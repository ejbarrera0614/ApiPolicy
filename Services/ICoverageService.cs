using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface ICoverageService
{
    Task<List<Coverage>> GetCoveragesAsync();
    Task<Coverage> GetCoverageByIdAsync(int id);
    void AddCoverageAsync(Coverage coverage);
    void UpdateCoverageAsync(Coverage coverage);
    void DeleteCoverageAsync(int id);
}
