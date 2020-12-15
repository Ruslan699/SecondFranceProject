using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class PricePlanServiceFacade : BaseServiceFacade, IBaseServiceFacade<PricePlanDto>
    {
        private readonly PricePlanService _pricePlanService;
        public PricePlanServiceFacade(PricePlanService pricePlanService)
        {
            _pricePlanService = pricePlanService;
        }
        public IQueryable<PricePlanDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _pricePlanService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<PricePlanDto>().AsQueryable();
        }

        public PricePlanDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _pricePlanService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new PricePlanDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _pricePlanService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(PricePlanDto obj)
        {
            var response = new SiteResponse();
            var command = _pricePlanService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}