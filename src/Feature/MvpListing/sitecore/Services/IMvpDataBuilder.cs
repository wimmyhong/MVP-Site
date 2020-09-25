using Mvp.Feature.MvpListing.Models;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Mvp.Feature.MvpListing.Services
{
    public interface IMvpDataBuilder
    {
        MvpData GetMvpData(Item contextItem, Rendering rendering);
    }
}