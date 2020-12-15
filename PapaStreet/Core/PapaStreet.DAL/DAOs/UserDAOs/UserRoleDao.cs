using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
   public class UserRoleDao : IdentityUserRole<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }

    public class UserRoleDao<TKey>
    {
        public virtual TKey UserId { get; set; }

        public virtual TKey RoleId { get; set; }
    }
}
