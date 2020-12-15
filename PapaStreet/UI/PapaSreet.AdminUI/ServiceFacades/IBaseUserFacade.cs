
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public interface IBaseUserFacade<TDto> where TDto : class
    {
        IQueryable<TDto> GetAll(params Status[] statuses);
        TDto GetById(Guid id, params Status[] statuses);
        SiteResponse Remove(Guid id);
        SiteResponse Save(TDto obj);
    }
}
