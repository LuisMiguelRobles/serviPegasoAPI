
namespace Application.Auth.Responses
{
    using System;

    public class UserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public bool UserStatus { get; set; }
        public DateTime UserBirthDay { get; set; }
        public string RoleName { get; set; }

    }
}
