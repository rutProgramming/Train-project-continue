using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRepositoryManager _repositoryManager;
        public EmployeeService(IEmployeeRepository employeeEntity, IRepositoryManager repositoryManager)
        {
            _employeeRepository = employeeEntity;
            _repositoryManager = repositoryManager;

        }

        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
        public EmployeeEntity? GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }
        public EmployeeEntity AddEmployee(EmployeeEntity employee)
        {
            EmployeeEntity employeeCheck = _employeeRepository.GetById(employee.Id);
            if (employeeCheck == null && ValidData(employee))
            {
                _employeeRepository.AddEntity(employee);
                _repositoryManager.save();
                return employee;
            }
            return null;
        }
        public EmployeeEntity UpdateEmployee(int id, EmployeeEntity employee)
        {
            EmployeeEntity employeeCheck = _employeeRepository.GetById(id);
            if (employeeCheck != null && ValidData(employee))
            {
                employee= _employeeRepository.UpdateEmployee(id, employee);
                _repositoryManager.save();
            }
            return null;
        }
        public bool DeleteEmployee(int id)
        {
            EmployeeEntity employeeCheck = _employeeRepository.GetById(id);
            if (employeeCheck != null)
            {
                 _employeeRepository.DeleteEntity(id);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
        public bool ValidData(EmployeeEntity employee)
        {
            return employee.Id<=0?true:Valid.IsIdValid(employee.Id.ToString()) && employee.Id<=0?true: Valid.IsIsraeliPhoneNumberValid(employee.Id.ToString());
        }

       
    }
}
