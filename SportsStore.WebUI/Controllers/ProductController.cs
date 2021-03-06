﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

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

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(p => p.Category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                pagingInfo = new PagingInfo()
                {
                    CurrentItem = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}