using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DAOs
{
    [Table("RolePermissions")]
    public class RolePermissionDao : BaseDao
    {
        public Guid RoleId { get; set; }
        public Permission Permission { get; set; }
        public string Name => Permission.ToString();
        public string Description { get; set; }

        [ForeignKey(nameof(RoleId))]
        public RoleDao Role { get; set; }
    }
}
