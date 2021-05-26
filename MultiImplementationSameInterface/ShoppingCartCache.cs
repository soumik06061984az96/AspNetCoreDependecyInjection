using System;

namespace MultiImplementationSameInterface
{
    public class ShoppingCartCache : IShoppingCart
    {
        public object GetCart()
        {
            return $"Cart returned from cache";
        }
    }
}