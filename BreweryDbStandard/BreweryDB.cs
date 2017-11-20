using BreweryDbStandard.Models;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDbStandard
{
    public class BreweryDB
    {
        static HttpClient Client = new HttpClient();

        const string ApiUrl = "http://api.brewerydb.com/v2/";

        public async Task<BreweryDbResponse> Search(string key, string searchQuery, SearchParams searchParams = null)
        {
            var builder = new UriBuilder(ApiUrl + "/search");
            var query = new ParameterCollection();

            query.Add("key", key);
            query.Add("q", searchQuery);

            AddQueryParams(query, searchParams);

            builder.Query = query.ToString();

            var response = await Client.GetAsync(builder.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Did not get a successful response from BreweryDB. Reason: " + response.RequestMessage);
            }

            return JsonConvert.DeserializeObject<BreweryDbResponse>(await response.Content.ReadAsStringAsync());
        }

        private void AddQueryParams(ParameterCollection query, SearchParams searchParams)
        {
            if (searchParams == null)
            {
                return;
            }

            if (searchParams.Type.Value != SearchTypes.ALL.Value)
            {
                query.Add("type", searchParams.Type.Value);
            }

            AddQueryParamIfNotNullAndTrue(query, searchParams.WithAlternateNames, "withAlternateNames");
            AddQueryParamIfNotNullAndTrue(query, searchParams.WithBreweries, "withBreweries");
            AddQueryParamIfNotNullAndTrue(query, searchParams.WithGuilds, "withGuilds");
            AddQueryParamIfNotNullAndTrue(query, searchParams.WithIngredients, "withIngredients");
            AddQueryParamIfNotNullAndTrue(query, searchParams.WithLocations, "withLocations");
            AddQueryParamIfNotNullAndTrue(query, searchParams.WithSocialAccounts, "withSocialAccounts");
        }

        private void AddQueryParamIfNotNullAndTrue(ParameterCollection queryParams, bool? param, string paramName)
        {
            if (param != null && param.Value)
            {
                queryParams.Add(paramName, "Y");
            }
            else if (param != null && !param.Value)
            {
                queryParams.Add(paramName, "N");
            }
        }
    }

    // Based on https://stackoverflow.com/a/17096340
    internal class ParameterCollection
    {
        private Dictionary<string, string> _parms = new Dictionary<string, string>();

        public void Add(string key, string val)
        {
            if (_parms.ContainsKey(key))
            {
                throw new InvalidOperationException(string.Format("The key {0} already exists.", key));
            }
            _parms.Add(key, val);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var kvp in _parms)
            {
                if (sb.Length > 0) { sb.Append("&"); }
                sb.AppendFormat("{0}={1}",
                    WebUtility.UrlEncode(kvp.Key),
                    WebUtility.UrlEncode(kvp.Value));
            }
            return sb.ToString();
        }
    }

}
