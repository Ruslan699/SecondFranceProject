using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class CityServiceFacade : BaseServiceFacade, IBaseServiceFacade<CityDto>
    {
        private readonly CityService _cityService;

        public CityServiceFacade(CityService cityService)
        {
            _cityService = cityService;
        }
        public IQueryable<CityDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _cityService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<CityDto>().AsQueryable();
        }

        public CityDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _cityService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new CityDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _cityService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(CityDto obj)
        {
            var response = new SiteResponse();
            var command = _cityService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}