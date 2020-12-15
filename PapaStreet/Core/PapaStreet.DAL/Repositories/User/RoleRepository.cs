using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DAOs.UserDAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.Repositories
{
    public class RoleRepository : IRoleRepository<RoleDto>
    {
        private readonly RoleManager<RoleDao, Guid> _roleManager;
        public RoleRepository(RoleManager<RoleDao,Guid> roleManager)
        {
            _roleManager = roleManager;
        }

        public ActionResponse<IQueryable<RoleDto>> GetAll(params Enums.Status[] statuses)
        {
            try
            {
                var roles = _roleManager.Roles.ProjectTo<RoleDto>(Mapper.Configuration);
                return ActionResponse<IQueryable<RoleDto>>.Succeed(roles);
            }
            catch (Exception exc)
            {
                return ActionResponse<IQueryable<RoleDto>>.Failure(exc.Message);
            }
        }

        public ActionResponse<RoleDto> GetById(Guid id)
        {
            try
            {
                var user = _roleManager.FindById(id);
                var dto = Mapper.Map<RoleDto>(user);
                return ActionResponse<RoleDto>.Succeed(dto);
            }
            catch (Exception exc)
            {
                return ActionResponse<RoleDto>.Failure(exc.Message);
            }
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            try
            {
                var role = _roleManager.FindById(id);
                if (role == null)
                    return ActionResponse.Failure($"Role not found for id={id.ToString()}");
                _roleManager.Delete(role);
                return ActionResponse.Succeed();
            }

            catch (Exception exc)
            {
                return ActionResponse<RoleDto>.Failure(exc.Message);
            }
        }

        public ActionResponse Save(RoleDto obj, Guid? userId = null)
        {
            return ActionResponse<RoleDto>.Succeed();
            //try
            //{
            //    var dao = Mapper.Map<RoleDto>(obj);
            //    if (obj.Id == null)
            //    {
            //        var response = _roleManager.Create(dao,userId);
            //        if (!response.Succeeded)
            //            return ActionResponse.Failure(response.Errors.ToArray());
            //        var user = _roleManager.FindByName(obj.Name);
            //        if (user == null)
            //            return ActionResponse.Failure($"Role not found for name={obj.Name.ToString()}");
            //        return ActionResponse.Succeed();
            //    }
            //    else
            //    {
            //        var response = _roleManager.Update(dao);
            //        if (!response.Succeeded)
            //            return ActionResponse.Failure(response.Errors.ToArray());
            //        return ActionResponse.Succeed();
            //    }

            //}
            //catch (Exception exc)
            //{
            //    return ActionResponse.Failure(exc.Message);
            //}
        }
    }
}
