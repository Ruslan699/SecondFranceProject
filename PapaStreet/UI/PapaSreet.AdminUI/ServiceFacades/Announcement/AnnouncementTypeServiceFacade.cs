using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class AnnouncementTypeServiceFacade:BaseServiceFacade,IBaseServiceFacade<AnnouncementTypeDto>
    {
        private readonly AnnouncementTypeService _announcementTypeService;
        public AnnouncementTypeServiceFacade(AnnouncementTypeService announcementTypeService)
        {
            _announcementTypeService = announcementTypeService;
        }

        public IQueryable<AnnouncementTypeDto> GetAll(params Status[] statuses)
        {
            var response = _announcementTypeService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<AnnouncementTypeDto>().AsQueryable();
        }

        public AnnouncementTypeDto GetById(Guid id)
        {
            var dto = _announcementTypeService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new AnnouncementTypeDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementTypeService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(AnnouncementTypeDto obj)
        {
            var response = new SiteResponse(); 
            var command = _announcementTypeService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}