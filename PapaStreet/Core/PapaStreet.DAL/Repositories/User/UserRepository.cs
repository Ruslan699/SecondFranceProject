using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.AspNet.Identity;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;
using PapaStreet.BLL.Validators;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using PapaStreet.DAL.DAOs.UserDAOs;
using PapaStreet.DAL.Utils;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;

namespace PapaStreet.DAL.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        
        public ApplicationUserManager UserManager => _userManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        public ApplicationSignInManager SignInManager => _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
   
        public ActionResponse<IQueryable<UserDto>> GetAll(params Enums.Status[] statuses)
        {
            try
            {
                var users = UserManager.Users.ProjectTo<UserDto>(Mapper.Configuration);
                return ActionResponse<IQueryable<UserDto>>.Succeed(users);
            }
            catch (Exception exc)
            {
                return ActionResponse<IQueryable<UserDto>>.Failure(exc.Message);
            }
        }

        public ActionResponse<UserDto> GetById(Guid id)
        {
            try
            {
                var user = UserManager.FindById(id);
                var dto = Mapper.Map<UserDto>(user);
                return ActionResponse<UserDto>.Succeed(dto);
            }
            catch (Exception exc)
            {
                return ActionResponse<UserDto>.Failure(exc.Message);
            }
        }

        public ActionResponse Remove(Guid id)
        {
            try
            {
                var user = _userManager.FindById(id);
                if (user == null)
                    return ActionResponse.Failure($"User not found for id={id.ToString()}");
                _userManager.Delete(user);
                return ActionResponse.Succeed();
            }

            catch (Exception exc)
            {
                return ActionResponse<UserDto>.Failure(exc.Message);
            }
        }

        public ActionResponse Save(UserDto obj)
        {
            try
            {
                var dao = Mapper.Map<UserDao>(obj);
                if (obj.Id == default(Guid))
                {
                    var response = _userManager.Create(dao);
                    if (!response.Succeeded)
                        return ActionResponse.Failure(response.Errors.ToArray());
                    var user = _userManager.FindByEmail(obj.Email);
                    if (user == null)
                        return ActionResponse.Failure($"User not found for email={obj.Email.ToString()}");
                    return ActionResponse.Succeed();
                }
                else
                {
                    using (ApplicationDataContext ctx = new ApplicationDataContext())
                    {
                        
                        ctx.Entry(dao).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    return ActionResponse.Succeed();
                }

            }
            catch (Exception exc)
            {
                return ActionResponse.Failure(exc.Message);
            }
        }
                

        public async Task<ActionResponse> SignIn(string email, string password, bool rememberMe = false)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(email);
                var response = await SignInManager.PasswordSignInAsync(user.Email,user.PasswordHash, rememberMe, shouldLockout: false);
                switch (response)
                {
                    case SignInStatus.Success:
                        return ActionResponse.Succeed();
                    case SignInStatus.LockedOut:
                        return ActionResponse.Failure($"Lockout for email {email.ToString()}");
                    case SignInStatus.RequiresVerification:
                        return ActionResponse.Failure("Sign in failed");
                    case SignInStatus.Failure:
                    default:
                        return ActionResponse.Failure("This email or password is invalid");
                }
            }
            catch (Exception exc)
            {
                return ActionResponse<UserDto>.Failure(exc.Message);
            }
        }

        public void Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            if (_signInManager != null)
            {
                _signInManager.Dispose();
                _signInManager = null;
            }
        }
    }
}

