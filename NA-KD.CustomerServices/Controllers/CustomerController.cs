using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA_KD.CustomerServices.Models;
using NA_KD.CustomerServices.Service;

namespace NA_KD.CustomerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private INaKdCustomerService _naKdCustomerService;
        public CustomerController(INaKdCustomerService naKdCustomerService)
        {
            _naKdCustomerService = naKdCustomerService;
        }

        [HttpPost]
        public async Task<CreateCustomerServiceResponse> Post([FromBody]CreateCustomerServiceRequest request)
        {
            return await _naKdCustomerService.CreateCustomer(request);
        }

        [HttpGet("{id}")]
        public async Task<QueryCustomerResponse> GetById(string id)
        {
            return await _naKdCustomerService.QueryCustomer(id);
        }

    }
}