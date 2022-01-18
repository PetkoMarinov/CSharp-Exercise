using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    internal class RedirectResponse : Response
    {
        //location - the URL of the page, which the server should redirect to
        public RedirectResponse(string location) : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
