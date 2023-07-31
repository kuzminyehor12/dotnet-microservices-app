namespace Discount.DataAccess.Entities
{
    public class Coupon : BaseEntity
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public static Coupon Default()
        {
            return new Coupon
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No Discount"
            };
        }
    }
}
