using System;
using NA_KD.CustomerServices.Models;

namespace NA_KD.CustomerServices.Service
{
	public interface INaKdCustomerService
	{
		Task<CreateCustomerServiceResponse> CreateCustomer(CreateCustomerServiceRequest request);

		Task<QueryCustomerResponse> QueryCustomer(string id);
	}
}

