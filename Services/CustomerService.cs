using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesAPI.Services;
public class CustomerService : ICustomerService
{
    private readonly InsurancePoliciesContext _context;

    public CustomerService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<Customer>> GetCustomersAsync()
    {
        try
        {
            return await _context.Customers.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return _context.Customers.FirstOrDefault(p => p.ID == id);
    }

    public async void AddCustomerAsync(Customer Customer)
    {
        _context.Customers.Add(Customer);
        _context.SaveChanges();
    }

    public async void UpdateCustomerAsync(Customer Customer)
    {
        _context.Customers.Update(Customer);
        _context.SaveChanges();
    }

    public async void DeleteCustomerAsync(int id)
    {
        var policy = _context.Customers.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.Customers.Remove(policy);
            _context.SaveChanges();
        }
    }
}
