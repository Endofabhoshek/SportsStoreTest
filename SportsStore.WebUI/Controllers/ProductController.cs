using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 3;

        public ProductController(IProductRepository productrepo)
        {
            this.repository = productrepo;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Products.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}