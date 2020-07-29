namespace Domain.Models
{
    using System;
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public int OrderDetailProductAmount { get; set; }
        public double OrderDetailSubTotal { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
