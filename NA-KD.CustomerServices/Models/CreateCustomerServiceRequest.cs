using System;
using System.Text.Json.Serialization;

namespace NA_KD.CustomerServices.Models
{
	public class CreateCustomerServiceRequest
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tenantId")]
        public string Id { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}

