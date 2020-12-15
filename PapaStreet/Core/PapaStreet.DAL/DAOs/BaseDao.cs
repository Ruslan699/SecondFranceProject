using PapaStreet.Common.Constants;
using PapaStreet.DAL.DAOs.UserDAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DAOs
{
    public abstract class BaseDao
    {
        public Guid Id { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        public int Version { get; private set; }

        public void SetVersion(int version)
        {
            this.Version = version;
        }


    }
}
