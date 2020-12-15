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
    public class RegionDepartamentServiceFacade : BaseServiceFacade, IBaseServiceFacade<RegionDepartamentDto>
    {
        private readonly RegionDepartamentService _regionDepartamentService;
        public RegionDepartamentServiceFacade(RegionDepartamentService regionDepartamentService)
        {
            _regionDepartamentService = regionDepartamentService;
        }
        public IQueryable<RegionDepartamentDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _regionDepartamentService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<RegionDepartamentDto>().AsQueryable();
        }

        public RegionDepartamentDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _regionDepartamentService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new RegionDepartamentDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _regionDepartamentService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(RegionDepartamentDto obj)
        {
            var response = new SiteResponse();
            var command = _regionDepartamentService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}