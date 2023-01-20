using Microsoft.AspNetCore.Mvc;
using pittman_mvc.Models;
using Newtonsoft.Json;

namespace pittman_mvc.Controllers
{
    [ApiController]
    [Route("/api/about")]
    public class AboutController : ControllerBase
    {
        

        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<About> Get()
        {
            //Reads text from about.json
            string jsonText = System.IO.File.ReadAllText("./Data/abouts.json");
            //Deserializes into About object
            return JsonConvert.DeserializeObject<IEnumerable<About>>(jsonText);
        }
    }
}