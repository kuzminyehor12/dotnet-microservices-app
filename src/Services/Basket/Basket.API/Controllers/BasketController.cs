using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketAsync(userName, cancellationToken);
            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.UpdateBasketAsync(shoppingCart, cancellationToken);
            return Ok(basket);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
            await _basketRepository.DeleteBasketAsync(userName, cancellationToken);
            return Ok();
        }
    }
}
