namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Reports.Queries;
    using Domain.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ReportController: BaseController
    {
        [HttpGet]
        public async Task<List<Order>> GetAllConfirmedOrders()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}
