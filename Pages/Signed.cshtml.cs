using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using queuefront.Model;

namespace queuefront.Pages
{
    public class SignedModel : PageModel
    {
        private readonly ILogger<SignedModel> _logger;
        private readonly IConfiguration _configuration;
        private string APIEndpoint;
        public SignedModel(ILogger<SignedModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void OnGet([FromQuery(Name = "shopcode")] string shopcode)
        {
            APIEndpoint = _configuration.GetValue<string>("UrlEndPoint:SignedApi");

            Console.WriteLine("SignedApi" + APIEndpoint);

            //EnvironmentModel config = JsonConvert.DeserializeObject<EnvironmentModel>(Environment.GetEnvironmentVariable("APP_SETTING"));

            ViewData["BaseAPI"] = APIEndpoint;
            ViewData["Shopcode"] = shopcode;
        }
    }
}
