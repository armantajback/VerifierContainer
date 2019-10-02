
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Http;
    using Newtonsoft;
    using Newtonsoft.Json;
    using System.Net.Sockets;

    [Route("LocalConnectivity")]
    public class LocalConnectivityController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("{port:int}")]
        public ActionResult<string> Get(int port)
        {
            var hostIp = Environment.GetEnvironmentVariable("Fabric_NodeIPOrFQDN") ?? "localhost";
            return EndpointChecker.GetEndpoint(hostIp, port, TimeSpan.FromSeconds(1), 10);
        }
    }
}
