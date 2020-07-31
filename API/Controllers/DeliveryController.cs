namespace API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Delivery.Commands;
    using Application.Delivery.Queries;
    using Domain.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class DeliveryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Delivery>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Mediator.Send(command);
        }
    }
}
