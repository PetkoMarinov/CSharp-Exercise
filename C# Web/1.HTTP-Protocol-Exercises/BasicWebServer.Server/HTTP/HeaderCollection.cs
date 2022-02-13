namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection() 
            => this.headers = new Dictionary<string, Header>();

        public int Count => this.headers.Count;

        public bool Contains(string name) 
            => this.headers.ContainsKey(name);

        public void Add(string name, string value)
        {
            //this.headers.Add(name, new Header(name, value));
            this.headers[name] = new Header(name, value);
        }
    }
}
