using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Deliverer.Commands
{
    public class UpdateIsAvailable
    {
        public class Command : IRequest {
            public string Email { get; set; }
            public bool IsAvailable { get; set; }
        }

        public class CommandValidator: AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.IsAvailable).NotEmpty();
            }   
        }

        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var succes = await _context.Database.ExecuteSqlRawAsync("UpdateDelivererStatus @p0, @p1", request.Email, request.IsAvailable) ==1;
                if(succes)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}
