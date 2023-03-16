﻿using System.Net;
using System.Reflection;
using TicTacToeAPI.Endpoints;

namespace TicTacToeAPI
{
    public class ReadMeEndpoint : IEndpoint
    {
        public bool IsSuitable(string? path)
        {
            return path == "/";
        }

        public async Task Execute(HttpListenerContext ctx)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string? assemblyName = assembly.GetName().Name;
            using Stream? stream = assembly.GetManifestResourceStream($"{assemblyName}.README.md");
            if (stream == null)
            {
                ctx.Response.StatusCode = (int)HttpStatusCode.NotFound;
                ctx.Response.Close();
                return;
            }
            await stream.CopyToAsync(ctx.Response.OutputStream);
            ctx.Response.ContentType = "text/markdown";
            ctx.Response.StatusCode = (int)HttpStatusCode.OK;
            ctx.Response.Close();
        }
    }

    public class ApiListener
    {
        private readonly HttpListener _listener;
        private readonly IEndpoint[] _endpoints;

        public ApiListener(string url, GameController gameController)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
            _endpoints = new IEndpoint[]
            {
                new GamesEndpoint(gameController),
                new ShowGameEndpoint(gameController),
                new CreateGameEndpoint(gameController),
                new ResetGameEndpoint(gameController),
                new RemoveGameEndpoint(gameController),
                new MoveEndpoint(gameController),
                new ReadMeEndpoint()
            };
        }

        public async Task Loop()
        {
            _listener.Start();
            IEnumerable<string> urls = _listener.Prefixes.Select(p => p.ToString());
            Console.WriteLine("Started at: " + string.Join(", ", urls));
            while (_listener.IsListening)
            {
                try
                {
                    HttpListenerContext ctx = await _listener.GetContextAsync();
                    Console.WriteLine("Request: " + ctx.Request.RawUrl);
                    await ProcessRequest(ctx);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private async Task ProcessRequest(HttpListenerContext ctx)
        {
            foreach (IEndpoint endpoint in _endpoints)
            {
                if (endpoint.IsSuitable(ctx.Request.RawUrl))
                {
                    await endpoint.Execute(ctx);
                    return;
                }
            }
            ctx.Response.StatusCode = (int)HttpStatusCode.NotFound;
            ctx.Response.Close();
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}