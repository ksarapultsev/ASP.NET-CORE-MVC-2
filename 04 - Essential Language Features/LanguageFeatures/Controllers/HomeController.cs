using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index() { 
            var products = new[]
            {
                new {Name = "Kayak", Price =275M},
                new {Name = "Lifejacket", Price =48.95M},
                new {Name = "Soccer Ball", Price =19.50M},
                new {Name = "Corner flag", Price =34.95M}

            };
            return View(products.Select(p =>
            $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));

            //return View(products.Select(p => $"Name: {p.Name}, Price: {p.Price}"));

        //bool FilterByPrice(Product p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}
        //public async Task<ViewResult> Index()
        //{
        //    long? length = await MyAsyncMethods.GetPageLength();
        //    return View(new string[] { $"Length: {length}" });

            //return View(Product.GetProducts().Select(p => p?.Name));

            //Func<Product, bool> nameFilter = delegate (Product prod)
            //{
            //    return prod?.Name?[0] == 'S';
            //};

            //decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
            //decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();

            //return View("Index", new string[] {
            //    $"Price Total: {priceFilterTotal:C2}",
            //    $"Name Total: {nameFilterTotal:C2}" });


            //decimal priceFilterTotal = productArray.FilterByPrices(20).TotalPrices();
            //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            //return View("Index", new string[] {
            //    $"Price Total: {priceFilterTotal:C2}",
            //    $"Name Total: {nameFilterTotal:C2}" });


            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.FilterByPrices(20).TotalPrices();


            //return View("Index", new string[] { $"Cart Total: {cartTotal:C2}", $"Array Total: {arrayTotal:C2}" });

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //decimal cartTotal = cart.TotalPrices();
            //return View("Index", new string[] { $"Total: {cartTotal:C2}" });

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    switch (data[i])
            //    {
            //        case decimal decimalValue: total += decimalValue;
            //            break;
            //        case int intVal when intVal > 50: total += intVal;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //return View("Index", new string[] { $"Total : {total:C2}" });

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] is decimal d )
            //    {
            //        total += d;
            //    }
            //}
            //return View("Index", new string[] { $"Total : {total:C2}" });


            /*
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                {"Kayak", new Product{Name = "Kayak", Price = 275M} },
                {"Lifejacket", new Product{Name = "Lifejacket", Price = 48.95M} }
            };
            return View("Index", products.Keys);
            */

            /*
            string[] names = new string[3];
            names[0] = "Bob";
            names[1] = "Joe";
            names[2] = "Alice";
            return View("Index", names);
            */

            /*
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name} Price: {price}, Related: {relatedName}");
            }
            return View(results);
            */
        }
    }
}
