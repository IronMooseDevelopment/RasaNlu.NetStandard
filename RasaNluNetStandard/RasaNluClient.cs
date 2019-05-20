using IronMooseDevelopment.RasaNlu.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string errorMessage;
                try
                {
                    errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                }
                catch
                {
                    throw new RasaException("Did not get a successful response from RASA. Reason: " + response.RequestMessage);
                }
                throw new RasaException(errorMessage);
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        #endregion

        public virtual async Task<RasaStatus> Status()
        {
            var response = await Client.GetAsync(BaseDomain + "/status");

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage;
                try
                {
                    errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                }
                catch
                {
                    throw new RasaException("Did not get a successful response from RASA. Reason: " + response.RequestMessage);
                }
                throw new RasaException(errorMessage);
            }

            return JsonConvert.DeserializeObject<RasaStatus>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<bool> Train(Stream trainData, string project)
        {
            var body = new StreamContent(trainData);
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-yml");

            var request = new HttpRequestMessage(HttpMethod.Post, BaseDomain + "/train?project=" + project)
            {
                Content = body,
            };

            var response = await Client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage;
                try
                {
                    errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                }
                catch
                {
                    throw new RasaException("Did not get a successful response from RASA. Reason: " + response.RequestMessage);
                }
                throw new RasaException(errorMessage);
            }

            return true;
        }
    }
}
