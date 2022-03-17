using System;
using System.Text.Json.Serialization;

namespace NA_KD.User.Client.Model.Customer
{
	public class CreateCustomerResponse
	{
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}

