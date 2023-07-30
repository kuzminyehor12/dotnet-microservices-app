using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet("{productName}")]
        [ProducesResponseType(typeof(Coupon), StatusCodes.Status200OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscountAsync(productName, cancellationToken);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDiscount(Coupon coupon, CancellationToken cancellationToken)
        {
            var result = await _discountRepository.CreateAsync(coupon, cancellationToken);
            return result ? CreatedAtAction(nameof(CreateDiscount), coupon) : BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateDiscount(Coupon coupon, CancellationToken cancellationToken)
        {
            var result = await _discountRepository.UpdateAsync(coupon, cancellationToken);
            return result ? Ok(coupon) : BadRequest();
        }

        [HttpDelete("{productName}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteDiscount(string productName, CancellationToken cancellationToken)
        {
            var result = await _discountRepository.DeleteCouponAsync(productName, cancellationToken);
            return result ? Ok(new { ProductName = productName }) : BadRequest();
        }
    }
}
