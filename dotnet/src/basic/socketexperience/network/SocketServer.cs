using System.Net;
using System.Net.Sockets;

namespace MyApp.Network  
{

    internal class SocketServer
    {
        static IPEndPoint ipEndPoint = new(IPAddress.Loopback, 11_000);
        static Thread _serverThread;
        static List<Thread> _clientThread = new List<Thread>();
        static bool _needExit = false;
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main(string[] args)
        {
            cts.Token.ThrowIfCancellationRequested();
            _serverThread = new Thread(ServerPro);
            _serverThread.Start(cts.Token);

            for (int i = 0; i < 10; i++)
            {
                Thread newThread = new Thread(ClientPro);
                newThread.Start(i);
                _clientThread.Add(newThread);
            }
            Console.ReadKey();
            _needExit = true;
            cts.Cancel();



            Console.WriteLine(nameof(SocketServer) + " exit!");

            cts.Dispose();

        }

        static void ServerPro(object? obj)
        {
            CancellationToken token = (CancellationToken)obj;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(ipEndPoint);
                socket.Listen(1000);
                ValueTask<Socket> task;
                while (_needExit == false)
                {
                    Socket _handle;
                    task = socket.AcceptAsync(token);
                    while (_needExit == false && task.IsCompletedSuccessfully == false)
                    {
                        Thread.SpinWait(100);
                    }
                    _handle = task.Result;

                    Console.WriteLine("server:connected from:" + _handle.RemoteEndPoint?.ToString());



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
            }
        }



        static void ClientPro(object? port)
        {
            Socket socket = null;
            try
            {
                Thread.Sleep(1000 * ((int)(port ?? 1)));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipEndPoint);
                while (_needExit == false)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (socket != null && socket.IsBound)
                {
                    socket.Close();
                }
            }


        }
    }
}
