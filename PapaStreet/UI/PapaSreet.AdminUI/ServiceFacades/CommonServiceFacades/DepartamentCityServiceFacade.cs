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
    public class DepartamentCityServiceFacade : BaseServiceFacade, IBaseServiceFacade<DepartamentCityDto>
    {
        private readonly DepartamentCityService _departamentCityService;
        public DepartamentCityServiceFacade(DepartamentCityService departamentCityService)
        {
            _departamentCityService = departamentCityService;
        }
        public IQueryable<DepartamentCityDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _departamentCityService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<DepartamentCityDto>().AsQueryable();
        }

        public DepartamentCityDto GetById(Guid id)
        {
            var all = _departamentCityService.GetAll();
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new DepartamentCityDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _departamentCityService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(DepartamentCityDto obj)
        {
            var response = new SiteResponse();
            var command = _departamentCityService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}