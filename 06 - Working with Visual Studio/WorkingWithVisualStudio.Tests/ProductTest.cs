using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTest 
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Организация
            var p = new Product { Name = "Test", Price = 100M };

            // Действие
            p.Name = "New Name";

            // Утверждение
            Assert.Equal("New Name", p.Name);
        }
        [Fact]
        public void CanChangeProductPrice()
        {
            // Организация
            var p = new Product { Name = "Test", Price = 100M };

            // Действие
            p.Price = 200M;

            // Утверждение
            Assert.Equal(200M, p.Price);
        }
    }
}
