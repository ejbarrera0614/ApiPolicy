using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesAPI.Services;
public class PolicyCoverageService : IPolicyCoverageService
{
    private readonly InsurancePoliciesContext _context;

    public PolicyCoverageService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<PolicyCoverage>> GetPolicyCoverageAsync()
    {
        try
        {
            return await _context.PolicyCoverage.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<PolicyCoverage> GetPolicyCoverageByIdAsync(int id)
    {
        return _context.PolicyCoverage.FirstOrDefault(p => p.ID == id);
    }

    public async void AddPolicyCoverageAsync(PolicyCoverage policyCoverage)
    {
        _context.PolicyCoverage.Add(policyCoverage);
        _context.SaveChanges();
    }

    public async void UpdatePolicyCoverageAsync(PolicyCoverage policyCoverage)
    {
        _context.PolicyCoverage.Update(policyCoverage);
        _context.SaveChanges();
    }

    public async void DeletePolicyCoverageAsync(int id)
    {
        var policy = _context.PolicyCoverage.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.PolicyCoverage.Remove(policy);
            _context.SaveChanges();
        }
    }
}
