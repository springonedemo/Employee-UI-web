using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pivotal.Discovery.Client;

namespace EmployeeUIWeb.Controllers
{
    public class HomeController : Controller
    {
        DiscoveryHttpClientHandler _handler;
        ILogger<HomeController> _logger;
        private const string EMPLOYEE_SERVICE_URL = "http://localhost:52419/api/values/";

        public HomeController(IDiscoveryClient client, ILoggerFactory logFactory)
        {
            _handler = new DiscoveryHttpClientHandler(client, logFactory.CreateLogger<DiscoveryHttpClientHandler>());
            // Remove comment to use SSL communications with Self-Signed Certs
            // _handler.ServerCertificateCustomValidationCallback = (a,b,c,d) => {return true;};
            _logger = logFactory.CreateLogger<HomeController>();

        }

        private HttpClient GetClient()
        {
            var client = new HttpClient(_handler, false);
            return client;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult SearchEmployee()
        {
            return View("~/Views/Values/Employee.cshtml");
        }


        public async Task<IActionResult> MicroServiceDemo(int id)
        {
            //return View(genres);
            var response = "";

            //string[] arr;
            Dictionary<string, string> _Data = new Dictionary<string, string>();
            using (var client = GetClient())
            {

                //await client.GetStringAsync("https://employee.cglean.com/api/values/" + id.ToString());
                response = await client.GetStringAsync(EMPLOYEE_SERVICE_URL + id.ToString());
                _logger.LogInformation("Get Employee Details: {0}", response);
                _Data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(response.ToString());
            }
            return View("~/Views/Values/Employeedetails.cshtml", _Data);
        }

    }
}
