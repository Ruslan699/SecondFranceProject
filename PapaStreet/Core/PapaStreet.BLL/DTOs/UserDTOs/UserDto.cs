using Microsoft.AspNet.Identity.EntityFramework;
using PapaStreet.BLL.DTOs.UserDTOs;
using System;

namespace PapaStreet.BLL.DTOs
{
    public class UserDto:IdentityUser<Guid,UserLoginDto,UserRoleDto,UserClaimDto>
    {
        //public Guid RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        //public RoleDto Role { get; set; }
    }
}
