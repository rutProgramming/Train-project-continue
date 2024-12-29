using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class EmployeeRepository :Repository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context)
        {
        }
       
        public EmployeeEntity UpdateEmployee(int id, EmployeeEntity updatedEmployee)
        {

            EmployeeEntity existingEmployee = GetById(id);

            if (!string.IsNullOrEmpty(updatedEmployee.EmployeeId))
                existingEmployee.EmployeeId = updatedEmployee.EmployeeId;

            if (!string.IsNullOrEmpty(updatedEmployee.EmployeeName))
                existingEmployee.EmployeeName = updatedEmployee.EmployeeName;

            if (!string.IsNullOrEmpty(updatedEmployee.EmployeeAddress))
                existingEmployee.EmployeeAddress = updatedEmployee.EmployeeAddress;

            if (updatedEmployee != default)
                existingEmployee.EmployeeType = updatedEmployee.EmployeeType;

            if (!string.IsNullOrEmpty(updatedEmployee?.EmployeePhone))
                existingEmployee.EmployeePhone = updatedEmployee.EmployeePhone;

            if (updatedEmployee?.Salary >= 0)
                existingEmployee.Salary = updatedEmployee.Salary;

            if (updatedEmployee.EmployedFrom != default)
                existingEmployee.EmployedFrom = updatedEmployee.EmployedFrom;
            return existingEmployee;
        }
   
    }
}

