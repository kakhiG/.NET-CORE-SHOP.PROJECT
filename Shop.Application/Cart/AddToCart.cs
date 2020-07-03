using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shop.Application.Infrastructure;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Cart
{
    public class AddToCart
    {
        private readonly ISessionManager _sessionManager;
        private readonly ApplicationDbContext _ctx;

        public AddToCart(ISessionManager sessionManager, ApplicationDbContext ctx)
        {
            _sessionManager = sessionManager;
            _ctx = ctx;
        }


        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }
        public async Task<bool> Do(Request request)
        {
            var stockOnHold = _ctx.StocksOnHold.Where(x => x.SessionId == _sessionManager.GetId()).ToList();
            var stockToHold = _ctx.Stock.Where(x => x.Id == request.StockId).FirstOrDefault();



            if (stockToHold.Qty < request.Qty)
            {
                //return not enough stock
                return false;

            }

            if (stockOnHold.Any(x => x.StockId == request.StockId))
            {
                stockOnHold.Find(x => x.StockId == request.StockId).Qty += request.Qty;
            }
            else
            {
                _ctx.StocksOnHold.Add(new StockOnHold
                {
                    StockId = stockToHold.Id,
                    SessionId = _sessionManager.GetId(),
                    Qty = stockToHold.Qty,
                    ExpiryDate = DateTime.Now.AddMinutes(20)
                });
            }


            stockToHold.Qty = stockToHold.Qty - request.Qty;

            foreach (var stock in stockOnHold)
            {
                stock.ExpiryDate = DateTime.Now.AddMinutes(20);
            }
            await _ctx.SaveChangesAsync();

            _sessionManager.AddProduct(request.StockId, request.Qty);
            // var cartList = new List<CartProduct>();
            //  var stringObject = _session.GetString("cart");
            //  if (!string.IsNullOrEmpty(stringObject))
            //  {
            //      cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);
            //  }
            //
            //  if (cartList.Any(x => x.StockId == request.StockId))
            //  {
            //      cartList.Find(x => x.StockId == request.StockId).Qty += request.Qty;
            //  }
            //  else
            //  {
            //      cartList.Add(new CartProduct
            //      {
            //          StockId = request.StockId,
            //          Qty = request.Qty
            //      });
            //  }
            //  
            //      stringObject = JsonConvert.SerializeObject(cartList);
            //      
            //      _session.SetString("cart", stringObject);
            return true;
        }
    }
}