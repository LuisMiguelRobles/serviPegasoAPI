namespace Application.Delivery.Queries
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
        public class Query : IRequest<List<Delivery>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Delivery>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Delivery>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
