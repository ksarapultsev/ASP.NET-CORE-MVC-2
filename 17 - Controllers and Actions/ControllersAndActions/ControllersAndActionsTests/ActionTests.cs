using System;
using System.Collections.Generic;
using System.Text;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActionsTests
{
    public class ActionTests
    {
        //[Fact]
        //public void ViewSelected()
        //{
        //    //Организация
        //    HomeController controller = new HomeController();

        //    // Действие
        //    ViewResult result = controller.ReceiveForm("Adam", "London");

        //    // Утверждение
        //    Assert.Equal("Result", result.ViewName);
        //}

        //[Fact]
        //public void ModelObjectType()
        //{
        //    //Организация
        //    ExampleController controller = new ExampleController();

        //    // Действие
        //    ViewResult result = controller.Index();

        //    // Утверждение
        //    Assert.IsType<string>(result.ViewData["Message"]);
        //    Assert.Equal("Hello", result.ViewData["Message"]);
        //    Assert.IsType<System.DateTime>(result.ViewData["Date"]);

        //}

        //[Fact]
        //public void Redirection()
        //{
        //    //Организация
        //    ExampleController controller = new ExampleController();

        //    // Действие
        //    RedirectToActionResult result = controller.Redirect();

        //    // Утверждение
        //    Assert.False(result.Permanent);           
        //    Assert.Equal("Index", result.ActionName);
        //}

        [Fact]
        public void NotFoundActionMethod()
        {
            //Организация
            ExampleController controller = new ExampleController();

            // Действие
            StatusCodeResult result = controller.Index();

            // Утверждение            
            Assert.Equal(404, result.StatusCode);
        }
    }
}
