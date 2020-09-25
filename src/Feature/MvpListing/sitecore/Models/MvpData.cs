using System.Collections.Generic;

namespace Mvp.Feature.MvpListing.Models
{
    public class MvpData
    {
        public int Year { get; set; }

        public Dictionary<string, Dictionary<string, string>> Mvps { get; set; }
    }
}