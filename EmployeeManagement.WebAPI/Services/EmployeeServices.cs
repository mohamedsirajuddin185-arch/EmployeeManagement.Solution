
using Dapper;
using EmployeeManagement.WebAPI.Models;
using EmployeeManagement.WebAPI.ServiceContracts;
using EmployeeManagement.WebAPI.SqlFactory;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeManagement.WebAPI.Services;
//Bussiness Logic Or Backend Logic 
public class EmployeeServices : IEmployeeServices
{
    private readonly SqlConnectionFactory _sqlConnection;

    public EmployeeServices(SqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnection = sqlConnectionFactory;
    }

    //public async Task<List<Employee>> GetAllEmployee()//Return Type
    //{
    //    var connection = _sqlConnection.CreateConnection();
      

    //   var employees = await connection.QueryAsync<Employee>(
    //        "GetAllEmployees",
    //        commandType: CommandType.StoredProcedure
    //    );

    //    return employees.ToList();
    //}

    public async Task<List<Employee>> GetAllEmployee()
    {
        var connection = _sqlConnection.CreateConnection();
        var employee = await connection.QueryAsync<Employee>(
            "GetAllEmployees",
            commandType: CommandType.StoredProcedure
            );
        return employee.ToList();
    }

    //public async Task<Employee?> GetEmployeeById(Guid id)
    //{
    //    var connection = _sqlConnection.CreateConnection();

    //    return await connection.QueryFirstOrDefaultAsync<Employee>(
    //        "GetEmployeeByID",
    //        new
    //        {
    //            EmployeeId = id
    //        },
    //        commandType: CommandType.StoredProcedure
    //    );
    //}

    public async Task<Employee?> GetEmployeeById(Guid id)
    {
        var connection = _sqlConnection.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Employee>(
            "GetEmployeeById",
            new
            {
                EmployeeId = id,
            },
            commandType: CommandType.StoredProcedure
            );
    }

    public async Task<Employee> CreatEmployee(Employee employee)
    {
        employee.EmployeeId = Guid.NewGuid();
        var connection = _sqlConnection.CreateConnection();

        await connection.ExecuteAsync(
            "CreateEmployee",
            new
            {
                employee.EmployeeId,
                employee.Name,
                employee.Email,
                employee.Age,
                employee.Role,
                employee.Salary
            },
            commandType: CommandType.StoredProcedure
        );

        return employee;
    }

    //public async Task<Employee> UpdateEmployee(Employee employee,Guid id)
    //{
    //    employee.EmployeeId = id;
    //    var connection = _sqlConnection.CreateConnection();
    //    await connection.ExecuteAsync(
    //        "UpdateEmployee",
    //        new
    //        {
    //            employee.EmployeeId,
    //            employee.Name,
    //            employee.Email,
    //            employee.Age,
    //            employee.Role,
    //            employee.Salary
                
    //        },
    //        commandType: CommandType.StoredProcedure
    //    );
    //    return employee;

    //}

    public async Task<Employee> UpdateEmployee(Employee employee,Guid id)
    {
        employee.EmployeeId = id;
        var connection = _sqlConnection.CreateConnection();
        await connection.ExecuteAsync(
            "UpdateEmployee",
            new
            {
                employee.EmployeeId,
                employee.Name,
                employee.Email,
                employee.Age,
                employee.Role,
                employee.Salary
            },
            commandType: CommandType.StoredProcedure
            );
        return employee;
    }

    //public async Task<bool> DeleteEmployee(Guid? id)
    //{
    //   var connection = _sqlConnection.CreateConnection();
    //    await connection.ExecuteAsync(
    //        "DeleteEmployee",


    //    new
    //    {
    //        EmployeeId = id
    //    },
    //    commandType:CommandType.StoredProcedure
    //    );
    //    if (id == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
    public async Task<bool> DeleteEmployee(Guid? id)
    {
        var connection = _sqlConnection.CreateConnection();
        await connection.ExecuteAsync(
            "DeleteEmployee",


        new
        {
            EmployeeId = id
        },
        commandType: CommandType.StoredProcedure
        );
        if (id == null)
        {
            return false;
        }
        return true;
    }
}
