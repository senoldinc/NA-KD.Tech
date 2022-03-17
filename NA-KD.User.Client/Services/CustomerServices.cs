using System;
using NA_KD.User.Client.Model.Customer;
using RestSharp;

namespace NA_KD.User.Client.Services
{
	public class CustomerServices
	{
		private RestClient client;

		public CustomerServices(string url)
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

		public async Task<RestResponse<CreateCustomerResponse>> CreateCustomer(CreateCustomerRequest model)
		{
			var request = GetRequest("/api/customer", Method.Post);
			request.AddBody(model);
			var serviceResult = await client.ExecuteAsync<CreateCustomerResponse>(request);
			return serviceResult;
		}

		public async Task<RestResponse<QueryCustomerResponse>> QueryCustomer(string id)
        {
			var request = GetRequest(String.Format("/api/customer/{0}", id), Method.Get);
			var serviceResult = await client.ExecuteAsync<QueryCustomerResponse>(request);
			return serviceResult;
		}


	}
}

