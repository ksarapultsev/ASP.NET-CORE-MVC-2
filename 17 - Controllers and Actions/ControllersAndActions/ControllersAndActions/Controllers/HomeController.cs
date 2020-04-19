using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;
namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index() => Json(new[] { "Alice", "Bob", "Joe" });
        
    }


}
