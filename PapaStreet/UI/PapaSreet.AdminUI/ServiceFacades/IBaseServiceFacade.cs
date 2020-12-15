using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public interface IBaseServiceFacade<TDto> where TDto : BaseDto
    {
        IQueryable<TDto> GetAll(params Status[] statuses);
        TDto GetById(Guid id);
        SiteResponse Remove(Guid id);
        SiteResponse Save(TDto obj);
    }
}