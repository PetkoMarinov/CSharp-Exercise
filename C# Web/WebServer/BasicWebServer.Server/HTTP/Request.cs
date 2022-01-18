namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        //To parse the request string to an HTTP request we need to first separate each line
        //and get the first one, which contains our method and URL, split by a space:

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            //The start line is an array with the method and the URL as strings
            var startLine = lines.First().Split(" ");

            var method = ParseMethod(startLine[0]);
            var url = startLine[1];

            var headers = ParseHeaders(lines.Skip(1));
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join("\r\n", bodyLines);

            return new Request 
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();
            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(':',2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();
                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
