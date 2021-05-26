using System;

namespace MultiImplementationSameInterface
{
    public class ShoppingCartDb : IShoppingCart
    {
        public object GetCart()
        {
        return "Cart returned from DB";
        }
    }
}