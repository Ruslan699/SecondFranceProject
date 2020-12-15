using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs.UserDTOs
{
   public class UserRoleDto : IdentityUserRole<Guid>
    {
    }

    public class UserRoleDto<TKey>
    {
        public virtual TKey UserId { get; set; }

        public virtual TKey RoleId { get; set; }
    }
}
