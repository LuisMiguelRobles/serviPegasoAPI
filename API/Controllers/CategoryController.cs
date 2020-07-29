using System.Collections.Generic;
using Application.Category.Query;
using Domain.Models;

namespace API.Controllers
{
    using System.Threading.Tasks;
    using Application.Category.Commands;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> List()
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
