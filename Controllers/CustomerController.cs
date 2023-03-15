using InsurancePoliciesAPI.Models;
using InsurancePoliciesAPI.Data;
using InsurancePoliciesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetCustomersAsync();
        if (customers == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
        }

        return StatusCode(StatusCodes.Status200OK, customers);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var customer = _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Post(Customer customer)
    {
        _customerService.AddCustomerAsync(customer);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Customer customer)
    {
        if (id != customer.ID)
        {
            return BadRequest();
        }
        _customerService.UpdateCustomerAsync(customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _customerService.DeleteCustomerAsync(id);
        return Ok();
    }
}