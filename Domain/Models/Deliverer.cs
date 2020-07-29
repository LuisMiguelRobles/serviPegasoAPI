namespace Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class Deliverer
    {
        public Guid DelivererId { get; set; }
        public string DelivererFullName { get; set; }
        public string DelivererEmail { get; set; }
        public string DelivererPhoneNumber { get; set; }
        public DateTime DelivererBirthDate { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        
    }
}
