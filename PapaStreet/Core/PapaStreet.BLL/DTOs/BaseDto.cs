using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.DTOs
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public Guid? CreatedUserId { get; }
        public Guid? ModifiedUserId { get; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; }
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
    }
}
