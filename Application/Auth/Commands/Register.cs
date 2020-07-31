namespace Application.Auth.Commands
{
    using Domain.Auth;
    using FluentValidation;
    using Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Validators;

    public class Register
    {
        public class Command : IRequest<User>
        {
            public string DisplayName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Guid RoleId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.RoleId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.Where(x => x.Email == request.Email)
                    .AnyAsync(cancellationToken))
                {
                    // throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exits" });
                }

                if (await _context.Users.Where(x => x.UserName == request.Username)
                    .AnyAsync(cancellationToken))
                {
                    // throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exits" });
                }

                var user = new AppUser
                {
                    Email = request.Email,
                    UserName = request.Username,
                    RoleId = request.RoleId
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new User
                    {
                        Token = _jwtGenerator.CreateToken(user),
                        Username = user.UserName,
                        Role = _context.Roles.Find(user.RoleId).RoleName
                    };
                };
                throw new Exception("Problem creating user");
            }
        }
    }
}
