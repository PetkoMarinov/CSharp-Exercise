using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers.Add(Header.Server, "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:r}"); //Coordinated Universal Time
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public Action<Request,Response> PrerenderAction { get; protected set; }

        public override string ToString()
        {
            //the HTTP response should be converted to a byte array. To make that possible,
            //it should first be converted to a string in a valid HTTP response message format.
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} { this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                result.AppendLine(this.Body);
            }

            return result.ToString();
        }
    }
}
