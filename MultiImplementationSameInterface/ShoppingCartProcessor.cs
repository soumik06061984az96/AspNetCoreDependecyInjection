using System;

namespace MultiImplementationSameInterface
{
    public class Processor
    {
        private readonly Func<ShoppingCartServiceType, IShoppingCart> _serviceResolver = null;

        public Processor(Func<ShoppingCartServiceType, IShoppingCart> serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public void Process()
        {
            ProcessFromCache();
            ProcessFromDb();
            ProcessFromApi();
        }
        private void ProcessFromCache()
        {
            var service = _serviceResolver(ShoppingCartServiceType.Cache);
            Console.WriteLine(service.GetCart());
        }

        private void ProcessFromDb()
        {
            var service = _serviceResolver(ShoppingCartServiceType.Db);
            Console.WriteLine(service.GetCart());
        }

        private void ProcessFromApi()
        {
            var service = _serviceResolver(ShoppingCartServiceType.Api);
            Console.WriteLine(service.GetCart());
        }
    }
}