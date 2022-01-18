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

        public HttpServer(string iPAddress, int port)
        {
            this.iPAddress = IPAddress.Parse(iPAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.iPAddress, port);
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

                //method for writing the response in the network stream
                WriteResponse(networkStream, "Hello from the server.");

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string message)
        {
            var contentLength = Encoding.UTF8.GetByteCount(message);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=utf-8
Content-Length: {contentLength}

{message}";
            //converts the response to a byte array
            var responseBytes = Encoding.UTF8.GetBytes(response);

            //Use the network stream to send the response bytes to the browser
            networkStream.Write(responseBytes);
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