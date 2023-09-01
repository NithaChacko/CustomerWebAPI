using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Service.Model;

namespace Customer.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Model.Customer>> GetAllCustomer();
        Task<Model.Customer> CreateCustomer(Model.Customer customer);
        Task<Model.Customer> GetCustomerById(string id);
        Task<Model.Customer> UpdateCustomer(Model.Customer customer);

        
        Task<string> DeleteCustomer(string id);
    }
}
    

