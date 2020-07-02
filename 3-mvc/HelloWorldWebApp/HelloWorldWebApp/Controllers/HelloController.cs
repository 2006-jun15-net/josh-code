using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp.Controllers
{
    public class HelloController : Controller
    {
        //this class can contain action methods and non-action methods...
        public IActionResult Hello1()
        {
            //var result = new ContentResult
            //{
            //    StatusCode = 200, //default anyway
            //    ContentType = "text/html",
            //    Content = "<html><head></head><body>Hello controller</body></html>"
            //};
            //return result;

            // View is a helper method fromt he parent class to find a view
            var result = View("Hello", "this string is the model");

            //by default, the name of the view is guessed to be the name of the action method
            return result;
        }
        //when the action method is called,
        //asp.net attempts to fill in the parameters from a variety of sources:
        //  - query string (at the end of the URL)
        //  - route parameters (in the path of the URL, and defined in the route)
        //  - request body
        public IActionResult Hello2(string who)
        {
            var result = new ContentResult
            {
                StatusCode = 200, //default anyway
                ContentType = "text/html",
                Content = $"<html><head></head><body>Hello {who}</body></html>"
            };
            return result;
        }

        // with MVC, action methods should return either a ViewResult (for an HTML page)
        // or some kind of redirct result

        [NonAction]// by default any instance method in this class might get called to handle a request
        public void HelperMethod()
        {

        }
    }
}
