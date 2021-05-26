using System;

namespace MultiImplementationSameInterface
{
    public class ShoppingCartApi : IShoppingCart
    {
        public object GetCart()
        {
            return $"Cart returned from API";
        }
    }
}