using Newtonsoft.Json;

namespace IronMooseDevelopment.RasaNlu.Models
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
