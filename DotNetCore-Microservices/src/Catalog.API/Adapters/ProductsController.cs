using Catalog.API.Domains.Entities;
using Catalog.API.Domains.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Adapters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IRepository<Product> _repository;
        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            //Use extension method to convert Item to Item Dto
            var items = (await _repository.GetAllAsync());
            return items;
        }

    }
}
