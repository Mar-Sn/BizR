using BizR.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace BizR
{
    public static class ServiceCollectionRegister
    {
        public static void AddBizR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBusinessFactory,BusinessFactory>();
        }
    }
}