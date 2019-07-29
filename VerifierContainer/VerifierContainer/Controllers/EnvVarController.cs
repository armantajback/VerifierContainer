
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("[EnvironmentVariable]")]
    [ApiController]
    public class EnvVarController : Controller
    {
        [HttpGet("ResourceName")]
        public ActionResult<string> Get()
        {
            return Environment.GetEnvironmentVariable("ResourceName");
        }
    }
}
