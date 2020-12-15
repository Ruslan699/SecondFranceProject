using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class GenericAnnouncementServiceFacade:BaseServiceFacade
    {
        private readonly GenericAnnouncementService  _genericAnnouncementService;

        public GenericAnnouncementServiceFacade(GenericAnnouncementService genericAnnouncementService)
        {
            _genericAnnouncementService = genericAnnouncementService;
        }
        public IQueryable<GenericAnnouncementDto> GetAll(params Status[] statuses)
        {
            var response = _genericAnnouncementService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<GenericAnnouncementDto>().AsQueryable();
        }

        public GenericAnnouncementDto GetById(Guid id)
        {
            var dto = _genericAnnouncementService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new GenericAnnouncementDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _genericAnnouncementService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(GenericAnnouncementDto obj)
        {
            var response = new SiteResponse();
            var command = _genericAnnouncementService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}