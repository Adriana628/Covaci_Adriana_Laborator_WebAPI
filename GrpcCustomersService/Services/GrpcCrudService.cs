using Grpc.Core;
using GrpcCustomersService;
using DataAccess = Covaci_Adriana_Laborator2.Data;
using ModelAccess = Covaci_Adriana_Laborator2.Models;

namespace GrpcCustomersService.Services
{
    public class GrpcCrudService : CustomerService.CustomerServiceBase
    {

        private DataAccess.LibraryContext db = null;
        public GrpcCrudService(DataAccess.LibraryContext db)
        {
            this.db = db;
        }
        public override Task<CustomerList> GetAll(Empty empty, ServerCallContext
       context)
        {

            CustomerList pl = new CustomerList();
            var query = from cust in db.Customer
                        select new Customer()
                        {
                            CustomerId = cust.CustomerID,
                            Name = cust.Name,
                            Adress = cust.Adress
                        };
            pl.Item.AddRange(query.ToArray());
            return Task.FromResult(pl);
        }
        public override Task<Empty> Insert(Customer requestData, ServerCallContext
       context)
        {
            db.Customer.Add(new ModelAccess.Customer
            {
                CustomerID = requestData.CustomerId,
                Name = requestData.Name,
                Adress = requestData.Adress,
                BirthDate = DateTime.Parse(requestData.Birthdate)
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }


        public override Task<Customer> Update(Customer request, ServerCallContext context)
        {
            var customerToUpdate = db.Customer.FirstOrDefault(c => c.CustomerID == request.CustomerId);
            if (customerToUpdate == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Customer not found."));
            }

            customerToUpdate.Name = request.Name;
            customerToUpdate.Adress = request.Adress;
            customerToUpdate.BirthDate = DateTime.Parse(request.Birthdate);

            db.SaveChanges();

            return Task.FromResult(request);
        }

        public override Task<Empty> Delete(CustomerId request, ServerCallContext context)
        {
            var customerToDelete = db.Customer.FirstOrDefault(c => c.CustomerID == request.Id);
            if (customerToDelete == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Customer not found."));
            }

            db.Customer.Remove(customerToDelete);
            db.SaveChanges();

            return Task.FromResult(new Empty());
        }

        public override Task<Customer> Get(CustomerId request, ServerCallContext context)
        {
            // Căutăm clientul în baza de date
            var customer = db.Customer.FirstOrDefault(c => c.CustomerID == request.Id);
            if (customer == null)
            {
                // Aruncăm o excepție gRPC dacă clientul nu este găsit
                throw new RpcException(new Status(StatusCode.NotFound, "Customer not found."));
            }

            // Mapăm clientul din baza de date către modelul gRPC
            var grpcCustomer = new Customer
            {
                CustomerId = customer.CustomerID,
                Name = customer.Name,
                Adress = customer.Adress,
                Birthdate = customer.BirthDate?.ToString("yyyy-MM-dd")
            };

            // Returnăm clientul către clientul gRPC
            return Task.FromResult(grpcCustomer);
        }


    }
}
