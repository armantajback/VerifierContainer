
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
            return GetLocalEndpoint(port);
        }

        private string GetLocalEndpoint(int port)
        {
            var hostIp = Environment.GetEnvironmentVariable("Fabric_NodeIPOrFQDN");

            Socket s = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            try
            {
                IAsyncResult result = s.BeginConnect(hostIp, port, null, null);
                result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), true);

                if (s.Connected)
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
            finally
            {
                s.Close();
            }
        }
    }
}
