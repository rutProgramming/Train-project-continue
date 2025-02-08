using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeEntity, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _employeeRepository = employeeEntity;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            IEnumerable<EmployeeEntity> employees= _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
        public EmployeeDto? GetEmployeeById(int id)
        {
            var empoyee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDto>(empoyee);
        }
        public EmployeeDto AddEmployee(EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetById(employeeDto.Id);
            if (employee== null && ValidData(employeeDto))
            {
                employee= _mapper.Map<EmployeeEntity>(employeeDto);
                _employeeRepository.AddEntity(employee);
                _repositoryManager.save();
                employeeDto.Id = employee.Id;
                return employeeDto;
            }
            return null;
        }
        public EmployeeDto UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null && ValidData(employeeDto))
            {
                employee = _mapper.Map<EmployeeEntity>(employeeDto);
                employee = _employeeRepository.UpdateEmployee(id, employee);
                _repositoryManager.save();
                employeeDto.Id = employee.Id;
                return employeeDto;
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
        public bool ValidData(EmployeeDto employee)
        {
            return employee.Id<=0?true:Valid.IsIdValid(employee.Id.ToString()) && employee.Id<=0?true: Valid.IsIsraeliPhoneNumberValid(employee.Id.ToString());
        }

       
    }
}
