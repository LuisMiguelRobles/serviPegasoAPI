using System.Collections.Generic;

namespace Domain.Models
{
    using System;

    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
        public string ProductDescription { get; set; }
        public Category ProductCategory { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
