using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto? GetEmployeeById(int id);
        EmployeeDto AddEmployee(EmployeeDto employee);
        EmployeeDto UpdateEmployee(int id, EmployeeDto employee);
        bool DeleteEmployee(int id);
        bool ValidData(EmployeeDto employee);
    }
}
