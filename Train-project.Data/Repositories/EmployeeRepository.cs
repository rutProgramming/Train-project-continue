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
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context) { }

       
        public EmployeeEntity UpdateEmployee(int id, EmployeeEntity updatedEmployee)
        {
            EmployeeEntity existingEmployee = GetById(id);
            existingEmployee.Tz = updatedEmployee.Tz;
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Address = updatedEmployee.Address;
            existingEmployee.Type = updatedEmployee.Type;
            existingEmployee.Phone = updatedEmployee.Phone;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.EmployedFrom = updatedEmployee.EmployedFrom;
            return existingEmployee;
        }

        
    }
}

