
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.NetworkInformation;

    [Route("Egress")]
    public class EgressController : Controller
    {
        [HttpGet("Verify")]
        public ActionResult<string> Get()
        {

            using (Ping pinger = new Ping())
                try
                {
                    var reply = pinger.Send("8.8.8.8", 5000);

                    if (reply.Status == IPStatus.Success)
                    {
                        return "Connected";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
                catch (Exception e)
                {
                    return $"Exception while trying to connect. Exception: {e}";
                }
        }
    }
}
