namespace Application.Payment.Commands
{
    using Application.Interfaces;
    using Application.Payment.Request;
    using FluentValidation;
    using MediatR;
    using Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class Create
    {
        public class Command: IRequest
        {
  
            public Guid OrderId { get; set; }
            public string Token { get; set; }
            public float Amount { get; set; }
            public string PayerEmail { get; set; }
            public string PaymentMethodId { get; set; }
            public string Description { get; set; }
        }

        public class CommandValidator: AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OrderId).NotEmpty();
                RuleFor(x => x.Token).NotEmpty();
                RuleFor(x => x.Amount).NotEmpty();
                RuleFor(x => x.PayerEmail).NotEmpty();
                RuleFor(x => x.PaymentMethodId).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IPayment _payment;

            public Handler(DataContext context, IPayment payment)
            {
                _context = context;
                _payment = payment;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                
                var paymentStatus = _payment.AddPayment(GetPaymentRequest(request)).Result;
                var sqlParams = new object[] {Guid.NewGuid(),request.Amount, DateTime.Now,PaymentStatus.Pending, request.OrderId};
                var success = await _context.Database.ExecuteSqlRawAsync("RegisterPayment @p0, @p1, @p2, @p3, @p4", sqlParams) == 1;

                if (paymentStatus.Equals("approved"))
                {
                    _context.Database.ExecuteSqlRaw("UpdateOrderStatus @p0, @p1", request.OrderId, OrderStatus.Paid);
                }

                if(success)
                    return Unit.Value;

                throw new Exception("Problem saving changes");
            }


            private PaymentRequest GetPaymentRequest(Command request)
            {
                return new PaymentRequest
                {
                    Amount = (float) request.Amount,
                    PayerEmail = request.PayerEmail,
                    PaymentMethodId = request.PaymentMethodId,
                    Token = request.Token,
                    Description = request.Description
                };
            }
        }
    }
}
