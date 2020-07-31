namespace Application.Product.Quieries
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
        public class Query : IRequest<List<Product>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Product>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new Exception();
            }

        }
    }
}
