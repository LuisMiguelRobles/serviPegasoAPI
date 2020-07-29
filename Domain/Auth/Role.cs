namespace Domain.Auth
{
    using System;
    using System.Collections.Generic;

    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
