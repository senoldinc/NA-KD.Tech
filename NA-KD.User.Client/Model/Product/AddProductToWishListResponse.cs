using System;
using System.Text.Json.Serialization;

namespace NA_KD.User.Client.Model.Product
{
	public class AddProductToWishListResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
}

