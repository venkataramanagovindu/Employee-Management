using EmployeeManagement.Models.DTO;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.IRepository
{
    public interface IHTTP
    {
        Task<HTTPResponse> Get(string requestUri = "", string json = "", string userEmail = "");
        Task<HTTPResponse> Post(string requestTo = "", string requestUri = "", string data = "", string userEmail = "");
    }
}
