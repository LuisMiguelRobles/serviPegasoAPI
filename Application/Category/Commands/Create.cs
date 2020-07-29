using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Category.Commands
{
    public class Create
    {
        public class Command: IRequest
        {
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
            public bool CategoryStatus { get; set; }
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
                var success = await Task.FromResult(_context.Database.ExecuteSqlCommand("CreateCategory @p0, @p1, @p2, @p3", Guid.NewGuid(), request.CategoryName, request.CategoryDescription, request.CategoryStatus));

                if(success == 1) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
