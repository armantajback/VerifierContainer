using System;
using System.Net.Sockets;

namespace VerifierContainer
{
    public static class EndpointChecker
    {
        public static string GetEndpoint(string host, int port, int retries = 0)
        {
            int attempts = 0;
            while (true)
            {
                Socket s = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                try
                {
                    s.Connect(host, port);

                    if (s.Connected)
                    {
                        return "Connected";
                    }
                    else
                    {
                        attempts++;
                        if (attempts > retries)
                        {
                            return $"Failed to connect.";
                        }
                        continue;
                    }
                }
                catch (Exception e)
                {
                    return $"Failed to connect. Exception: {e}";
                }
                finally
                {
                    s.Close();
                }
            }
        }
    }
}
