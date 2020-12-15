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
    public class ManageUsersServiceFacade : BaseServiceFacade, IBaseUserFacade<UserDto>
    {
        private readonly UserService _userService;

        public ManageUsersServiceFacade(UserService userService)
        {
            _userService = userService;
        }
        public IQueryable<UserDto> GetAll(params Status[] statuses)
        {
            var response = _userService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<UserDto>().AsQueryable();
        }

        public UserDto GetById(Guid id, params Status[] statuses)
        {
            var dto = _userService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new UserDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _userService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(UserDto obj)
        {
            var response = new SiteResponse();
            var command = _userService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}