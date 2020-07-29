using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Cart
{
    
    
        public class StockManager : IStockManager
        {
            private ApplicationDbContext _ctx;


            public StockManager(ApplicationDbContext ctx)
            {
                _ctx = ctx;
            }

            public bool EnoughStock(int stockId, int qty)
            {
                return _ctx.Stock.FirstOrDefault(x => x.Id == stockId).Qty >= qty;
            }

            public Stock GetStockWithProduct(int stockId)
            {
                return _ctx.Stock
                .Include(x => x.Product)
                .FirstOrDefault(x => x.Id == stockId);

            }

            public Task PutStockOnHold(int stockId, int qty, string sessionId)
            {
                //begin transaction

                //update Stock set qty =qty +{0} where  Id =(1)
                _ctx.Stock.FirstOrDefault(x => x.Id == stockId).Qty -= qty;

                var stockOnHold = _ctx.StocksOnHold
                    .Where(x => x.SessionId == sessionId)
                    .ToList();
                //select count(*) from StockOnHold where StockId ={0} and sessionId ={1}
                if (stockOnHold.Any(x => x.StockId == stockId))
                {
                    //update StockOnHold set qty = qty + {0}
                    //where StockId ={1} and sessionId ={2}
                    stockOnHold.Find(x => x.StockId == stockId).Qty += qty;
                }
                else
                {
                    //insert into StockOnHold(StockId,SessionId,Qty,ExpiryDate)
                    //values ({0},{1},{2},{3})
                    _ctx.StocksOnHold.Add(new StockOnHold
                    {
                        StockId = stockId,
                        SessionId = sessionId,
                        Qty = qty,
                        ExpiryDate = DateTime.Now.AddMinutes(20)
                    });
                }
                //update StockOnHold set ExpiryDate ={0}where sessionId = {1}
                foreach (var stock in stockOnHold)
                {
                    stock.ExpiryDate = DateTime.Now.AddMinutes(20);
                }


                //commit transaction
                return _ctx.SaveChangesAsync();

            }

            public Task RemoveStockFromHold(int stockId, int qty, string sessionId)
            {

                var stockOnHold = _ctx.StocksOnHold
                    .FirstOrDefault(x => x.StockId == stockId
                                         && x.SessionId == sessionId);

                var stock = _ctx.Stock.FirstOrDefault(x => x.Id == stockId);
                stock.Qty += qty;
                stockOnHold.Qty -= qty;

                if (stockOnHold.Qty <= 0)
                {
                    _ctx.Remove(stockOnHold);
                }

                return _ctx.SaveChangesAsync();

            }
        }
    
}