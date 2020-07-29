using Shop.Database;
using Shop.Domain.Infrastracture;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin 
{
    public class CreateProduct
    {

        private IProductManager __productManager;

        public CreateProduct(IProductManager productManager )
        {
            __productManager = productManager;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value
            };

            if(await __productManager.CreateProduct(product)>0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
            {
                Id =product.Id,
                Name=product.Name,
                Description =product.Description,
                Value =product.Value
            };
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
    

}
