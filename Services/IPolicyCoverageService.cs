using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface IPolicyCoverageService
{
    Task<List<PolicyCoverage>> GetPolicyCoverageAsync();
    Task<PolicyCoverage> GetPolicyCoverageByIdAsync(int id);
    void AddPolicyCoverageAsync(PolicyCoverage policyCoverage);
    void UpdatePolicyCoverageAsync(PolicyCoverage policyCoverage);
    void DeletePolicyCoverageAsync(int id);
}
