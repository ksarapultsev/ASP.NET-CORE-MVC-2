﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SportsStore.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            }).AsQueryable<Product>());
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);
            // Действие
            Product[] result
                = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();
            // Утверждение
            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Product()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            }).AsQueryable<Product>());
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);

            // Действие
            Product p1 = GetViewModel<Product>(target.Edit(1));
            Product p2 = GetViewModel<Product>(target.Edit(2));
            Product p3 = GetViewModel<Product>(target.Edit(3));

            // Утверждение
            Assert.Equal(1, p1.ProductID);
            Assert.Equal(2, p2.ProductID);
            Assert.Equal(3, p3.ProductID);
        }

        [Fact]
        public void Can_Edit_Nonexistent_Product()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            }).AsQueryable<Product>());
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);

            // Действие
            Product result = GetViewModel<Product>(target.Edit(4));
           
            // Утверждение
            Assert.Null(result);           
        }

        [Fact]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            // Организация - создание имитированных временных данных
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();

            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };
            // Организация - создание товара
            Product product = new Product { Name = "Test" };

            // Действие - попытка сохранить товар
            IActionResult result = target.Edit(product);
            // Утверждение - проверка того, что к хранилищу было произведено обращение
            mock.Verify(m => m.SaveProduct(product));
            // Утверждение - проверка, что типом результата является перенаправление
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);

        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);
          
            // Организация - создание товара
            Product product = new Product { Name = "Test" };
            // Организация - добавление ошибки в состояние модели
            target.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранить товар
            IActionResult result = target.Edit(product);
            // Утверждение - проверка того, что к хранилищу было произведено обращение
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            // Утверждение - проверка, что типом результата является метода
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Cannot_Delete_Valid_Products()
        {
            // Организация - создание объекта Product
            Product prod = new Product { ProductID = 2, Name = "Test" };
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
           {
                new Product {ProductID = 1, Name = "P1"},
                prod,
                new Product {ProductID = 3, Name = "P3"},
           }).AsQueryable<Product>());
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);

            // Действие - удаление товара
            target.Delete(prod.ProductID);

            // Утверждение - проверка того, что был вызван метод удаления
            // в хранилище с корректным объектом Product
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }

    }
}
