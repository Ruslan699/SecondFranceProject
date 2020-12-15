using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("UserLogins")]
    public class UserLoginDao : IdentityUserLogin<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }

    public class UserLoginDao<TKey>
    {
        public virtual string LoginProvider { get; set; }

        public virtual string ProviderKey { get; set; }

        public virtual TKey UserId { get; set; }
    }
        
  
}
