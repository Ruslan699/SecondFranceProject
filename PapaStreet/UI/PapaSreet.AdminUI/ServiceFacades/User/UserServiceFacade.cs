using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.Security;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class UserServiceFacade : BaseUserServiceFasade, IBaseUserFacade<UserDto>
    {
        private readonly UserService _userService;
        public UserServiceFacade(UserService userService)
        {
            _userService = userService;
        }
        public IQueryable<UserDto> GetAll(params Status[] statuses)
        {
            var all = _userService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
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
        public SiteResponse Login(UserDto obj)
        {
            var response = new SiteResponse();
            var command = _userService.Login(obj.Email, obj.Password);
            if (command.IsSucceed)
                CustomIdentity.User = command.Data;
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse ChangePassword(ChangePasswordViewModell user)
        {
            var response = new SiteResponse();
            var command = _userService.ResetPassword(user.Id, user.OldPassword, user.NewPassword, user.ConfirmPassword);
            SetResponse(command, ref response);
            return response;
        }
    }
}