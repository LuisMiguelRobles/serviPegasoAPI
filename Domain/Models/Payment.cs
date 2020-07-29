using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enums;

namespace Domain.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public double PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
