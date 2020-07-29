using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Category.Query
{
    public class List
    {
        public class Query : IRequest<List<Domain.Models.Category>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Domain.Models.Category>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Models.Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categories =
                    await _context.Categories.FromSqlRaw("GetAllCategories").ToListAsync(cancellationToken);

                return categories;
            }

        }
    }
}
