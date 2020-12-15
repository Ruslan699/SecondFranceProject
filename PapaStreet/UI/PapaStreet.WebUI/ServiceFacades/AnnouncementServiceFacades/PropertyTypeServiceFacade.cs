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
    public class PropertyTypeServiceFacade : BaseServiceFacade, IBaseServiceFacade<PropertyTypeDto>
    {
        private readonly PropertyTypeService _propertyTypeService;

        public PropertyTypeServiceFacade(PropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }
        public IQueryable<PropertyTypeDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _propertyTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<PropertyTypeDto>().AsQueryable();
        }

        public PropertyTypeDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _propertyTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new PropertyTypeDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _propertyTypeService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(PropertyTypeDto obj)
        {
            var response = new SiteResponse();
            var command = _propertyTypeService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}