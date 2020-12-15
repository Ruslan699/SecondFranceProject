using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
   public class UserClaimsDao : IdentityUserClaim<Guid>
    {
    }

    public class UserClaimsDao<TKey>
    {
        public virtual int Id { get; set; }

        public virtual TKey UserId { get; set; }

        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }
    }
}
