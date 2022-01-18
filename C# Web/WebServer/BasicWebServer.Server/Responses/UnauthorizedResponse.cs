using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    internal class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() : base(StatusCode.Unauthorized)
        {
        }
    }
}
