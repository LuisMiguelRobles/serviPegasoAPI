namespace Application.OrderManager.Commands
{
    using Domain.Models;
    using Domain.Models.Enums;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Create
    {
        public class Command : IRequest
        {
            public string CustomerEmail { get; set; }
            public float OrderTotal { get; set; }
            public List<OrderDetail> OrderDetails { get; set; }
            
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerEmail == request.CustomerEmail, cancellationToken);
                var orderId = Guid.NewGuid();
                var sqlParams = new object[] { orderId, request.OrderTotal, DateTime.Now, OrderStatus.Preparing, customer.CustomerId };

                var success = await _context.Database.ExecuteSqlRawAsync("CreateOrder @p0, @p1, @p2, @p3, @p4",
                                  sqlParams) == 1;

                if (success)
                {
                    request.OrderDetails.ForEach(x =>
                        {
                            var sqlParamsOrderDetail = new object[] { Guid.NewGuid(), x.OrderDetailProductAmount, x.OrderDetailSubTotal, x.ProductId, orderId };
                            _context.Database.ExecuteSqlRaw("CreateOrderDetail @p0, @p1, @p2, @p3, @p" , sqlParamsOrderDetail);
                        });

                    return Unit.Value;
                }

                throw new Exception("Problem saving changes");
            }
        }
    }
}
