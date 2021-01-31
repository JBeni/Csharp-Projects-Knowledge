using System.Collections.Generic;
using WebAPI_DatabaseConnection.Models;

namespace WebAPI_DatabaseConnection.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}
