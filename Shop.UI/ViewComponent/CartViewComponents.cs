using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.ViewComponents
{
    public class CartViewComponents:ViewComponent
    {
        private ApplicationDbContext _ctx;

        public CartViewComponents(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke(string view="Default")
        {
            if(view =="small" )
            {
                var totalValue = new GetCart(HttpContext.Session, _ctx).Do().Sum(x => x.RealValue * x.Qty);
                return View(view, $"£{totalValue}");
            }
            return View(view, new GetCart(HttpContext.Session,_ctx).Do());
        }
    }
}

