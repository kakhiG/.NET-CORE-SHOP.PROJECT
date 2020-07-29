using System.Linq;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.Infrastracture;

namespace Shop.Application.OrdersAdmin
{
    public class UpdateOrder
    {
        
        private readonly IOrderManager _orderManager;

        public UpdateOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public Task <int>DoAsync(int id)
        {
            return _orderManager.AdvanceOrder(id);
        }
    }
}