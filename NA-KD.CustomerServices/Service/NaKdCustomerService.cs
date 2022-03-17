using System;
using NA_KD.CustomerServices.Models;
using RestSharp;

namespace NA_KD.CustomerServices.Service
{
	public class NaKdCustomerService : INaKdCustomerService
	{
        private RestClient client;
        private string _url = "https://nakdbaseserviceapi20211025120549.azurewebsites.net/api/customer";
        public NaKdCustomerService()
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

        public async Task<CreateCustomerServiceResponse> CreateCustomer(CreateCustomerServiceRequest model)
        {
            var request = GetRequest("/v1/customers", Method.Post);
            request.AddBody(model);
            var serviceResult = await client.ExecuteAsync<CreateCustomerServiceResponse>(request);
            return serviceResult.Data;
        }

        public async Task<QueryCustomerResponse> QueryCustomer(string id)
        {
            var request = GetRequest(String.Format("v1/customers/{0}", id));
            var serviceResult = await client.ExecuteAsync<QueryCustomerResponse>(request);
            return serviceResult.Data;
        }
    }
}

