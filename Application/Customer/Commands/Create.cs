namespace Application.Customer.Commands
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
            public string CustomerFullName { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public DateTime CustomerBirthDate { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CustomerFullName).NotEmpty();
                RuleFor(x => x.CustomerEmail).NotEmpty();
                RuleFor(x => x.CustomerPhoneNumber).NotEmpty();
                RuleFor(x => x.CustomerBirthDate).NotEmpty();

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
