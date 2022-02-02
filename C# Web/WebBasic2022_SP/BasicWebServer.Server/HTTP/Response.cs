using System;
using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        //the response consists of a start line, headers and content (body)
        //The status line consists of an HTTP version and a status code
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; init; }

        //create a header collection class for the response headers
        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; } = new CookieCollection();

        public string Body { get; set; }

        public byte[] FileContent { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in this.Cookies)
            {
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                result.Append(this.Body);
            }

            return result.ToString();
        }
    }
}
