namespace API.Controllers
{
    using Application.Product.Commands;
    using Domain.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Product.Quieries;

    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromForm]Create.Command command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Mediator.Send(command);
        }
    }
}
