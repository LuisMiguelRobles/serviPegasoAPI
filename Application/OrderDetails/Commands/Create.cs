namespace Application.OrderDetails.Commands
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
            public int OrderDetailProductAmount { get; set; }
            public double OrderDetailSubTotal { get; set; }
            public Guid ProductId { get; set; }
            public Guid OrderId { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OrderDetailProductAmount).NotEmpty();
                RuleFor(x => x.OrderDetailSubTotal).NotEmpty();
                RuleFor(x => x.ProductId).NotEmpty();
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
