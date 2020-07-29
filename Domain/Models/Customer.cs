using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber{ get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public virtual ICollection<Order> CustomerOrders { get; set; }
    }

}
