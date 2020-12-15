using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.Common.Constants
{
    public static class Enums
    {
        public enum Status
        {
            [Display(Name = "Active")]
            Active,
            [Display(Name = "Deactive")]
            Deactive,
            [Display(Name = "Deleted")]
            Deleted,
            [Display(Name = "Pending")]
            Pending,
            [Display(Name = "Rejected")]
            Rejected,
            [Display(Name = "Blocked")]
            Blocked
        }

        public enum Permission
        {
            
        }

        public enum VendorType
        {
            Ownership = 1,
            Mediator = 2
        }

        public enum SourceType
        {
            Default,
            Other
        }
        public enum SortBy
        {
            Default = 1,
            Area=2,
            PriceLowToHigh=3,
            PriceHighToLow=4
        }

        public static string GetStatusName(Status value)
        {
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }
    }
}
