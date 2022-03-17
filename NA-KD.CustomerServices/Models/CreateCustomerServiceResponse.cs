using System;
using System.Text.Json.Serialization;

namespace NA_KD.CustomerServices.Models
{
	public class CreateCustomerServiceResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
}

