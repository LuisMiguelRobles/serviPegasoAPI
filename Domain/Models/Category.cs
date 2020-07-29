namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
