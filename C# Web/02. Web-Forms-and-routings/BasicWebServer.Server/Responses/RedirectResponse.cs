using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string Location) 
            : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location,Location);
        }
    }
}
