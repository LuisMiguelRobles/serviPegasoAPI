using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Payment.Quieries
{
    using Domain.Models;
    public class List
    {
        public class Query : IRequest<List<Payment>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Payment>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Payment>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }
    }
}
