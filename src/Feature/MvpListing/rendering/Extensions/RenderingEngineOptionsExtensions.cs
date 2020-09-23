using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Mvp.Feature.MvpListing.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureMvpListing(this RenderingEngineOptions options)
        {
            options.AddModelBoundView<Models.MvpListing>("MvpListing");
            return options;
        }
    }
}