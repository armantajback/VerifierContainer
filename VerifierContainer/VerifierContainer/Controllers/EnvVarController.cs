
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("EnvVar")]
    public class EnvVarController : Controller
    {
        [HttpGet("{variable}")]
        public ActionResult<string> Get(string variable)
        {
            Console.WriteLine($"{DateTime.UtcNow}: received request");
            return Environment.GetEnvironmentVariable(variable);
        }
    }
}
