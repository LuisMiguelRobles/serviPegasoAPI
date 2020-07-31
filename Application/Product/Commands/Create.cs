namespace Application.Product.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Persistence;

    public class Create
    {
        public class Command : IRequest
        {
            public string ProductName { get; set; }
            public double ProductPrice { get; set; }
            public string ProductDescription { get; set; }
            public Guid CategoryId { get; set; }
        }


        public class CommandValidator: AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductName).NotEmpty();
                RuleFor(x => x.ProductPrice).NotEmpty();
                RuleFor(x => x.ProductDescription).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
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
