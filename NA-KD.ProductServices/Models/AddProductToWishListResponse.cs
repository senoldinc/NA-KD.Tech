using System;
using System.Text.Json.Serialization;

namespace NA_KD.ProductServices.Models
{
	public class AddProductToWishListResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
}

