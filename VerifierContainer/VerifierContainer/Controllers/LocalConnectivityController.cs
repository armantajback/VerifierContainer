
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Http;

    [Route("LocalConnectivity")]
    public class LocalConnectivityController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string localUri = "http://localhost:{0}";

        [HttpGet("31002")]
        public ActionResult<string> Get_31002()
        {
            return GetLocalEndpoint(31002);
        }

        [HttpGet("19080")]
        public ActionResult<string> Get_19080()
        {
            return GetLocalEndpoint(19080);
        }

        private string GetLocalEndpoint(int port)
        {
            try
            {
                var Uri = string.Format(localUri, port.ToString());
                var response = client.GetAsync(Uri).Result;
                response.EnsureSuccessStatusCode();

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                return responseString;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
