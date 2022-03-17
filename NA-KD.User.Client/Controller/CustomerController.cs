using System;
using NA_KD.User.Client.ViewModel;

namespace NA_KD.User.Client.Controller
{
	public static class CustomerController
	{
		public static CustomerViewModel GetCustomerFromConsole()
		{
			var customerModel = new CustomerViewModel();
			Console.Write("Name: ");
			customerModel.Name = Console.ReadLine();
			Console.Write("Description: ");
			customerModel.Description = Console.ReadLine();
			return customerModel;
		}
	}
}

