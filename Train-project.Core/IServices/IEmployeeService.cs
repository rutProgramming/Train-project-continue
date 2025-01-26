using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeEntity> GetAllEmployees();
        EmployeeEntity? GetEmployeeById(int id);
        EmployeeEntity AddEmployee(EmployeeEntity employee);
        EmployeeEntity UpdateEmployee(int id, EmployeeEntity employee);
        bool DeleteEmployee(int id);
        bool ValidData(EmployeeEntity employee);
    }
}
