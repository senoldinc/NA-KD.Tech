using System;
using System.Net;
using NA_KD.ProductServices.Models;
using RestSharp;

namespace NA_KD.ProductServices.Service
{
    public class NaKdProductService : INaKdProductService
    {
        private RestClient client;
        private string _url = "https://nakdbaseserviceapi20211025120549.azurewebsites.net/api/customer";
        public NaKdProductService()
        {
            client = new RestClient(_url);
            client.UseJson();
        }

        public RestRequest GetRequest(string resource, Method method = Method.Get)
        {
            var request = new RestRequest(resource, method);
            request.Timeout = Int32.MaxValue;
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public async Task<AddProductToWishListResponse> AddProductToWishList(string customerId, AddProductToWishListRequest model)
        {
            var request = GetRequest(String.Format("/v1/customers/{0}/wishListProducts", customerId), Method.Post);
            request.AddBody(model);
            var serviceResult = await client.ExecuteAsync<AddProductToWishListResponse>(request);
            return serviceResult.Data;
        }

        public async Task<HttpResponseMessage> RemoveProductToWishList(string id, string productId)
        {
            var request = GetRequest(String.Format("/v1/customers/{0}/wishListProducts/{1}", id, productId), Method.Delete);
            var serviceResult = await client.ExecuteAsync(request);
            return new HttpResponseMessage(serviceResult.StatusCode);
        }
    }
}

