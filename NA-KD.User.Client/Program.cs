using NA_KD.User.Client.Controller;
using NA_KD.User.Client.Model.Customer;
using NA_KD.User.Client.Services;
using RestSharp;

namespace NA_KD.User.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //todo: read this endpoint from the appsettings ...
            var customerServices = new CustomerServices("https://localhost:7167");
            var productServices = new ProductServices("https://localhost:7198");

            //Console App - Functionality...
            Console.WriteLine("Hello, NA-KD user!");
            Console.WriteLine("What would you like to do ?");
            Console.WriteLine("Please write only the transaction first letter.");

            var key = string.Empty;

            while (key != "X")
            {
                Console.WriteLine("U: User Creat");
                Console.WriteLine("A: Add Product to Wish List");
                Console.WriteLine("R: Remove Product to Wish List");
                Console.WriteLine("Q: Query to Customer Product Wish List");
                Console.Write(">");
                key = Console.ReadLine()?.ToUpperInvariant();
                Console.WriteLine();

                switch (key)
                {
                    case "U":
                        var customer = CustomerController.GetCustomerFromConsole();

                        var createCustomerResult = await customerServices.CreateCustomer(new CreateCustomerRequest
                                                { Name = customer.Name,
                                                  Description = customer.Description,
                                                  Id = Guid.NewGuid().ToString(),
                                                  Enabled = true
                                                 });

                        if (createCustomerResult.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Console.Write($"Customer is created. Customer id: {createCustomerResult.Data.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Uppss! Something get wrongs...");
                        }

                        break;
                    case "A":
                        var product = ProductController.GetProductFromConsole();

                        var addProductResult = await productServices.AddProductToWishList(product.CustomerId,
                                                                new Model.Product.AddProductToWishListRequest
                                                                {
                                                                   Id = Guid.NewGuid().ToString(),
                                                                   Name = product.Name,
                                                                   Description = product.Description
                                                                });

                        if (addProductResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            Console.Write("Product added to wish list.");
                        }
                        else
                        {
                            Console.WriteLine("Uppss! Something get wrongs...");
                        }
                        break;
                    case "R":
                        var removeProduct = ProductController.GetRemoveProductFromConsole();

                        var removeProductResult = await productServices.RemoveProductToWishList(removeProduct.CustomerId, removeProduct.ProductId);
                        if (removeProductResult.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Console.Write("Product removed to wish list.");
                        }
                        else
                        {
                            Console.WriteLine("Uppss! Something get wrongs...");
                        }
                        break;
                    case "Q":
                        Console.Write("Customer Id: ");
                        string queryCustomerId = Console.ReadLine();
                        var queryCustomerResult = await customerServices.QueryCustomer(queryCustomerId);

                        if (queryCustomerResult.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var queryCustomerData = queryCustomerResult.Data;
                            if (queryCustomerData != null)
                            {
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("Name           | Description");
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine(String.Format("{0,-15}|{1}", queryCustomerData.Name, queryCustomerData.Description));
                                Console.WriteLine("------------------------------------");

                                if (queryCustomerData.WishListProducts != null && queryCustomerData.WishListProducts.Count > 0)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Wish List");
                                    Console.WriteLine("--------------------------------------------------------------------");
                                    Console.WriteLine("Name           | Description   | Id");
                                    Console.WriteLine("--------------------------------------------------------------------");
                                    foreach (var item in queryCustomerData.WishListProducts)
                                    {
                                        Console.WriteLine(String.Format("{0,-15}|{1,-15}|{2}", item.Name, item.Description, item.Id));
                                    }
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Uppss! Something get wrongs...");
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong typing!! Please write only U, A, R or Q.");
                        break;
                }

                Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}