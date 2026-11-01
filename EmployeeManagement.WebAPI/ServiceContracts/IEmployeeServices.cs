using EmployeeManagement.WebAPI.Models;
namespace EmployeeManagement.WebAPI.ServiceContracts;
// Bussiness Logic Interface
public interface IEmployeeServices
{
    //this method need to implemented by inherited Service
    public Task<Employee?> GetEmployeeById(Guid id);
    public Task<List<Employee>> GetAllEmployee();
    public Task<Employee> CreatEmployee(Employee employee);
    public Task<Employee> UpdateEmployee(Employee employee, Guid id);
    public Task<bool> DeleteEmployee(Guid? id);
}
