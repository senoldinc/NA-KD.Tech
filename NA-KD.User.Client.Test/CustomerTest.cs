using System;
using System.Net;
using NA_KD.User.Client.Services;
using Xunit;

namespace NA_KD.User.Client.Test;

public class CustomerTest
{
    private string _url = "https://localhost:7167";

    [Fact]
    public async void CreateUser()
    {
        //arrange
        var customerService = new CustomerServices(_url);
        var customerRequest = new Model.Customer.CreateCustomerRequest {
                                                                         Id = Guid.NewGuid().ToString(),
                                                                         Name = "Senol_Test",
                                                                         Description = "Test",
                                                                         Enabled = true
                                                                        };

        //act
        var serviceResult = await customerService.CreateCustomer(customerRequest);

        //assert
        Assert.NotNull(serviceResult);
        Assert.NotNull(serviceResult.Data);
        Assert.Equal(serviceResult.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async void QueryUser()
    {
        //arrange
        var customerService = new CustomerServices(_url);

        //act
        var serviceResult = await customerService.QueryCustomer("f7d20a22-109d-4db4-b1fe-8002943263de");

        //assert
        Assert.NotNull(serviceResult);
        Assert.NotNull(serviceResult.Data);
        Assert.Equal(serviceResult.StatusCode, HttpStatusCode.OK);
    }

}
