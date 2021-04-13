using Newtonsoft.Json;

namespace IntegrationTesting.Tests.Models
{
    public class UserRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
