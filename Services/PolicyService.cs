using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesAPI.Services;
public class PolicyService : IPolicyService
{
    private readonly InsurancePoliciesContext _context;

    public PolicyService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<Policy>> GetPoliciesAsync()
    {
        try
        {
            return await _context.Policies.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Policy> GetPolicyByIdAsync(int id)
    {
        return await _context.Policies.FirstOrDefaultAsync(p => p.ID == id);
    }
    public Policy GetPolicyByNumber(string number)
    {
        return _context.Policies.FirstOrDefault(p => p.PolicyNumber == number);
    }
    public async Task<Policy> GetPolicyByNumberPlateAsync(string number)
    {
        Console.WriteLine("GetPolicyByNumberPlateAsync ->" + number);

        var result = await (from p in _context.PolicyVehicle
                            join v in _context.Vehicles on p.VehicleID equals v.ID
                            join po in _context.Policies on p.PolicyID equals po.ID
                            where v.NumberPlate == number
                            select new { po.ID, po.PolicyNumber, po.MaxCoverage, po.DateInit, po.DateEnd })
                      .FirstOrDefaultAsync();

        Policy pol = new Policy()
        {
            ID = result.ID,
            PolicyNumber = result.PolicyNumber,
            MaxCoverage = result.MaxCoverage,
            DateInit = result.DateInit,
            DateEnd = result.DateEnd
        };
        return pol;
    }
    public async Task<ApiResponse<Policy>> AddPolicyAsync(Policy policy)
    {
        string error = "";
        if (policy.DateEnd < DateTime.Now)
        {
            error = "La fecha de expiración de la póliza ya caduco";
            return new ApiResponse<Policy>(false, null, error);
        }
        else
        {
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return new ApiResponse<Policy>(true, policy, error);
        }
    }
    public async Task<ApiResponse<PolicyVehicle>> AssignPolicyVehicleAsync(PolicyVehicle policyVehicle)
    {
        string error = "";
        Policy policy = await this.GetPolicyByIdAsync(policyVehicle.PolicyID);
        if (policy.DateEnd < DateTime.Now)
        {
            error = "La fecha de expiración es menor a la actual";
            return new ApiResponse<PolicyVehicle>(false, null, error);
        }
        else
        {
            _context.PolicyVehicle.Add(policyVehicle);
            await _context.SaveChangesAsync();
            return new ApiResponse<PolicyVehicle>(true, policyVehicle, error);

        }
    }
    public async void UpdatePolicyAsync(Policy policy)
    {
        _context.Policies.Update(policy);
        _context.SaveChanges();
    }

    public async void DeletePolicyAsync(int id)
    {
        var policy = _context.Policies.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.Policies.Remove(policy);
            _context.SaveChanges();
        }
    }
}
