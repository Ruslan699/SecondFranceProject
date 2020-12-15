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
    public class AnnouncementAdditionServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementAdditionDto>
    {
        private readonly AnnouncementAdditionService _announcementAdditionService;

        public AnnouncementAdditionServiceFacade(AnnouncementAdditionService announcementAdditionService)
        {
            _announcementAdditionService = announcementAdditionService;
        }

        public IQueryable<AnnouncementAdditionDto> GetAll(params Enums.Status[] statuses)
        {
            var response = _announcementAdditionService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<AnnouncementAdditionDto>().AsQueryable();
        }

        public AnnouncementAdditionDto GetById(Guid id)
        {
            var dto = _announcementAdditionService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new AnnouncementAdditionDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementAdditionService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(AnnouncementAdditionDto obj)
        {
            var response = new SiteResponse();
            var command = _announcementAdditionService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}