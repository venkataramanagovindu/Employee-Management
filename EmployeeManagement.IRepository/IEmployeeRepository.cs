using System;
using System.Collections.Generic;
using System.Text;

using EmployeeManagement.Models.DTO;

namespace EmployeeManagement.IRepository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public void Add(Employee employee);
        public void UpdateEmployee(Employee employee);
        public List<Employee> DeleteEmployee(int id);
    }
}
