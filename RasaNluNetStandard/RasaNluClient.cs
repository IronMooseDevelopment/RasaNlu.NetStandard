using IronMooseDevelopment.RasaNlu.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IronMooseDevelopment.RasaNlu
{
    public class RasaNluClient : IRasaNluClient
    {
        static readonly HttpClient Client = new HttpClient();

        private string BaseDomain { get; set; }

        public RasaNluClient(string baseDomain)
        {
            BaseDomain = baseDomain;
        }

        #region Parse

        public virtual async Task<DialogflowParseResponse> ParseAsDialogflow(string parseQuery, string project)
        {
            return await Parse<DialogflowParseResponse>(parseQuery, project);
        }

        public virtual async Task<LuisParseResponse> ParseAsLuis(string parseQuery, string project)
        {
            return await Parse<LuisParseResponse>(parseQuery, project);
        }

        public virtual async Task<RasaParseResponse> ParseAsRasa(string parseQuery, string project)
        {
            return await Parse<RasaParseResponse>(parseQuery, project);
        }

        private async Task<T> Parse<T>(string parseQuery, string project)
        {
            var body = new ParseBody
            {
                Query = parseQuery,
                Project = project
            };
            var json = JsonConvert.SerializeObject(body);

            var response = await Client.PostAsync(BaseDomain + "/parse", new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Did not get a successful response from RASA. Reason: " + response.RequestMessage);
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        #endregion
    }
}
