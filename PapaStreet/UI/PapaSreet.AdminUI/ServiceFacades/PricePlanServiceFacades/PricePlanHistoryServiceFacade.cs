using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.ServiceFacades
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
            var response = _pricePlanHistoryService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<PricePlanHistoryDto>().AsQueryable();
        }

        public PricePlanHistoryDto GetById(Guid id)
        {
            var response = _pricePlanHistoryService.GetAll();
            if (response.IsSucceed)
            {
                var dto = response.Data.FirstOrDefault(x => x.Id == id);
                if (dto == null)
                    return new PricePlanHistoryDto();
                return dto;
            }
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