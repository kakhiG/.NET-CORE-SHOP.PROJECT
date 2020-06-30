using System.Collections.Generic;
using Shop.Application.Cart;
using Shop.Domain.Models;

namespace Shop.Application.Infrastructure
{
    public interface ISessionManager
    {
        string GetId();
        void AddProduct(int stockId, int qty);
        void RemoveProduct(int stockId, int qty);
        List<CartProduct> GetCart();
        void AddCustomerInformation(CustomerInformation customer);
        CustomerInformation GetCustomerInformation();
    }
}