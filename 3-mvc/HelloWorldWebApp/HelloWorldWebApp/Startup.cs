using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp
{

    //a controller will take responsibility for handling some subset of requests to the app
    //(usually based upon the path in the URL.)
    //e.g. if I want a user to be able to access pages like /account/myprofile, /account/browse
    // /catalog/purchase, maybe i'd have an AccountController and a CatalogController
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // teach asp.net about controllers and views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints( endpoints=>
            {
                // C# supports anonymouse types like new {prop = "a", prop2 = 1}
                // we can set up multiple routes - each one will associate a certain pattern of URL
                // that can decide what the controller and action are
                endpoints.MapControllerRoute("hello-route", "hello", new { controller = "Hello", action = "Hello1" });
                // for each request, it starts with the first routh and if that doesn't match, it tries each succeeding one in order
                //if you pull the controller or action directly from the pattern, you don't need any default
                endpoints.MapControllerRoute("default", "{controller}/{action}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //for every request, just respond with hello world html
            //app.Run(async context =>
            //{
            //    context.Response.StatusCode = 200; //success
            //    context.Response.ContentType = "text/html";
            //    await context.Response.WriteAsync("<DOCTYPE! html><html><head</head><body>Hello World</body></html> ");
            //});

            //for every request, look in the url for a relative path, and respond with the contents of that file
            app.Run(async context =>
            {
                string path = $"wwwroot{context.Request.Path}";

                //TODO: exceptionhandling
                string text = await File.ReadAllTextAsync(path);

                context.Response.StatusCode = 200; //success
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(text);
                //await context.Response.WriteAsync($"<DOCTYPE! html><html><head</head><body>Path: {context.Request.Path}</body></html> ");
            });
        }
    }
}
