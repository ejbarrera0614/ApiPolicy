using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface IPolicyVehicleService
{
    Task<List<PolicyVehicle>> GetPolicyVehicleAsync();
    Task<PolicyVehicle> GetPolicyVehicleByIdAsync(int id);
    void AddPolicyVehicleAsync(PolicyVehicle policyVehicle);
    void UpdatePolicyVehicleAsync(PolicyVehicle policyVehicle);
    void DeletePolicyVehicleAsync(int id);
}
