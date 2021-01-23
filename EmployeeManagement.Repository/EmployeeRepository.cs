using System;
using System.Collections.Generic;
using System.Text;

using EmployeeManagement.IRepository;
using EmployeeManagement.Models.DTO;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        List<Employee> Employees = new List<Employee>() {
            new Employee(){ Id = 1, FirstName = "Venkataramana", LastName = "Govindu", Age = 20, Experience = 2.5 },
            new Employee(){ Id = 2,  FirstName = "Eshwar", LastName = "Kytham", Age = 20, Experience = 2.5 }
        } ;

        public List<Employee> GetEmployees()
        {
            return Employees;
        }

        public Employee GetEmployee(int id)
        {
            return Employees.Find( emp => emp.Id == id );
        }

        public void Add(Employee employee)
        {
            Employees.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            int index = Employees.FindIndex(emp => emp.Id == employee.Id);
            if (index > 0)
            {
                Employees[index] = employee;
            }
            return Employees[index];
        }

        public List<Employee> DeleteEmployee(int id)
        {
            int index = Employees.FindIndex(emp => emp.Id == id);
            if (index >= 0)
            {
                Employees.RemoveAt(index);
            }
            return Employees;
        }
    }
}
