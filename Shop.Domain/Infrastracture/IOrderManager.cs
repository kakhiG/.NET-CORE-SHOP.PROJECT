using Shop.Domain.Enums;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Infrastracture
{
    public interface IOrderManager
    {
        bool OrderReferenceExists(string reference);



        IEnumerable<TResult> GetOrdersByStatus<TResult>(OrderStatus status, Func<Order, TResult> selector);
        TResult GetOrderById<TResult>(int Id, Func<Order, TResult> selector);

        TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector);

        Task<int> CreatOrder(Order order);
        Task <int>AdvanceOrder(int id);
    }
}



