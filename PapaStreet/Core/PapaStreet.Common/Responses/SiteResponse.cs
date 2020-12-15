using PapaStreet.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.Common.Responses
{
    public class SiteResponse
    {
        public SiteResponse()
        {
            IsSucceed = true;
            Description = UI.SuccessOperation;
        }

        public void Success()
        {
            IsSucceed = true;
            Description = UI.SuccessOperation;
        }

        public void Success(string description)
        {
            IsSucceed = true;
            Description = description;
        }

        public void Failure()
        {
            IsSucceed = false;
            Description = UI.FailureOperation;
        }

        public void Failure(string description)
        {
            IsSucceed = false;
            Description = description;
        }

        public bool IsSucceed { get; set; }
        public string Description { get; set; }

    }
}