using System;
using System.Text.Json.Serialization;

namespace NA_KD.ProductServices.Models
{
	public class AddProductToWishListRequest
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}

