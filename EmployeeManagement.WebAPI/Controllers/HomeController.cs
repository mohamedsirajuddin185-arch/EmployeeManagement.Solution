using EmployeeManagement.WebAPI.Models;
using EmployeeManagement.WebAPI.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers;

//Controller Works 
//Recieve Request => Call Service methods => response

[ApiController]
[Route("api/employees")]
public class HomeController : ControllerBase
{
    private readonly IEmployeeServices _employeeServices;

    public HomeController(IEmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeServices.GetAllEmployee();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await _employeeServices.GetEmployeeById(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        employee.EmployeeId = Guid.NewGuid();

        var createdEmployee =
            await _employeeServices.CreatEmployee(employee);

        return Ok(createdEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        Guid id,
        Employee employee)
    {
        employee.EmployeeId = id;

        var updatedEmployee =
            await _employeeServices.UpdateEmployee(employee,id);

        if (updatedEmployee == null)
            return NotFound();

        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var deleted = await _employeeServices.DeleteEmployee(id);

        if (!deleted)
            return NotFound();

        return Ok("Employee deleted successfully");
    }
}