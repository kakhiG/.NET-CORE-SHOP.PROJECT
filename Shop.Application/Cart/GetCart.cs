using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Domain.Infrastructure;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Domain.Infrastracture;

namespace Shop.Application.Cart
{
    public class GetCart
    {
        private ISessionManager _sessionManager;
        
        public GetCart(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
          
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int Qty { get; set; }
            public decimal RealValue { get; set; }

            public int StockId { get; set; }
        }

        public IEnumerable <Response> Do()
        {
            return _sessionManager
                .GetCart(x => new Response
                {
                    Name = x.ProductName,
                    Value = x.Value.GetValueString(),
                    RealValue = x.Value,
                    StockId = x.StockId,
                    Qty = x.Qty

                });
          

        }
    }

}


