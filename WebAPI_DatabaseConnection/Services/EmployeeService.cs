using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI_DatabaseConnection.IServices;
using WebAPI_DatabaseConnection.Models;

namespace WebAPI_DatabaseConnection.Services
{
    public class EmployeeService : IEmployeeService
    {
        WebAPICoreContext _dbContext;

        public EmployeeService(WebAPICoreContext db)
        {
            _dbContext = db;
        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employee;
            }

            return null;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            //_dbContext.Remove(employee); // another option
            _dbContext.Entry(employee).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            //_dbContext.Update(employee); // another option
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return employee;
        }
    }
}
