using System;
using Newtonsoft.Json;

namespace IntegrationTesting.Tests.Models
{
    public class CreateResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
