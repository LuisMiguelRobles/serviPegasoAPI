namespace Application.Auth.Queries
{
    using Application.Auth.Responses;
    using Domain.Auth;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListAllUsers
    {
        public class Query: IRequest<List<UserResponse>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<UserResponse>>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, UserManager<AppUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public Task<List<UserResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var usersResponse = new List<UserResponse>();

                var users = _userManager.Users;

                foreach (var user in users)
                {
                    usersResponse.Add(new UserResponse
                    {
                        Id = user.Id,
                        UserFullName = user.UserFullName,
                        UserName = user.UserName,
                        RoleName = _context.Roles.Find(user.RoleId).RoleName,
                        Email = user.Email,
                        UserStatus = user.UserStatus,
                        UserBirthDay = user.UserBirthDay
                    });
                }

                return usersResponse;
            }
        }
    }

    
}
