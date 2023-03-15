using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetVehiclesAsync();
        if (vehicles == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
        }

        return StatusCode(StatusCodes.Status200OK, vehicles);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var vehicle = _vehicleService.GetVehicleByIdAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpPost]
    public IActionResult Post(Vehicle vehicle)
    {
        _vehicleService.AddVehicleAsync(vehicle);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Vehicle vehicle)
    {
        if (id != vehicle.ID)
        {
            return BadRequest();
        }
        _vehicleService.UpdateVehicleAsync(vehicle);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _vehicleService.DeleteVehicleAsync(id);
        return Ok();
    }
}