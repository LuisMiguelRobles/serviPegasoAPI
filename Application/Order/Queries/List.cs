namespace Application.Order.Queries
{
    using MediatR;
    using Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public class List
    {
        public class Query : IRequest<List<Order>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Order>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Order>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
