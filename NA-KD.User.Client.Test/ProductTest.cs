using System;
using System.Net;
using NA_KD.User.Client.Services;
using Xunit;

namespace NA_KD.User.Client.Test
{
	public class ProductTest
	{
        private string _url = "https://localhost:7198";

        [Fact]
        public async void AddProductToWishList()
        {
            //arrange
            var productService = new ProductServices(_url);
            var productRequest = new Model.Product.AddProductToWishListRequest
            {
                Id = "54ca873f-089b-434f-aa38-8ed66140b885",
                Name = "Test_Test",
                Description = "Test"
            };

            //act
            var serviceResult = await productService.AddProductToWishList("59cef5f6-d372-424d-8727-f19b1024a91f", productRequest);

            //assert
            Assert.NotNull(serviceResult);
            Assert.Equal(serviceResult.StatusCode, HttpStatusCode.NoContent);
        }

        [Fact]
        public async void RemoveProductToWishList()
        {
            //arrange
            var productService = new ProductServices(_url);

            //act
            var serviceResult = await productService.RemoveProductToWishList("59cef5f6-d372-424d-8727-f19b1024a91f", "54ca873f-089b-434f-aa38-8ed66140b885");

            //assert
            Assert.NotNull(serviceResult);
            Assert.Equal(serviceResult.StatusCode, HttpStatusCode.OK);
        }
    }
}

