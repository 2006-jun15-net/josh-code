using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

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
