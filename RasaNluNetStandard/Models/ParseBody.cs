using Newtonsoft.Json;

namespace IronMooseDevelopment.RasaNlu.Models
{
    public class ParseBody
    {
        [JsonProperty(propertyName: "q")]
        public string Query { get; set; }

        [JsonProperty(propertyName: "project")]
        public string Project { get; set; }
    }
}
