using Shop.Database;
using Shop.Domain.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.ProductsAdmin 
{
    public class GetProducts
    {
        
        private IProductManager _productManager;

        public GetProducts(IProductManager productManager)
        {
            _productManager =productManager;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _productManager.GetProducts(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value

            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
    }
    
}

