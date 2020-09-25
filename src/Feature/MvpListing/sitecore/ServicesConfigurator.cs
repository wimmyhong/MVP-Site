using Microsoft.Extensions.DependencyInjection;
using Mvp.Feature.MvpListing.Services;
using Sitecore.DependencyInjection;

namespace Mvp.Feature.MvpListing
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMvpDataBuilder, MvpDataBuilder>();
        }
    }
}