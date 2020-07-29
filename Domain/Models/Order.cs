namespace Domain.Models
{

    using Enums;

    using System;

    using System.Collections.Generic;

    public class Order
    {
        public Guid OrderId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }
    }
}
