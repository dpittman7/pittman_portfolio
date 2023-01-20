using Microsoft.AspNetCore.Mvc;
using pittman_mvc.Models;
using Newtonsoft.Json;

namespace pittman_mvc.Controllers
{
    [ApiController]
    [Route("/api/project")]
    public class ProjectController : ControllerBase
    {
        

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            //Reads text from about.json
            string jsonText = System.IO.File.ReadAllText("./Data/projects.json");
            //Deserializes into About object
            return JsonConvert.DeserializeObject<IEnumerable<Project>>(jsonText);
        }
    }
}