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
    public class RegionServiceFacade : BaseServiceFacade, IBaseServiceFacade<RegionDto>
    {
        private readonly RegionService _regionService;
        public RegionServiceFacade(RegionService regionService)
        {
            _regionService = regionService;
        }
        public IQueryable<RegionDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _regionService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<RegionDto>().AsQueryable();
        }

        public RegionDto GetById(Guid id)
        {
            var all = _regionService.GetAll();
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new RegionDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _regionService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(RegionDto obj)
        {
            var response = new SiteResponse();
            var command = _regionService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}