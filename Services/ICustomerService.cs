using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface ICustomerService
{
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    void AddCustomerAsync(Customer Customer);
    void UpdateCustomerAsync(Customer Customer);
    void DeleteCustomerAsync(int id);
}
