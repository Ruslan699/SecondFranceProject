using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.DTOs
{
    public class RolePermissionDto : BaseDto
    {
        public Guid RoleId { get; set; }
        public Permission Permission { get; set; }
        public string Name => Permission.ToString();
        public string Description { get; set; }

        public RoleDto Role { get; set; }
    }
}
