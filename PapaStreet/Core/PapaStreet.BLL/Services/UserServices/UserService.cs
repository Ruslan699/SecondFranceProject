using Microsoft.AspNet.Identity;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.Services
{
    public class UserService:IBaseUserService<UserDto>
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResponse<IQueryable<UserDto>> GetAll(params Enums.Status[] statuses)
        {
            var users = _userRepository.GetAll(statuses);
            return users;
        }

        public ActionResponse<UserDto> GetById(Guid id)
        {
            var userId = _userRepository.GetById(id);
            return userId;
        }

        public ActionResponse Remove(Guid id)
        {
            var removedId = _userRepository.Remove(id);
            return removedId;
        }

        public ActionResponse Save(UserDto obj)
        {
            var result = new UserValidator().Validate(obj);
            if (result.IsValid)
            {
                var user = _userRepository.Save(obj);
                return user;
            }
            else
            {
                var errors = result.Errors.Select(m => m.ErrorMessage).ToArray();
                return ActionResponse.Failure(errors);
            }
        
        }

        public ActionResponse<UserDto> Login(string email, string password)
        {
            try
            {
                var users = _userRepository.GetAll(Status.Active);
                if (users.IsSucceed)
                {
                    var user = users.Data.FirstOrDefault(e => e.Email == email);

                    if (user == null)
                        return ActionResponse<UserDto>.Failure(UI.UserNotFound);
                    var verify = HashHelper.Verify(user.PasswordHash, password);
                    if (!verify)
                        return ActionResponse<UserDto>.Failure(UI.PasswordIsIncorrect);

                    return ActionResponse<UserDto>.Succeed(user);
                }
                else return ActionResponse<UserDto>.Failure(string.Join(", ", users.FailureResult));
            }
            catch (Exception ex)
            {
                return ActionResponse<UserDto>.Failure(ex.Message);
            }
        }

        public ActionResponse ResetPassword(Guid userId, string oldPassword, string newPassword, string confirmPassword, params Status[] statuses)
        {
            try
            {
                var all = _userRepository.GetAll(statuses);
                if (all.IsSucceed)
                {
                    var user = all.Data.FirstOrDefault(e => e.Id == userId);
                    if (user != null)
                    {
                        //oldPassword = user.PasswordHash;
                        user.PasswordHash = HashHelper.ComputeHash(newPassword);
                       
                        return _userRepository.Save(user);
                    }
                    else return ActionResponse.Failure(UI.UserNotFound);
                }
                else return ActionResponse.Failure(all.FailureResult);
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}
