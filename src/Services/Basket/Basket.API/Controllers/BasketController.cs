using Basket.API.Entities;
using Basket.API.Repositories;
using Basket.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketRepository)
        {
            _basketService = basketRepository;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketAsync(userName, cancellationToken);
            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            var basket = await _basketService.UpdateBasketAsync(shoppingCart, cancellationToken);
            return Ok(basket);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
            await _basketService.DeleteBasketAsync(userName, cancellationToken);
            return Ok();
        }
    }
}
