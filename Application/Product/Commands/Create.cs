using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Product.Commands
{
    public class Create
    {
        public class Command : IRequest
        {
            
        }


        public class CommandValidator: AbstractValidator<Command>
        {
            public CommandValidator()
            {
                
            }
        }


        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
