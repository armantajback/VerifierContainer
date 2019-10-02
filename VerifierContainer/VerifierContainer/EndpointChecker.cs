using System;
using System.Net.Sockets;

namespace VerifierContainer
{
    public static class EndpointChecker
    {
        public static string GetEndpoint(string host, int port, TimeSpan timeout, int retries)
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
                    IAsyncResult result = s.BeginConnect(host, port, null, null);
                    result.AsyncWaitHandle.WaitOne(timeout, true);

                    if (s.Connected)
                    {
                        return "Connected";
                    }
                    else
                    {
                        attempts++;
                        if (attempts > retries)
                        {
                            return "Failed";
                        }
                        continue;
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
}
