namespace Application.Deliverer.Commands
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
            public string DelivererFullName { get; set; }
            public string DelivererEmail { get; set; }
            public string DelivererPhoneNumber { get; set; }
            public DateTime DelivererBirthDate { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DelivererFullName).NotEmpty();
                RuleFor(x => x.DelivererEmail).NotEmpty();
                RuleFor(x => x.DelivererPhoneNumber).NotEmpty();
                RuleFor(x => x.DelivererBirthDate).NotEmpty();
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
