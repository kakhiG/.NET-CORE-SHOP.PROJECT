using System.Threading.Tasks;
using Shop.Domain.Models;

namespace Shop.Application.Cart
{
    public interface IStockManager
    {
        Stock GetStockWithProduct(int stockId);
        bool EnoughStock(int stockId, int qty);
        Task PutStockOnHold(int stockId, int qty, string sessionId);
        Task RemoveStockFromHold(int stockId, int qty, string sessionId);

    }
}