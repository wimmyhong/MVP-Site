using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Mvp.Feature.MvpListing.Models
{
    public class MvpListing
    {
        public TextField Year { get; set; }

        public MvpCategory[] Categories { get; set; }

        public MvpData MvpData { get; set; }
    }
}