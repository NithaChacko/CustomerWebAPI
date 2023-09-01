using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Service
{
    public interface ICustomerWebService
    {
        [Get("/api/v1.0/get-customer/all")]
        Task<IEnumerable<Model.Customer>> GetAllCustomer();

        [Post("/api/v1.0/customer/create")]
        Task<Model.Customer> CreateCustomer([Body] Model.Customer customer);

        [Get("/api/v1.0/get-customer/{id}")]
        Task<Model.Customer> GetCustomerById(string id);

        [Put("/api/v1.0/customer/update")]
        Task<Model.Customer> UpdateCustomer([Body] Model.Customer customer);

        [Delete("/api/v1.0/delete-customer/{id}")]
        Task<string> DeleteCustomer(string id);
    }
}
