using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;

        public CartController(IProductRepository repo)
        {
            productRepository = repo;
        }

        public RedirectToRouteResult AddToCart(Cart cart,int productId, string returnUrl)
        {
            Product product = productRepository.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = productRepository.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLines(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel() { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult CheckOut()
        {
            return View(new ShippingDetails());
        }
    }
}