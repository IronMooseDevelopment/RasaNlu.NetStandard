using Newtonsoft.Json;
using System.Collections.Generic;

namespace IronMooseDevelopment.RasaNlu.Models
{

    public partial class RasaParseResponse
    {
        [JsonProperty("intent")]
        public RasaIntent Intent { get; set; }

        [JsonProperty("entities")]
        public List<RasaEntity> Entities { get; set; }

        [JsonProperty("intent_ranking")]
        public List<RasaIntent> IntentRanking { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }

    public partial class RasaEntity
    {
        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("extractor")]
        public string Extractor { get; set; }
    }

    public partial class RasaIntent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}
