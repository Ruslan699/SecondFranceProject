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
    public class PricePlanHistoryServiceFacade : BaseServiceFacade, IBaseServiceFacade<PricePlanHistoryDto>
    {
        private readonly PricePlanHistoryService _pricePlanHistoryService;
        public PricePlanHistoryServiceFacade(PricePlanHistoryService pricePlanHistoryService)
        {
            _pricePlanHistoryService = pricePlanHistoryService;
        }
        public IQueryable<PricePlanHistoryDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _pricePlanHistoryService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<PricePlanHistoryDto>().AsQueryable();
        }

        public PricePlanHistoryDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _pricePlanHistoryService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new PricePlanHistoryDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _pricePlanHistoryService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(PricePlanHistoryDto obj)
        {
            var response = new SiteResponse();
            var command = _pricePlanHistoryService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse DecUsedAnnouncementCount(Guid id)
        {
            var response = new SiteResponse();
            var command = _pricePlanHistoryService.DecUsedAnnouncementCount(id);
            SetResponse(command, ref response);
            return response;
        }
    }
}