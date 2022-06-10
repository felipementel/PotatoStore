using Microsoft.AspNetCore.Mvc;
using Potato.Product.Application.AppServices;
using Potato.Product.Application.Dtos;

namespace Potato.Product.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("0.9", Deprecated = true)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    //[HttpGet]
    //[MapToApiVersion("1.0")]
    //[Produces("application/json")]
    //[ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<IActionResult> GetAll()
    //{
    //    return Ok();
    //}

    [HttpPost]
    [MapToApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        ProductAppService productAppService = new ProductAppService();

        await productAppService.InsertAsync(productDto);

        return Ok();
    }
}
