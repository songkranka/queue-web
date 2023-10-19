using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using queuefront.Model;
using System;
using System.Text;

namespace queuefront.Pages
{
    public class PunthaiModel : PageModel
    {
        private readonly ILogger<PunthaiModel> _logger;
        private readonly IConfiguration _configuration;
        private string APIEndpoint;
        public PunthaiModel(ILogger<PunthaiModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task OnGet()
        {

            Console.WriteLine("OnGet");

            APIEndpoint = _configuration.GetValue<string>("UrlEndPoint:PunthaiApi");

            Console.WriteLine("UrlEndPoint" + APIEndpoint);

            ViewData["BaseAPI"] = APIEndpoint;
            ViewData["Shopcode"] = "";

            //using (var client = new System.Net.Http.HttpClient())
            //{
            //    var request = new System.Net.Http.HttpRequestMessage();
            //    // webapi is the container name
            //    //request.RequestUri = new Uri(APIEndpoint);

            //    var body = new PunthaiShopCode();
            //    body.ShopCode = "N007";

            //    var json = JsonConvert.SerializeObject(body);
            //    var data = new StringContent(json, Encoding.UTF8, "application/json");

            //   // request.RequestUri = new Uri("https://uat-queue-punthai-asv.azurewebsites.net/api/GetQueue");
            //    var response = await client.PostAsync("https://localhost:44384/Queue/api/v1/GetQueue", data).ConfigureAwait(false);
            //    string counter = await response.Content.ReadAsStringAsync();

            //    var test = JsonConvert.DeserializeObject<ResponseCMPOSModel>(counter);

            //    ViewData["QueueOrder"] = test;
            //}
        }

        [HttpPost]
        public async Task OnPost()
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                // webapi is the container name
                //request.RequestUri = new Uri(APIEndpoint);

                var body = new PunthaiShopCode();
                body.ShopCode = "N007";

                var json = JsonConvert.SerializeObject(body);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                // request.RequestUri = new Uri("https://uat-queue-punthai-asv.azurewebsites.net/api/GetQueue");
                var response = await client.PostAsync("https://uat-queue-punthai-asv.azurewebsites.net/api/GetQueue", data).ConfigureAwait(false);
                string counter = await response.Content.ReadAsStringAsync();

                var test = JsonConvert.DeserializeObject<ResponseCMPOSModel>(counter);

                ViewData["QueueOrder"] = test;

            }
        }
    }
    public class PunthaiShopCode
    {

        public string ShopCode { get; set; }
    }
}
