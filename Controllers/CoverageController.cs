using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using InsurancePoliciesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CoverageController : ControllerBase
{
    private readonly ICoverageService _coverageService;

    public CoverageController(ICoverageService coverageService)
    {
        _coverageService = coverageService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var coverages = await _coverageService.GetCoveragesAsync();
        if (coverages == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
        }

        return StatusCode(StatusCodes.Status200OK, coverages);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var coverage = _coverageService.GetCoverageByIdAsync(id);
        if (coverage == null)
        {
            return NotFound();
        }
        return Ok(coverage);
    }

    [HttpPost]
    public IActionResult Post(Coverage coverage)
    {
        _coverageService.AddCoverageAsync(coverage);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Coverage coverage)
    {
        if (id != coverage.ID)
        {
            return BadRequest();
        }
        _coverageService.UpdateCoverageAsync(coverage);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _coverageService.DeleteCoverageAsync(id);
        return Ok();
    }
}