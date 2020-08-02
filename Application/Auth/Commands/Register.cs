namespace Application.Auth.Commands
{
    using Application.Errors;
    using Domain.Auth;
    using FluentValidation;
    using Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Validators;

    public class Register
    {
        public class Command : IRequest<User>
        {
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime BirthDay { get; set; }
            public string RoleType { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                
                RuleFor(x => x.FullName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.PhoneNumber).NotEmpty();
                RuleFor(x => x.BirthDay).NotEmpty();
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
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exits" });
                }


                var role = _context.Roles.SingleOrDefault(x => x.RoleName.Equals(request.RoleType));
                
                var user = new AppUser
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    UserFullName = request.FullName,
                    RoleId = role.RoleId,
                    UserStatus = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    this.RegisterUser(request, _context);


                    return new User
                    {
                        Token = _jwtGenerator.CreateToken(user),
                        UserFullName = user.UserFullName,
                        Role = role.RoleName,
                        Email = user.Email

                    };
                };
                
                throw new Exception("Problem creating user");
            }

            private void RegisterUser(Command request, DataContext context)
            {

                var sqlParamsUser = new object[] { Guid.NewGuid(), request.FullName, request.Email, request.PhoneNumber, request.BirthDay };

                switch (request.RoleType)
                {
                    case nameof(RoleType.client):
                        context.Database.ExecuteSqlRaw("CreateCustomer @p0,@p1, @p2, @p3, @p4", sqlParamsUser);
                        break;
                    case nameof(RoleType.deliverer):
                        context.Database.ExecuteSqlRaw("CreateDeliverer @p0,@p1, @p2, @p3, @p4", sqlParamsUser);
                        break;
                }
            }

        }

        
    }
}
