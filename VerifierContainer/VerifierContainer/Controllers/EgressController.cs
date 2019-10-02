
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("Egress")]
    public class EgressController : Controller
    {
        [HttpGet("Verify")]
        public ActionResult<string> Get()
        {
            return EndpointChecker.GetEndpoint("www.bing.com", 80, TimeSpan.FromSeconds(1), 5);
        }
    }
}
