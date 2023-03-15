using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using InsurancePoliciesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PolicyTestRequirementsController : ControllerBase
{
    private readonly IPolicyService _policyService;

    public PolicyTestRequirementsController(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpGet("getByNumber/{number}")]
    public IActionResult GetByNumber(string number)
    {
        try
        {
            var Policy = _policyService.GetPolicyByNumber(number);
            if (Policy == null)
            {
                return NotFound();
            }
            return Ok(Policy);
        }
        catch
        {
            return BadRequest();
        }
    }


    [HttpGet("getByNumberPlate/{number}")]
    public async Task<IActionResult> GetByVehicleNumberPlate(string number)
    {
        try
        {
            var Policy = await _policyService.GetPolicyByNumberPlateAsync(number);
            if (Policy == null)
            {
                return NotFound();
            }
            return Ok(Policy);
        }
        catch
        {
            return BadRequest();
        }
    }


    [HttpPost("addPolicy")]
    public async Task<IActionResult> AddPolicy(Policy policy)
    {
        try
        {
            var result = await _policyService.AddPolicyAsync(policy);
            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("assignPolicyVehicle")]
    public async Task<IActionResult> AssignPolicyVehicle(PolicyVehicle policyVehicle)
    {
        try
        {

            var result = await _policyService.AssignPolicyVehicleAsync(policyVehicle);
            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }
}