namespace Application.Order.Commands
{
    using FluentValidation;
    using MediatR;
    using Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Create
    {
        public class Command : IRequest
        {
            public double OrderTotal { get; set; }
            public Guid CustomerId { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OrderTotal).NotEmpty();
                RuleFor(x => x.CustomerId).NotEmpty();
            }
        }


        public class Handler : IRequestHandler<Command>
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
