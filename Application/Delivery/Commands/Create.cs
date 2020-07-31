namespace Application.Delivery.Commands
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
            public Guid OrderId { get; set; }
            public Guid DelivererId { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DelivererId).NotEmpty();
                RuleFor(x => x.OrderId).NotEmpty();
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
