using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Deliverer.Queries
{
    using Domain.Models;
    public class List
    {
        public class Query : IRequest<List<Deliverer>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Deliverer>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Deliverer>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
