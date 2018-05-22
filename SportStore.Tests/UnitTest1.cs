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
using SportsStore.WebUI.HtmlHelpers;

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

            PagingInfo pagingInfo = new PagingInfo() { CurrentItem = 2, ItemsPerPage = 3, TotalItems = 10 };

            MvcHtmlString result = helper.PageLinks(pagingInfo, i => "Page" + i);

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"  + @"<a class=""selected"" href=""Page2"">2</a>" + @"<a href=""Page3"">3</a>" );
        }

        [TestMethod]
        public void Can_Send_Pagination_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product() { ProductId=1, Category="Iron Man's Team", Description="Can Throw  Web(need help- gadget!)", Name="SpiderMan", Price=1 },
                new Product() { ProductId=2, Category="Captains's Team", Description="Same Age as Cap!", Name="Winter Soldier", Price=1 },
                new Product() { ProductId=3, Category="Iron Man's Team", Description="Tony made me!", Name="Rhodey", Price=1 },
                new Product() { ProductId=4, Category="Captains's Team", Description="Just got the device(stole it).", Name="Ant Man", Price=1 },
                new Product() { ProductId=5, Category="Iron Man's Team", Description="Am I in right team?", Name="Natasha", Price=1 },
                new Product() { ProductId=6, Category="Captains's Team", Description="Am I an Avenger?", Name="Falcon", Price=1 },
                new Product() { ProductId=7, Category="Am I in this Movie", Description="Stop this shit, my hammer broke!", Name="Thor", Price=1 }
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            ProductListViewModel result = (ProductListViewModel)controller.List(2).Model;

            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name , "Falcon");
            Assert.AreEqual(prodArray[1].Name , "Rhodey");
        }
    }
}