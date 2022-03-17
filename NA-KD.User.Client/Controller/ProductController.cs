using System;
using NA_KD.User.Client.ViewModel;

namespace NA_KD.User.Client.Controller
{
	public static class ProductController
	{
		public static ProductViewModel GetProductFromConsole()
        {
			var productModel = new ProductViewModel();
			Console.Write("Customer Id: ");
			productModel.CustomerId = Console.ReadLine();
			Console.Write("Name: ");
			productModel.Name = Console.ReadLine();
			Console.Write("Description: ");
			productModel.Description = Console.ReadLine();
			return productModel;
		}

		public static RemoveProductViewModel GetRemoveProductFromConsole()
        {
			var removeProductModel = new RemoveProductViewModel();
			Console.Write("Customer Id: ");
			removeProductModel.CustomerId = Console.ReadLine();
			Console.Write("Product Id: ");
			removeProductModel.ProductId = Console.ReadLine();
			return removeProductModel;
		}
	}
}

