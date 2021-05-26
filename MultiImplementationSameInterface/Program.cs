using System;
using Microsoft.Extensions.DependencyInjection;

namespace MultiImplementationSameInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var serviceProvider = ConfigureService()
                          .BuildServiceProvider();
            
            serviceProvider.GetService<Processor>().Process();

            System.Console.ReadLine();
        }

        private static IServiceCollection ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ShoppingCartCache>();
            services.AddScoped<ShoppingCartDb>();
            services.AddScoped<ShoppingCartApi>();
            
            //Transient because the scope of this delegate is to provide the proper service type and then get descoped
            services.AddTransient<Func<ShoppingCartServiceType,IShoppingCart>>(svcProvider => svcTypeName => {
                switch (svcTypeName)
                {
                    case ShoppingCartServiceType.Cache:
                        return svcProvider.GetService<ShoppingCartCache>();
                    case ShoppingCartServiceType.Db:
                        return svcProvider.GetService<ShoppingCartDb>();
                    case ShoppingCartServiceType.Api:
                        return svcProvider.GetService<ShoppingCartApi>();
                    default:
                        return null;
                }
            });

            services.AddTransient<Processor>();

            return services;
        }
    }
}
