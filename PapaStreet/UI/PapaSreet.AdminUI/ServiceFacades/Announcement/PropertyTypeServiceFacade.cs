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
    public class PropertyTypeServiceFacade : BaseServiceFacade, IBaseServiceFacade<PropertyTypeDto>
    {
        private readonly PropertyTypeService _propertyTypeService;
        public PropertyTypeServiceFacade(PropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }
        public IQueryable<PropertyTypeDto> GetAll(params Status[] statuses)
        {
            var response = _propertyTypeService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<PropertyTypeDto>().AsQueryable();
        }

        public PropertyTypeDto GetById(Guid id)
        {
            var dto = _propertyTypeService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
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