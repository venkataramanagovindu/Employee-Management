using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models.DTO
{
    public class HTTPResponse
    {
        public int statusCode { get; set; }
        public dynamic data { get; set; }
    }
}
