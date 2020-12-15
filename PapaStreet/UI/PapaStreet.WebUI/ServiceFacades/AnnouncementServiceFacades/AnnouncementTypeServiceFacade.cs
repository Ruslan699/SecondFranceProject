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
    public class AnnouncementTypeServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementTypeDto>
    {
        private readonly AnnouncementTypeService _announcementTypeService;

        public AnnouncementTypeServiceFacade(AnnouncementTypeService announcementTypeService)
        {
            _announcementTypeService = announcementTypeService;
        }
        public IQueryable<AnnouncementTypeDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _announcementTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<AnnouncementTypeDto>().AsQueryable();
        }

        public AnnouncementTypeDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _announcementTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
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