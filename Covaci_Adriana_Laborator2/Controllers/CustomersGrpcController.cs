using Grpc.Net.Client;
using GrpcCustomersService;
using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc;
using Covaci_Adriana_Laborator2.Models;

namespace Covaci_Adriana_Laborator2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {
            channel = GrpcChannel.ForAddress("https://localhost:7161");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GrpcCustomersService.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new
                CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var grpcCustomer = client.Get(new CustomerId { Id = id });

            var modelCustomer = new Covaci_Adriana_Laborator2.Models.Customer
            {
                CustomerID = grpcCustomer.CustomerId,
                Name = grpcCustomer.Name,
                Adress = grpcCustomer.Adress,
                BirthDate = DateTime.TryParse(grpcCustomer.Birthdate, out var birthDate) ? birthDate : null
            };

            return View(modelCustomer);
        }

        [HttpPost]
        public IActionResult Edit(Covaci_Adriana_Laborator2.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var grpcCustomer = new GrpcCustomersService.Customer
                {
                    CustomerId = customer.CustomerID,
                    Name = customer.Name,
                    Adress = customer.Adress,
                    Birthdate = customer.BirthDate?.ToString("yyyy-MM-dd")
                };

                var client = new CustomerService.CustomerServiceClient(channel);
                client.Update(grpcCustomer);

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var grpcCustomer = client.Get(new CustomerId { Id = id });

            var modelCustomer = new Covaci_Adriana_Laborator2.Models.Customer
            {
                CustomerID = grpcCustomer.CustomerId,
                Name = grpcCustomer.Name,
                Adress = grpcCustomer.Adress,
                BirthDate = DateTime.TryParse(grpcCustomer.Birthdate, out var birthDate) ? birthDate : null
            };

            return View(modelCustomer);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int CustomerID)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var grpcCustomer = client.Get(new CustomerId { Id = CustomerID });
            client.Delete(new CustomerId { Id = CustomerID });

            return RedirectToAction(nameof(Index));
        }


    }
}
