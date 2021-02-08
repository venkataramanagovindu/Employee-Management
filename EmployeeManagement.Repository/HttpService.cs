using EmployeeManagement.IRepository;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EmployeeManagement.Models.DTO;
using EmployeeManagement.Models.Common;

namespace EmployeeManagement.Repository
{
    public class HttpService: IHTTP
    {
        private HttpClient client;
        private IHttpClientFactory _factory;
        private readonly IConfiguration _configuration;

        public HttpService(IHttpClientFactory factory, IConfiguration configuration)
        {
            client = factory.CreateClient(Constants.SENDGRID_API);
            //_factory = factory;
            _configuration = configuration;
        }

        //static HTTPService([FromServices]IHttpClientFactory factory)
        //{
        //    client = new HttpClient();
        //}
        public async Task<HTTPResponse> Get(string requestUri, string json = "", string userEmail = "")
        {
            //client = _factory.CreateClient(requestTo);
            //string AccessToken = await _token.GetToken(userEmail);
            string URL = requestUri;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

            //var input = new StringContent(json, Encoding.Default, "application/json");
            HttpResponseMessage
                response = client.GetAsync(URL)
                    .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string Result;
            if (response.IsSuccessStatusCode)
            {
                Result = await response.Content.ReadAsStringAsync();
                HTTPResponse HttpResponse = new HTTPResponse()
                {
                    statusCode = (int)response.StatusCode,
                    data = Result
                };
                return HttpResponse;
            }
            else
            {
                Result = await response.Content.ReadAsStringAsync();
                HTTPResponse HttpResponse = new HTTPResponse()
                {
                    statusCode = (int)response.StatusCode,
                    data = Result
                };
                return HttpResponse;
            }
        }
        public async Task<HTTPResponse> Post(string requestTo = "", string requestUri = "", string json = "", string userEmail = "")
        {
            //client = _factory.CreateClient(requestTo);
            //string AccessToken = await _token.GetToken(userEmail);
            string URL = requestUri;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

            var input = new StringContent(json, Encoding.Default, "application/json");
            HttpResponseMessage
                response = client.PostAsync(URL, input)
                    .Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string Result;
            if (response.IsSuccessStatusCode)
            {
                Result = await response.Content.ReadAsStringAsync();
                HTTPResponse HttpResponse = new HTTPResponse()
                {
                    statusCode = (int)response.StatusCode,
                    data = Result
                };
                return HttpResponse;
            }
            else
            {
                Result = await response.Content.ReadAsStringAsync();
                HTTPResponse HttpResponse = new HTTPResponse()
                {
                    statusCode = (int)response.StatusCode,
                    data = Result
                };
                return HttpResponse;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();
            //return Result;
        }
        public string Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
