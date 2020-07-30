using Shop.Database;
using Shop.Domain.Infrastracture;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    [Service]
    public class DeleteProduct
    {
        
        private IProductManager _productManager;

        public DeleteProduct(IProductManager productManager )
        {
            _productManager = productManager;
        }

        public  Task<int> Do(int id)
        {
            return _productManager.DeleteProduct(id);
        }

        
    }
    

}
