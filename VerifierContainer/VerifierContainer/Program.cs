
namespace VerifierContainer
{
    using Microsoft.AspNetCore.Hosting;
    using System.Threading;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;

    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(s => s.AddMvc())
                .Configure(a => a.UseMvc())
                .UseUrls("http://+:12345")
                .Build();
            builder.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
