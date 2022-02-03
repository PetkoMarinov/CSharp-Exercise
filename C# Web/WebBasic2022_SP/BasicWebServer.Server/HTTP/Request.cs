﻿using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        //The HTTP request consists of an HTTP request line (with an HTTP method, a URL and HTTP version), headers and a body. 
        private static Dictionary<string, Session> Sessions = new();

        public Method Method { get; private set; } //Put, Get, Post, Delete

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public string Body { get; private set; }

        public Session Session { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request) //accepts a request as a string and parses it to a Request
        {
            //To parse the request string to an HTTP request we need to first separate each line and get the first one, which contains
            //our method and URL, split by a space
            var lines = request.Split("\r\n");

            var startLine = lines.First().Split(" "); //The start line is an array with the method and the URL as strings

            var method = ParseMethod(startLine[0]); //we need to parse the given method string to an HTTP method
            var url = startLine[1];

            var headers = ParseHeaders(lines.Skip(1)); //Take the headers, starting from the second request line. They also need parsing

            var cookies = ParseCookies(headers);

            var session = GetSession(cookies);

            //Then, we need to get the lines of the body part of the request. Skip the start line and the header lines,
            //get the body lines and join them to form the body part:
            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join("\r\n", bodyLines);

            var form = ParseForm(headers, body);

            return new Request //Finally, return the parsed HTTP request with all its components to finish the Parse(string request) method
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Body = body,
                Session = session,
                Form = form
            };
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

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

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

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookieHeader = headers[Header.Cookie];

                var allCookies = cookieHeader.Split(';');

                foreach (var cookieText in allCookies)
                {
                    var cookieParts = cookieText.Split('=');

                    var cookieName = cookieParts[0].Trim();
                    var cookieValue = cookieParts[1].Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }
            }

            return cookieCollection;
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }

            return Sessions[sessionId];
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType)
                && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
           => HttpUtility.UrlDecode(bodyLines)
               .Split('&')
               .Select(part => part.Split('='))
               .Where(part => part.Length == 2)
               .ToDictionary(
                   part => part[0],
                   part => part[1],
                   StringComparer.InvariantCultureIgnoreCase);
    }
}