using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IronMooseDevelopment.RasaNlu.Models
{
    public partial class DialogflowParseResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty("action")]
        public object Action { get; set; }

        [JsonProperty("actionIncomplete")]
        public object ActionIncomplete { get; set; }

        [JsonProperty("parameters")]
        public Dictionary<string, List<string>> Parameters { get; set; }

        [JsonProperty("contexts")]
        public List<object> Contexts { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty("score")]
        public object Score { get; set; }
    }

    public partial class Fulfillment
    {
    }

    public partial class Metadata
    {
        [JsonProperty("intentId")]
        public Guid IntentId { get; set; }

        [JsonProperty("webhookUsed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool WebhookUsed { get; set; }

        [JsonProperty("intentName")]
        public IntentName IntentName { get; set; }
    }

    public partial class IntentName
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}

