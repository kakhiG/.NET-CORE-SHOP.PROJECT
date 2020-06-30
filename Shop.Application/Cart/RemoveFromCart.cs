using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Application.Infrastructure;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Cart
{
    public class RemoveFromCart
    {
        private readonly ISessionManager _sessionManager;
        private readonly ApplicationDbContext _ctx;

        public RemoveFromCart(ISessionManager sessionManager, ApplicationDbContext ctx)
        {
            _sessionManager = sessionManager;
            _ctx = ctx;
        }


        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
            public bool All { get; set; }
        }
        public async Task<bool> Do(Request request)
        {
            _sessionManager.RemoveProduct(request.StockId, request.Qty);

            var stockOnHold = _ctx.StocksOnHold
                .FirstOrDefault(x => x.StockId == request.StockId
                                     && x.SessionId == _sessionManager.GetId());

            var stock = _ctx.Stock.FirstOrDefault(x => x.Id == request.StockId);

            if (request.All)
            {
                stock.Qty += stockOnHold.Qty;
                stockOnHold.Qty = 0;
            }
            else
            {
                stock.Qty += request.Qty;
                stockOnHold.Qty -= request.Qty;
            }

            if (stockOnHold.Qty <= 0)
            {
                _ctx.Remove(stockOnHold);
            }

            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
