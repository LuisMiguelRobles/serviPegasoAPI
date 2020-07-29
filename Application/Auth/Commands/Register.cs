using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Auth;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Auth.Commands
{
    public class Register
    {


        public class Command : IRequest<User>
        {
            public string UserFullName { get; set; }
            public bool UserStatus { get; set; }
            public DateTime UserBirthDay { get; set; }
            public Guid RoleId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserFullName).NotEmpty();
                RuleFor(x => x.UserStatus).NotEmpty();
                RuleFor(x => x.UserBirthDay).NotEmpty();

            }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
