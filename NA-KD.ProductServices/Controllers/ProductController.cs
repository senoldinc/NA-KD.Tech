using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NA_KD.ProductServices.Service;
using NA_KD.ProductServices.Models;

namespace NA_KD.ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private INaKdProductService _naKdProductService;
        public ProductController(INaKdProductService naKdProductService)
        {
            _naKdProductService = naKdProductService;
        }

        [HttpPost("{id}/wishlist")]
        public async Task<AddProductToWishListResponse> Post(string id,[FromBody] AddProductToWishListRequest request)
        {
            return await _naKdProductService.AddProductToWishList(id ,request);
        }

        [HttpDelete("{id}/wishlist/{productId}")]
        public async Task<HttpResponseMessage> Delete(string id, string productId)
        {
            return await _naKdProductService.RemoveProductToWishList(id, productId);
        }
    }
}