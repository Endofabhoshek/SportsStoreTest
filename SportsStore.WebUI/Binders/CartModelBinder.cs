using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string sessionKey = "cart";
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            return cart;
        }
    }
}