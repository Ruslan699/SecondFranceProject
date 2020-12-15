using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class AnnouncementImageServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementImageDto>
    {
        private readonly AnnouncementImageService _announcementImageService;

        public AnnouncementImageServiceFacade(AnnouncementImageService announcementImageService)
        {
            _announcementImageService = announcementImageService;
        }
        public IQueryable<AnnouncementImageDto> GetAll(params Status[] statuses)
        {
            var all = _announcementImageService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<AnnouncementImageDto>().AsQueryable();
        }

        public AnnouncementImageDto GetById(Guid id)
        {
            var dto = _announcementImageService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
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