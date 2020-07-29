namespace Domain.Models
{
    using Enums;
    using System;

    public class Delivery
    {
        public Guid DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Deliverer Deliverer { get; set; }
        public Guid DelivererId { get; set; }
    }
}
