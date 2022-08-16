using Microsoft.AspNetCore.Mvc;
using Potato.Product.Application.AppServices;
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
        await _productAppService.InsertAsync(productDto);

        return Ok();
    }

    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(Guid productId) 
    {
        var retorno = await _productAppService.DeleteAsyncWithReturn(productId);
        return retorno? Ok() : BadRequest("ID Inválido: " + productId);
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
