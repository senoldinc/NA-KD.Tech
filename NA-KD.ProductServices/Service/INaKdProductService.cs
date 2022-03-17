using System;
using System.Net;
using NA_KD.ProductServices.Models;

namespace NA_KD.ProductServices.Service
{
	public interface INaKdProductService
	{
		Task<AddProductToWishListResponse> AddProductToWishList(string id, AddProductToWishListRequest request);

		Task<HttpResponseMessage> RemoveProductToWishList(string id, string productId);
	}
}

