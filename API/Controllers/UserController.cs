namespace API.Controllers
{
    using System.Threading.Tasks;
    using Application.Auth;
    using Application.Auth.Commands;
    using Application.Auth.Queries;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        /// <summary>
        /// Login user
        /// </summary>

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Get Current user
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<User>> CurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

    }
}
