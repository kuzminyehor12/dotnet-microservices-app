using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(string id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FirstAsync(p => p.Id == id, cancellationToken);
            return Ok(product);
        }


        [HttpGet("{category}/products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllByFilterAsync(p => p.Category == category, cancellationToken);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            var result = await _productRepository.CreateAsync(product, cancellationToken);
            return result ? CreatedAtRoute(nameof(CreateProduct), product) : BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            var result = await _productRepository.UpdateAsync(product, cancellationToken);
            return result ? Ok(product) : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> DeleteProduct(string id, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteOneAsync(id, cancellationToken);
            return result ? Ok(new { Id = id }) : BadRequest();
        }
    }
}
