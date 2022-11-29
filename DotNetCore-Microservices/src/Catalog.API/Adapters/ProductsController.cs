using Catalog.API.Domains.Entities;
using Catalog.API.Domains.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Adapters;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IRepository<Product> _repository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IRepository<Product> repository, ILogger<ProductsController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        //Use extension method to convert Item to Item Dto
        var items = await _repository.GetAllAsync();
        return Ok(items);
    }


    [HttpGet("id")]
    public async Task<IActionResult> GetProduct(string id)
    {
        //Use extension method to convert Item to Item Dto
        var item = await _repository.GetAsync(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        //Use extension method to convert Item to Item Dto
        await _repository.CreateAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}