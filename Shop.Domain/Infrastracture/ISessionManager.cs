using System;
using System.Collections.Generic;
using Shop.Domain.Models;

namespace Shop.Domain.Infrastructure
{
    public interface ISessionManager
    {
        string GetId();
        void AddProduct(CartProduct cartProduct);
        void RemoveProduct(int stockId, int qty);
        IEnumerable<TResult>GetCart<TResult>(Func<CartProduct,TResult>selector);
        void CleanCart();

        void AddCustomerInformation(CustomerInformation customer);
        CustomerInformation GetCustomerInformation();
    }
}
