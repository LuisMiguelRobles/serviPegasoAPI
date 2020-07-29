﻿namespace Application.Auth.Queries
{
    using Application.Interfaces;
    using Domain.Auth;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly UserManager<AppUser> _userManager;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
            {
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    // throw new RestException(HttpStatusCode.Unauthorized);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    return new User
                    {
                        Id = user.Id,
                        Token = _jwtGenerator.CreateToken(user),
                        Username = user.UserName,
                        Role = user.UserRole.RoleName
                        
                    };
                }

                // throw new RestException(HttpStatusCode.Unauthorized);
                throw new Exception();
            }
        }

    }
}
