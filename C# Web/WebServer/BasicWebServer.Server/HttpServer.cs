using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress iPAddress;

        private readonly int port;
        
        //we use the TCPListener class, which allows us to accept requests from the browser
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string iPAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.iPAddress = IPAddress.Parse(iPAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.iPAddress, port);
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

        public void Start()
        {
            //makes connection to the browser
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                //make our server wait for the browser to connect to it
                var connection = serverListener.AcceptTcpClient();

                //we need to return a response from our server to the browser to visualize.
                //To do this, first we need to create a stream, through which data is received or sent to the browser as a byte array:
                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = Request.Parse(requestText);

                var response = this.routingTable.MatchRequest(request);

                if (response.PreRenderAction != null)
                {
                    response.PreRenderAction(request, response);
                }

                //method for writing the response in the network stream
                WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            //var contentLength = Encoding.UTF8.GetByteCount(message);

            //converts the response to a byte array
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            //Use the network stream to send the response bytes to the browser
            networkStream.Write(responseBytes);

            //            var response = $@"HTTP/1.1 200 OK
            //Content-Type: text/plain; charset=utf-8
            //Content-Length: {contentLength}

            //{message}";
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable); // May run not correctly over the internet

            return requestBuilder.ToString();
        }
    }
}