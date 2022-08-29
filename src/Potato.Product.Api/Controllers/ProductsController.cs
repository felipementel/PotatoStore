using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Potato.Product.Application.Dtos;
using Potato.Product.Application.Interfaces.Services;


namespace Potato.Product.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("0.9", Deprecated = true)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public readonly IProductAppService _productAppService;

    public ProductController(
        ILogger<ProductController> logger,
        IProductAppService productAppService)
    {
        _logger = logger;
        _productAppService = productAppService;
    }

    [HttpGet("{productId}")]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(Guid productId)
    {
        var retorno = await _productAppService.GetByIdAsync(productId);

        return Ok(retorno);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        var item = await _productAppService.InsertAsync(productDto);

        return CreatedAtAction(nameof(GetById), new { productId = item.Id }, item);
    }

    [HttpPatch("{productId}")]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] JsonPatchDocument<ProductDto> patchProduct)
    {
        var entity = await _productAppService.GetByIdAsync(productId);

        if (entity == null)
        {
            return NotFound();
        }

        patchProduct.ApplyTo(entity, ModelState);
        var retorno = await _productAppService.PatchAsync(productId, entity);

        return Ok(retorno);
    }

    [HttpDelete("{productId}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(Guid productId)
    {
        var retorno = await _productAppService.DeleteAsync(productId);
        return retorno ? NoContent() : BadRequest($"ID Inválido: {productId}");
    }

    [HttpPut("{productId}")]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProductAsync(Guid productId, [FromBody] ProductDto productDto)
    {
        var item = await _productAppService.UpdateAsync(productId, productDto);

        return item is null ? NotFound() : Ok(item);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        var retorno = await _productAppService.GetAllAsync();

        return retorno.Any() ? Ok(retorno) : NotFound();

    }
}
