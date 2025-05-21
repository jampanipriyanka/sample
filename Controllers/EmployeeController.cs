using sample.Models;
using sample.Services;
using Microsoft.AspNetCore.Mvc;

namespace sample.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {

    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Employee>> GetAll() =>
           EmployeeService.GetAll();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = EmployeeService.Get(id);

        if (employee == null)
            return NotFound();

        return employee;
    }
    // POST action
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        EmployeeService.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        if (id != employee.Id)
            return BadRequest();

        var existingEmployee = EmployeeService.Get(id);
        if (existingEmployee is null)
            return NotFound();

        EmployeeService.Update(employee);
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = EmployeeService.Get(id);
    
        if (employee is null)
            return NotFound();
        
        EmployeeService.Delete(id);
    
        return NoContent();
    }
}