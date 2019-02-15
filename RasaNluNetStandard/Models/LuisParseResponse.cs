using Newtonsoft.Json;
using System.Collections.Generic;

namespace IronMooseDevelopment.RasaNlu.Models
{
    public partial class LuisParseResponse
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("topScoringIntent")]
        public LuisIntent TopScoringIntent { get; set; }

        [JsonProperty("intents")]
        public List<LuisIntent> Intents { get; set; }

        [JsonProperty("entities")]
        public List<LuisEntity> Entities { get; set; }
    }

    public partial class LuisEntity
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("startIndex")]
        public long StartIndex { get; set; }

        [JsonProperty("endIndex")]
        public long EndIndex { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public partial class LuisIntent
    {
        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}
