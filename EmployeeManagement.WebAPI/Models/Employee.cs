namespace EmployeeManagement.WebAPI.Models;

public class Employee
{
    //Domain Model or Entity models
    public Guid EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int Age  { get; set; }
    public string? Role { get; set; }
    public double Salary  { get; set; } 

}
