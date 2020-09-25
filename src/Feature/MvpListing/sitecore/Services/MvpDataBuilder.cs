using Mvp.Feature.MvpListing.Models;
using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;

namespace Mvp.Feature.MvpListing.Services
{
    public class MvpDataBuilder : IMvpDataBuilder
    {
        public MvpData GetMvpData(Item contextItem, Rendering rendering)
        {
            var dataSourceItem = contextItem?.Database?.GetItem(rendering.DataSource);
            if (dataSourceItem == null)
            {
                throw new NullReferenceException("MvpDataBuilder: Datasource not found");
            }

            int year;
            if(!int.TryParse(dataSourceItem[Constants.FieldNames.Year], out year))
            {
                throw new ArgumentException("MvpDataBuilder: Year value cannot be parsed to int");
            }

            return new MvpData
            {
                Year = year,
                Mvps = GenerateMvpDataForYear(dataSourceItem, year)
            };
        }

        private Dictionary<string, Dictionary<string, string>> GenerateMvpDataForYear(Item dataSourceItem, int year)
        {
            if(string.IsNullOrWhiteSpace(dataSourceItem[Constants.FieldNames.Data]))
            {
                throw new ArgumentNullException("MvpDataBuilder: Json MVP data not found");
            }

            var jsonData = JObject.Parse(dataSourceItem[Constants.FieldNames.Data]);
            return new Dictionary<string, Dictionary<string, string>>();
        }
    }
}