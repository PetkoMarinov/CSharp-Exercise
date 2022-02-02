using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System.Linq;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener; //TCPListener allows us to accept requests from the browser

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, routingTable)
        {
        }

        public async Task Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine("Listening for requests...");

            while (true) //To make our server accept many requests, add a while(true) loop to create and close a connection every time
            {
                var connection = await serverListener.AcceptTcpClientAsync(); //make our server wait for the browser to connect to it

                _ = Task.Run(async () =>
                {
                    //to return a response from our server to the browser to visualize. To do this, first we need to
                    //create a stream, through which data is received or sent to the browser as a byte array
                    var networkStream = connection.GetStream();

                    var requestText = await this.ReadRequest(networkStream);

                    Console.WriteLine(requestText);

                    var request = Request.Parse(requestText);

                    var response = this.routingTable.MatchRequest(request);

                    AddSession(request, response);

                    await WriteResponse(networkStream, response); //special method for writing the response in the network stream

                    connection.Close();
                });
            }
        }

        //provides us with the HTTP request from the browser as a string
        private async Task<string> ReadRequest(NetworkStream networkStream) //First, our method should accept a network stream to read from. 
        {
            var bufferLength = 1024; //Our buffer for reading will have a length of 1024 bytes and will be a byte array
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder(); //will append the request strings and will be returned as a string to the method

            //Next, create a do-while loop, which will read bytes from the network stream, parse them into a string
            //and append the string to the StringBuilder. The loop should be active until there is no more data from the stream

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024) //to check the length of the request and stop the reading if it is too large
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable); // May not run correctly over the Internet

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var resposeBytes = Encoding.UTF8.GetBytes(response.ToString());

            if (response.FileContent != null)
            {
                resposeBytes = resposeBytes
                    .Concat(response.FileContent)
                    .ToArray();
            }

            await networkStream.WriteAsync(resposeBytes);
        }

        private static void AddSession(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }
    }
}
