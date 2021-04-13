using Newtonsoft.Json;

namespace IntegrationTesting.Tests.Models
{
    public class SupportData
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
