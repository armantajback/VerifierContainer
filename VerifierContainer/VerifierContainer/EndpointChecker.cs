using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace VerifierContainer
{
    public static class EndpointChecker
    {
        public static async Task<string> GetEndpoint(string host, int port, TimeSpan timeout = default, int retries = 0)
        {
            if(timeout == default)
            {
                timeout = TimeSpan.FromSeconds(5);
            }

            int attempts = 0;
            while (true)
            {
                Socket s = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                try
                {
                    var connectTask = Task.Factory.FromAsync(s.BeginConnect(host, port, null, null), s.EndConnect);
                    var timeoutTask = Task.Delay(timeout);

                    await Task.WhenAny(connectTask, timeoutTask);

                    if (s.Connected)
                    {
                        return $"Connected to {host}:{port}";
                    }
                    else
                    {
                        attempts++;
                        if (attempts > retries)
                        {
                            return $"Failed to connect to {host}:{port}. Timed out after {timeout.TotalMilliseconds} milliseconds.";
                        }
                        continue;
                    }
                }
                catch (Exception e)
                {
                    return $"Failed to connect to {host}:{port}. Exception: {e}";
                }
                finally
                {
                    s.Close();
                }
            }
        }
    }
}
