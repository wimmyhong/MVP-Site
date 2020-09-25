using Mvp.Feature.MvpListing.Services;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;

namespace Mvp.Feature.MvpListing.LayoutService
{
    public class MvpDataContentResolver : RenderingContentsResolver
    {
        private readonly IMvpDataBuilder mvpDataBuilder;

        public MvpDataContentResolver(IMvpDataBuilder mvpDataBuilder)
        {
            this.mvpDataBuilder = mvpDataBuilder;
        }

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var mvpData = mvpDataBuilder.GetMvpData(GetContextItem(rendering, renderingConfig), rendering);
            return new
            {
                mvpData = mvpData
            };
        }
    }
}