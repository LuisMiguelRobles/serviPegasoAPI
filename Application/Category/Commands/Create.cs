namespace Application.Category.Commands
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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
                var sqlParams = new object[] { Guid.NewGuid(), request.CategoryName, request.CategoryDescription, request.CategoryStatus };
                var success = await _context.Database.ExecuteSqlRawAsync("CreateCategory @p0, @p1, @p2, @p3", sqlParams) == 1;

                if(success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
