using System;
using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    [Message("This is the Controller-Scoped Filter", Order = 10)]
    // [Profile]
    //[ViewResultDetails]
    //[RangeException]
    //[TypeFilter(typeof(DiagnosticsFilter))]
    //[ServiceFilter(typeof(TimeFilter))]

    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]


        public ViewResult Index() => View("Message",
            "This is the Index action on the Home controller");

        public ViewResult SecondAction() => View("Message",
        "This is the SecondAction action on the Home controller");

        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            } else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            } else
            {
                return View("Message", $"The value is {id}");
            }
        }


    }
}