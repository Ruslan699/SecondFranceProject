using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class AnnouncementManageServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementDto>
    {
        private readonly AnnouncementService _announcementService;

        public AnnouncementManageServiceFacade(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public IQueryable<AnnouncementDto> GetAll(params Status[] statuses)
        {
            var response = _announcementService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public IQueryable<AnnouncementDto> GetAll(int pageNo, int pageSize, string Email, params Status[] statuses)
        {
            var result = _announcementService.GetAll(statuses);
            if (result.IsSucceed)
                return result.Data.OrderByDescending(x => x.CreatedDate).Skip((pageNo - 1) * pageSize).Take(pageSize);
            return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public AnnouncementDto GetById(Guid id)
        {
            var response = _announcementService.GetAll();
            if (response.IsSucceed)
            {
                var dto = response.Data.FirstOrDefault(x => x.Id == id);
                if (dto == null)
                    return new AnnouncementDto();
                return dto;
            }
            return new AnnouncementDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(AnnouncementDto obj)
        {
            var response = new SiteResponse();
            var command = _announcementService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse IncViewsCount(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementService.IncViewsCount(id);
            SetResponse(command, ref response);
            return response;
        }
    }
}