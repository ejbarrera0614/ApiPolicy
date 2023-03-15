using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesAPI.Services;
public class VehicleService : IVehicleService
{
    private readonly InsurancePoliciesContext _context;

    public VehicleService(InsurancePoliciesContext context)
    {
        _context = context;
    }
    public async Task<List<Vehicle>> GetVehiclesAsync()
    {
        try
        {
            return await _context.Vehicles.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int id)
    {
        return _context.Vehicles.FirstOrDefault(p => p.ID == id);
    }

    public async void AddVehicleAsync(Vehicle Vehicle)
    {
        _context.Vehicles.Add(Vehicle);
        _context.SaveChanges();
    }

    public async void UpdateVehicleAsync(Vehicle Vehicle)
    {
        _context.Vehicles.Update(Vehicle);
        _context.SaveChanges();
    }

    public async void DeleteVehicleAsync(int id)
    {
        var policy = _context.Vehicles.FirstOrDefault(p => p.ID == id);
        if (policy != null)
        {
            _context.Vehicles.Remove(policy);
            _context.SaveChanges();
        }
    }
}
