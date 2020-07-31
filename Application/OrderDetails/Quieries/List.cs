using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.OrderDetails.Quieries
{
    using Domain.Models;
    public class List
    {
        public class Query : IRequest<List<OrderDetail>>
        {
        }

        public class Handler : IRequestHandler<Query, List<OrderDetail>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<OrderDetail>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
