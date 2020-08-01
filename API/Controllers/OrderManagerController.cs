namespace API.Controllers
{
    using Application.OrderManager.Commands;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class OrderManagerController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Mediator.Send(command);
        }
    }
}
