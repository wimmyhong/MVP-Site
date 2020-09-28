using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mvp.Feature.Forms.Models
{
    public class LicenseRequest
    {
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Purpose { get; set; }
        public bool IncludePlatform { get; set; }
        public bool IncludeTdsRazl { get; set; }
        public bool IncludeFeydra { get; set; }
        public bool IncludeAvtor { get; set; }
        public bool Consent { get; set; }

    }
}
