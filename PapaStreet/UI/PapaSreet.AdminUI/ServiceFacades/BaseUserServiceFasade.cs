using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public abstract class BaseUserServiceFasade
    {
        public SiteResponse SetResponse(ActionResponse command, ref SiteResponse response)
        {
            if (!command.IsSucceed)
            {
                response.IsSucceed = false;
                response.Description = string.Join(" ", command.FailureResult);
            }
            return response;
        }
    }
}