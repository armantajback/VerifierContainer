
namespace VerifierContainer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net.Http;

    [Route("[Egress]")]
    [ApiController]
    public class EgressController : Controller
    {
        [HttpGet("GistCheck")]
        public ActionResult<string> Get()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://gist.githubusercontent.com/armantajback/04ff56c2717585f2c27da7321e4d1622/raw/d52566e03af78c0d0665d9b00190c88added777c/EgressChecksum.txt";
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
