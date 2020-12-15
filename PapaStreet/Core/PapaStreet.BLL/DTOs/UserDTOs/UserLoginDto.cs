using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.DTOs.UserDTOs
{
   public class UserLoginDto:IdentityUserLogin<Guid>
    {
    }
    public class UserLoginDto<TKey>
    {
        public virtual string LoginProvider { get; set; }

        public virtual string ProviderKey { get; set; }

        public virtual TKey UserId { get; set; }
    }
}
