using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Payment.Request;
using Domain.Models;
using Domain.Models.Enums;
using MediatR;
using Persistence;

namespace Application.Payment.Commands
{
    public class Create
    {
        public class Command: IRequest
        {
            //public DateTime PaymentDate { get; set; }
            //public PaymentStatus PaymentStatus { get; set; }
            //public Guid OrderId { get; set; }
            public string Token { get; set; }
            public float Amount { get; set; }
            public string PayerEmail { get; set; }
            public string PaymentMethodId { get; set; }
            public string Description { get; set; }
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
                // var success = _context.Payments.Add()
                await _payment.AddPayment(GetPaymentRequest(request));
                return Unit.Value;
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
