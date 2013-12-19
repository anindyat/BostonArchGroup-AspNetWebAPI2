using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1HttpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8085";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine(String.Format("Started listening {0}...",uri));
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Logging 
            app.Use((ctx, next) =>
            {
                foreach (var item in ctx.Request.Headers)
                {
                    Console.WriteLine(String.Format("Http Header= {0} and Value = {1}", item.Key, item.Value[0]));
                }
                return next.Invoke();
            });
            // Authentication
            app.Use((ctx, next) => { 
                if (ctx.Request.Headers.Keys.Contains("Authorization"))
                {
                    var credential = ctx.Request.Headers["Authorization"];
                    return next.Invoke();
                }
                ctx.Response.StatusCode = 401;
                return ctx.Response.WriteAsync("Unauthorized Access");
            });
            // Actual resource
            app.Use((ctx,next) =>
            {
                return ctx.Response.WriteAsync("Here is my secret resource");
            });
        }
    }
}
