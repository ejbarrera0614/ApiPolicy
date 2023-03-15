using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesAPI.Services;
public class CoverageService : ICoverageService
{
    private readonly InsurancePoliciesContext _context;

    public CoverageService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<Coverage>> GetCoveragesAsync()
    {
        try
        {
            return await _context.Coverages.ToListAsync();
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
            System.Diagnostics.Debug.WriteLine(e);
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
            return null;
        }
    }

    public async Task<Coverage> GetCoverageByIdAsync(int id)
    {
        try
        {
            return _context.Coverages.FirstOrDefault(p => p.ID == id);
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
            System.Diagnostics.Debug.WriteLine(e);
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
            return null;
        }
    }

    public void AddCoverageAsync(Coverage coverage)
    {
        try
        {
            _context.Coverages.Add(coverage);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
            System.Diagnostics.Debug.WriteLine(e);
            System.Diagnostics.Debug.WriteLine("--------------->Error<------------------");
        }
    }

    public async void UpdateCoverageAsync(Coverage coverage)
    {
        _context.Coverages.Update(coverage);
        _context.SaveChanges();
    }

    public async void DeleteCoverageAsync(int id)
    {
        var policy = _context.Coverages.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.Coverages.Remove(policy);
            _context.SaveChanges();
        }
    }
}
