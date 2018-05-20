using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportStore.Tests
{
    [TestClass]
    public class TestPage
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void PaginationTest()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");

        }

        [TestMethod]
        public void CanGeneratePageLinks()
        {
            HtmlHelper helper = null;

            PagingInfo pagingInfo = new PagingInfo() { CurrentItem=2, ItemsPerPage=3, TotalItems=30 };

        }
    }
}
