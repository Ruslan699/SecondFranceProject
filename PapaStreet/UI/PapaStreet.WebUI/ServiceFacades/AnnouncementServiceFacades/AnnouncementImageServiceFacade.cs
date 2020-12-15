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
    public class AnnouncementImageServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementImageDto>
    {
        private readonly AnnouncementImageService _announcementImageService;

        public AnnouncementImageServiceFacade(AnnouncementImageService announcementImageService)
        {
            _announcementImageService = announcementImageService;
        }
        public IQueryable<AnnouncementImageDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _announcementImageService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<AnnouncementImageDto>().AsQueryable();
        }

        public AnnouncementImageDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _announcementImageService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new AnnouncementImageDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementImageService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(AnnouncementImageDto obj)
        {
            var response = new SiteResponse();
            var command = _announcementImageService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}