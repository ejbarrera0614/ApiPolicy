using InsurancePoliciesAPI.Models;

namespace InsurancePoliciesAPI.Services;
public interface IVehicleService
{
    Task<List<Vehicle>> GetVehiclesAsync();
    Task<Vehicle> GetVehicleByIdAsync(int id);
    void AddVehicleAsync(Vehicle Vehicle);
    void UpdateVehicleAsync(Vehicle Vehicle);
    void DeleteVehicleAsync(int id);
}
