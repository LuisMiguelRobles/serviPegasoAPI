namespace Domain.Auth
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser
    {
        public string UserFullName { get; set; }
        public bool UserStatus { get; set; }
        public DateTime UserBirthDay{ get; set; }
        public Role UserRole { get; set; }
        public Guid RoleId { get; set; }
    }
}
