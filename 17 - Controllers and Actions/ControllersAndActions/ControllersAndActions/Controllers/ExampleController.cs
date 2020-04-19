using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        //public ContentResult Index() 
        //   => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");
        // public ObjectResult Index() => Ok(new string[] { "Alice", "Bob", "Joe" });
        // public VirtualFileResult Index()
        //    => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
        public StatusCodeResult Index()
           => NotFound();
    }
        
       
}
