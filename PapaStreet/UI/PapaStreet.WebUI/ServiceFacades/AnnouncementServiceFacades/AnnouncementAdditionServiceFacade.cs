using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Linq;

namespace PapaStreet.WebUI.ServiceFacades
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
            var all = _announcementAdditionService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<AnnouncementAdditionDto>().AsQueryable();
        }

        public AnnouncementAdditionDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _announcementAdditionService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
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