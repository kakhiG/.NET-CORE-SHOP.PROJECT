using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Value { get; set; }
        public int StockId { get; set; }
        public int Qty { get; set; }
    }
}


