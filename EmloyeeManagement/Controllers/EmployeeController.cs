using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeManagement.IRepository;
using EmployeeManagement.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmloyeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _employeeRepo.GetEmployees();
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public Employee GetEmployee(int id)
        {
            return _employeeRepo.GetEmployee(id);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public void AddEmployee(Employee employee)
        {
            _employeeRepo.Add(employee);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepo.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public List<Employee> DeleteEmployee(int id)
        {
            return _employeeRepo.DeleteEmployee(id);
        }
    }
}
