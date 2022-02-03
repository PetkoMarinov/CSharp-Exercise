using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        // it sets an additional header for the location (the URL of the page, which the server should redirect to).
        public RedirectResponse(string location)
             : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location); 
        }
    }
}
