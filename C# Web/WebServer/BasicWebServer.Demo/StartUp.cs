﻿using BasicWebServer.Server;
using BasicWebServer.Server.Responses;

public class StartUp
{
    private const string HtmlForm = @"<form action='HTML' method='POST'>
        Name: <input type='text' name='Name'/>
        Age: <input type='number' name = 'Age'/>
        <input type='submit value ='Save' />
    </form>";
    public static void Main()
        => new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
            .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
            .MapPost("/HTML", new TextResponse("")))
        .Start();

///*    var server = new Htt*/pServer("127.0.0.1", 8080);
//    server.Start();
}

