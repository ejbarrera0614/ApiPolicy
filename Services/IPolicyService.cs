using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface IPolicyService
{
    Task<List<Policy>> GetPoliciesAsync();
    Task<Policy> GetPolicyByIdAsync(int id);
    Policy GetPolicyByNumber(string number);   
    Task<Policy> GetPolicyByNumberPlateAsync(string number);     
    Task<ApiResponse<Policy>> AddPolicyAsync(Policy policy);     
    Task<ApiResponse<PolicyVehicle>> AssignPolicyVehicleAsync(PolicyVehicle policyVehicle);
    void UpdatePolicyAsync(Policy policy);
    void DeletePolicyAsync(int id);
}
