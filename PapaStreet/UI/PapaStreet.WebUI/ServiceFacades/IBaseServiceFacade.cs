using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.ServiceFacades
{
    public interface IBaseServiceFacade<TDto> where TDto : BaseDto
    {
        IQueryable<TDto> GetAll(params Status[] statuses);
        TDto GetById(Guid id, params Status[] statuses);
        SiteResponse Remove(Guid id);
        SiteResponse Save(TDto obj);
    }
}
