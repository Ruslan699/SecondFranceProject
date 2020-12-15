using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DAOs.UserDAOs
{
   public interface IBaseDao
    {
        [Key]
        Guid Id { get; set; }
        Guid? CreatedUserId { get; set; }
        Guid? ModifiedUserId { get; set; }
        DateTime CreatedDate { get; set; }
        Status Status { get; set; }
        int Version { get; }
    }
}
