using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using InsurancePoliciesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;

    public PolicyController(IPolicyService policyService)
    {
        _policyService = policyService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Policys = await _policyService.GetPoliciesAsync();
        if (Policys == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
        }

        return StatusCode(StatusCodes.Status200OK, Policys);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var Policy = _policyService.GetPolicyByIdAsync(id);
        if (Policy == null)
        {
            return NotFound();
        }
        return Ok(Policy);
    }

    [HttpGet("getByNumber/{number}")]
    public IActionResult GetByNumber(string number)
    {
        var Policy = _policyService.GetPolicyByNumber(number);
        if (Policy == null)
        {
            return NotFound();
        }
        return Ok(Policy);
    }

    [HttpGet("getByNumberPlate/{number}")]
    public async Task<IActionResult> GetByVehicleNumberPlate(string number)
    {
        var Policy = await _policyService.GetPolicyByNumberPlateAsync(number);
        if (Policy == null)
        {
            return NotFound();
        }
        return Ok(Policy);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Policy policy)
    {
        var result = await _policyService.AddPolicyAsync(policy);
        return Ok(result);
    }
    [HttpPost("assignPolicyVehicle")]
    public async Task<IActionResult> AssignPolicyVehicle(PolicyVehicle policyVehicle)
    {
        var result = await _policyService.AssignPolicyVehicleAsync(policyVehicle);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Policy Policy)
    {
        if (id != Policy.ID)
        {
            return BadRequest();
        }
        _policyService.UpdatePolicyAsync(Policy);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _policyService.DeletePolicyAsync(id);
        return Ok();
    }
}