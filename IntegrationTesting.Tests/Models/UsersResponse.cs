using Newtonsoft.Json;

namespace IntegrationTesting.Tests.Models
{
    public class UsersResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public UserData[] Data { get; set; }

        [JsonProperty("support")]
        public SupportData Support { get; set; }
    }
}
