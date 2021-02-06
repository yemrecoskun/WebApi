using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.MiddleWare
{
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        public HeaderCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            using (var swapStream = new MemoryStream())
            {
                var request = httpContext.Request;
                var requestValue = ("REQUEST :", DateTime.Now.ToLongTimeString(), request.Method, request.Host, request.Path);


                var originalResponseBody = httpContext.Response.Body;
                httpContext.Response.Body = swapStream;
                await _next(httpContext);
                swapStream.Seek(0, SeekOrigin.Begin);
                string responseBody = new StreamReader(swapStream).ReadToEnd();
                swapStream.Seek(0, SeekOrigin.Begin);

                await swapStream.CopyToAsync(originalResponseBody);
                httpContext.Response.Body = originalResponseBody;


                var response = httpContext.Response;
                var responseValue = ("RESPONSE : ", DateTime.Now.ToLongTimeString(), response.ContentType, response.StatusCode, (HttpStatusCode)response.StatusCode);
                var TxtValue = requestValue + "\n" + responseBody + "\n" + responseValue + "\n";
                string FileName = "log.txt";
                StreamWriter FileWrite = File.AppendText(FileName);
                FileWrite.WriteLine(TxtValue);
                FileWrite.Close();

            }
        }
    }
}