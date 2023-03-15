using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InsurancePoliciesAPI.Services;
public class PolicyVehicleService : IPolicyVehicleService
{
    private readonly InsurancePoliciesContext _context;

    public PolicyVehicleService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<PolicyVehicle>> GetPolicyVehicleAsync()
    {
        try
        {
            return await _context.PolicyVehicle.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<PolicyVehicle> GetPolicyVehicleByIdAsync(int id)
    {
        return _context.PolicyVehicle.FirstOrDefault(p => p.ID == id);
    }

    public async void AddPolicyVehicleAsync(PolicyVehicle policyVehicle)
    {
        _context.PolicyVehicle.Add(policyVehicle);
        _context.SaveChanges();
    }

    public async void UpdatePolicyVehicleAsync(PolicyVehicle policyVehicle)
    {
        _context.PolicyVehicle.Update(policyVehicle);
        _context.SaveChanges();
    }

    public async void DeletePolicyVehicleAsync(int id)
    {
        var policy = _context.PolicyVehicle.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.PolicyVehicle.Remove(policy);
            _context.SaveChanges();
        }
    }
}
