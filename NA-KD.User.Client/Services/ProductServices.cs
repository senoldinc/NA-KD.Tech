using System;
using RestSharp;
using NA_KD.User.Client.Model.Product;

namespace NA_KD.User.Client.Services
{
	public class ProductServices
	{
		private RestClient client;

		public ProductServices(string url)
		{
			client = new RestClient(url);
			client.UseJson();
		}

		public RestRequest GetRequest(string resource, Method method = Method.Get)
		{
			var request = new RestRequest(resource, method);
			request.Timeout = Int32.MaxValue;
			request.RequestFormat = DataFormat.Json;
			return request;
		}

		public async Task<RestResponse<AddProductToWishListResponse>> AddProductToWishList(string customerId,
																						   AddProductToWishListRequest model)
		{
			var request = GetRequest(String.Format("/api/product/{0}/wishlist", customerId), Method.Post);
			request.AddBody(model);
			var serviceResult = await client.ExecuteAsync<AddProductToWishListResponse>(request);
			return serviceResult;
		}

		public async Task<RestResponse> RemoveProductToWishList(string customerId, string productId)
        {
			var request = GetRequest(String.Format("/api/product/{0}/wishlist/{1}", customerId, productId), Method.Delete);
			var serviceResult = await client.ExecuteAsync(request);
			return serviceResult;
		}
	}
}

