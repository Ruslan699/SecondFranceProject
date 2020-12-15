using AutoMapper;
using AutoMapper.QueryableExtensions;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using System;
using System.Data.Entity;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.Repositories
{
    public abstract class BaseRepository<TDto, TDao, TContext> : IBaseRepository<TDto>
        where TDto : BaseDto
        where TDao : BaseDao
        where TContext : DbContext
    {
        private TContext ctx;

        public virtual ActionResponse<IQueryable<TDto>> GetAll(params Enums.Status[] statuses)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var entities = ctx.Set<TDao>()
                    .Where(e => statuses.Count() == 0 || statuses.Contains(e.Status))
                    .ProjectTo<TDto>(Mapper.Configuration);
                return ActionResponse<IQueryable<TDto>>.Succeed(entities);
            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<TDto>>.Failure(ex.Message);
            }
        }

        public virtual ActionResponse<TDto> GetById(Guid id)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var dao = ctx.Set<TDao>().FirstOrDefault(e => e.Id == id);
                var dto = Mapper.Map<TDto>(dao);
                return ActionResponse<TDto>.Succeed(dto);
            }
            catch (Exception ex)
            {
                return ActionResponse<TDto>.Failure(ex.Message);
            }
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var data = ctx.Set<TDao>().Find(id);
                data.Status = Status.Deleted;
                ctx.Entry(data).State = EntityState.Modified;
                var result = ctx.SaveChanges();
                return ActionResponse.Succeed();
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        private ActionResponse Add(TDto obj, Guid? userId = null)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var model = Mapper.Map<TDao>(obj);
                model.Id = Guid.NewGuid();
                model.CreatedDate = DateTime.UtcNow.AddHours(4);
                model.CreatedUserId = userId;
                model.ModifiedDate = null;
                model.SetVersion(1);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    if (obj.Id == default(Guid))
                        ctx.Set<TDao>().Add(model);
                    var result = ctx.SaveChanges();
                    transaction.Commit();
                    obj.Id = model.Id;
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        private ActionResponse Update(TDto obj, Guid? userId = null)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var model = Mapper.Map<TDao>(obj);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    var dbModel = ctx.Set<TDao>().FirstOrDefault(x => x.Id == model.Id);
                    dbModel.ModifiedUserId = userId;
                    dbModel.ModifiedDate = DateTime.UtcNow.AddHours(4);
                    var version = dbModel.Version + 1;
                    model.SetVersion(version);
                    var entry = ctx.Entry(dbModel);
                    entry.CurrentValues.SetValues(model);
                    entry.Property(e => e.CreatedDate).IsModified = false;
                    entry.Property(e => e.CreatedUserId).IsModified = false;
                    ctx.SaveChanges();
                    transaction.Commit();
                    obj.Id = model.Id;
                    return ActionResponse.Succeed();
                }
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        public virtual ActionResponse Save(TDto obj, Guid? userId = null)
        {
            var response = obj.Id == default(Guid) ? Add(obj, userId) : Update(obj, userId);
            return response;
        }
    }
}
