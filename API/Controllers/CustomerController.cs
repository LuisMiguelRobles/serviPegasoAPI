namespace API.Controllers
{
    using Application.Customer.Commands;
    using Application.Customer.Queries;
    using Domain.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomerController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> List()
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
