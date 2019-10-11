
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("Egress")]
    public class EgressController : Controller
    {
        [HttpGet("Verify")]
        public async Task<ActionResult<string>> Get()
        {
            return await EndpointChecker.GetEndpoint("www.bing.com", 80);
        }
    }
}
