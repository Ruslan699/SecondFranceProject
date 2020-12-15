using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class CityServiceFacade : BaseServiceFacade, IBaseServiceFacade<CityDto>
    {
        private readonly CityService _cityService;
        public CityServiceFacade(CityService cityService)
        {
            _cityService = cityService;
        }
        public IQueryable<CityDto> GetAll(params Status[] statuses)
        {
            var response = _cityService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<CityDto>().AsQueryable();
        }

        public CityDto GetById(Guid id)
        {
            var dto = _cityService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
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
            obj.ZipCodeAndName = obj.ZipCode + "-" + obj.Name;
            var command = _cityService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}