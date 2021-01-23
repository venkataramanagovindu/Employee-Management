﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models.DTO
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Experience { get; set; }
    }
}
