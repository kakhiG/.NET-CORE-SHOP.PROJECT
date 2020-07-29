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
        private GetCart _getCart;

        public CartViewComponents(GetCart getCart)
        {
            _getCart = getCart;
        }

        public IViewComponentResult Invoke(string view="Default")
        {
            if(view =="small" )
            {
                var totalValue = _getCart.Do().Sum(x => x.RealValue * x.Qty);
                return View(view, $"£{totalValue}");
            }
            return View(view, _getCart.Do());
        }
    }
}

