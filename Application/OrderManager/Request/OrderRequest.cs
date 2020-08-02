namespace Application.OrderManager.Request
{
    using System;
    using Domain.Models;
    using System.Collections.Generic;

    public class OrderRequest
    {
        public string CustomerEmail { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public OrderRequest()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
