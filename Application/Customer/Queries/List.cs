namespace Application.Customer.Queries
{
    using Domain.Models;
    using MediatR;
    using Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class List
    {
        public class Query : IRequest<List<Customer>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Customer>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
