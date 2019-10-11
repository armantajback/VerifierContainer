
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    [Route("LocalConnectivity")]
    public class LocalConnectivityController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("{port:int}")]
        public async Task<ActionResult<string>> Get(int port)
        {
            var hostIp = Environment.GetEnvironmentVariable("Fabric_NodeIPOrFQDN") ?? "localhost";
            return await EndpointChecker.GetEndpoint(hostIp, port);
        }
    }
}
