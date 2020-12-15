using Microsoft.AspNet.Identity.EntityFramework;
using PapaStreet.DAL.DAOs.UserDAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
    [Table("Roles")]
    public class RoleDao:IdentityRole<Guid,UserRoleDao>
    {
  
        public string Description { get; set; }

    }
}
