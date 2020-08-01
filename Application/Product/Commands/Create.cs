namespace Application.Product.Commands
{
    using Interfaces;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Create
    {
        public class Command : IRequest
        {
            public string ProductName { get; set; }
            public double ProductPrice { get; set; }
            public string ProductDescription { get; set; }
            public IFormFile File { get; set; }
            public Guid CategoryId { get; set; }
        }


        public class CommandValidator: AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductName).NotEmpty();
                RuleFor(x => x.ProductPrice).NotEmpty();
                RuleFor(x => x.ProductDescription).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
            }
        }


        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IPhotosAccessor _photosAccessor;

            public Handler(DataContext context, IPhotosAccessor photosAccessor)
            {
                _context = context;
                _context = context;
                _photosAccessor = photosAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = _photosAccessor.AddPhoto(request.File);

                var sqlParams = new object[] { Guid.NewGuid(), request.ProductName, request.ProductPrice, true, request.ProductDescription, photoUploadResult.Url, request.CategoryId };
                
                var success = await _context.Database.ExecuteSqlRawAsync("CreateProduct @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                    sqlParams) == 1;

                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
