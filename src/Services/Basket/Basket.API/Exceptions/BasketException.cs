namespace Basket.API.Exceptions
{
    public class BasketException : Exception
    {
        public BasketException() : base() { }

        public BasketException(string message) : base(message) { }

        public BasketException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
