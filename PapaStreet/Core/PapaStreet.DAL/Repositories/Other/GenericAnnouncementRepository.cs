using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.Repositories
{
    public class GenericAnnouncementRepository : BaseRepository<GenericAnnouncementDto, GenericAnnouncementDao, MainDataContext>, IGenericAnnouncementRepository
    {
        public ActionResponse<IQueryable<GenericAnnouncementDto>> GetAll_Old(params Enums.Status[] statuses)
        {
            try
            {
                var ctx = new MainDataContext();

                var entities = ctx.Set<GenericAnnouncementDao>()
                                  .Where(e => statuses.Count() == 0 || statuses.Contains(e.Status));
                var result = entities.Select(ToDTO).AsQueryable();
                return ActionResponse<IQueryable<GenericAnnouncementDto>>.Succeed(result);


            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<GenericAnnouncementDto>>.Failure(ex.Message);
            }
        }

        public ActionResponse<IQueryable<GenericAnnouncementDto>> SearchPagerSortBy(SearchDto search, int currentPage, int pageSize, params Enums.Status[] statuses)
        {
            try
            {
                var ctx = new MainDataContext();

                var entities = ctx.Set<GenericAnnouncementDao>()
                    .Where(e => statuses.Count() == 0 || statuses.Contains(e.Status));
                var result = entities.Select(ToDTO).AsQueryable();
                if (entities != null)
                {
                    List<string> citiNames = new List<string>();
                    //if (search.Regions.HasValue && !search.Departaments.HasValue)
                    //{

                    //    var departaments = ctx.RegionDepartaments.Where(x => x.RegionId == search.Regions.Value).ToList();
                    //    foreach (var departament in departaments)
                    //    {
                    //        var cities = ctx.DepartamentCities.Where(x => x.DepartamentId == departament.DepartamentId).ToList();
                    //        foreach (var city in cities)
                    //        {
                    //            var citiesname = ctx.Cities.Where(x => x.Id == city.CityId);
                    //            citiNames.AddRange(citiesname.Select(c => c.Name).ToList());
                    //        }
                    //    }
                    //    entities = entities.Where(x => citiNames.Contains(x.City));
                    //}
                    if (search.Departaments.HasValue)
                    {
                        var cities = ctx.DepartamentCities.Where(x => x.DepartamentId == search.Departaments.Value).ToList();
                        foreach (var city in cities)
                        {
                            var citiesname = ctx.Cities.Where(x => x.Id == city.CityId);
                            citiNames.AddRange(citiesname.Select(c => c.Name).ToList());
                        }
                        entities = entities.Where(x => citiNames.Contains(x.City));
                    }
                    if (search.Cities != null || search.CityName != null)
                    {
                            entities = entities.Where(x => search.CityName.Contains(x.City));
                    }
                    if (search.AnnouncementAdditionId != null)
                    {
                        entities = entities
                            .Where(x => x.AnnouncementAddition.Contains(search.AnnouncementAdditionId));
                    }
                    if (search.announcementtype.HasValue)
                        entities = entities.Where(x => x.AnnouncementTypeId == search.announcementtype);
                    if (search.PropertyTypes.HasValue)
                        entities = entities.Where(x => x.PropertyTypeId == search.PropertyTypes);
                    if (search.minprice.HasValue)
                        entities = entities.Where(e => e.PriceDouble >= search.minprice.Value);
                    if (search.maxprice.HasValue)
                        entities = entities.Where(e => e.PriceDouble <= search.maxprice.Value);
                    if (search.minarea.HasValue)
                        entities = entities.Where(e => e.Area >= search.minarea.Value);
                    if (search.maxarea.HasValue)
                        entities = entities.Where(e => e.Area <= search.maxarea.Value);
                    if (search.minroomcount.HasValue)
                        entities = entities.Where(e => e.RoomCount >= search.minroomcount.Value);
                    if (search.maxroomcount.HasValue)
                        entities = entities.Where(e => e.RoomCount <= search.maxroomcount.Value);
                    if (search.sortBy.HasValue)
                    {
                        switch (search.sortBy)
                        {
                            case 1:
                                entities = entities.OrderByDescending(s => s.CreatedDate);
                                break;
                            case 2:
                                entities = entities.OrderByDescending(s => s.CreatedDate);
                                break;
                            case 3:
                                entities = entities.OrderByDescending(s => s.CreatedDate);
                                break;
                            case 4:
                                entities = entities.OrderByDescending(s => s.CreatedDate);
                                break;
                            default:
                                entities = entities.OrderByDescending(s => s.CreatedDate);
                                break;
                        }
                    }
                   
                    else entities = entities.OrderByDescending(s => s.CreatedDate);
                    
                    result = entities.Skip((currentPage - 1) * pageSize).Take(pageSize).ToArray().Select(ToDTO).AsQueryable();

                    return ActionResponse<IQueryable<GenericAnnouncementDto>>.Succeed(result);
                }
                else
                    return ActionResponse<IQueryable<GenericAnnouncementDto>>.Succeed(result);


            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<GenericAnnouncementDto>>.Failure(ex.Message);
            }
        }

        public ActionResponse<int> SearchPagerSortByCount(SearchDto search, params Enums.Status[] statuses)
        {
            try
            {
                var ctx = new MainDataContext();

                var entities = ctx.Set<GenericAnnouncementDao>()
                    .Where(e => statuses.Count() == 0 || statuses.Contains(e.Status));
                var result = entities.Count();
                if (entities != null)
                {
                    List<string> citiNames = new List<string>();
                    //if (search.Regions.HasValue && !search.Departaments.HasValue)
                    //{

                    //    var departaments = ctx.RegionDepartaments.Where(x => x.RegionId == search.Regions.Value).ToList();
                    //    foreach (var departament in departaments)
                    //    {
                    //        var cities = ctx.DepartamentCities.Where(x => x.DepartamentId == departament.DepartamentId).ToList();
                    //        foreach (var city in cities)
                    //        {
                    //            var citiesname = ctx.Cities.Where(x => x.Id == city.CityId);
                    //                citiNames.AddRange(citiesname.Select(c => c.Name).ToList());
                    //        }
                    //    }
                    //    entities = entities.Where(x => citiNames.Contains(x.City));
                    //}
                    if (search.Departaments.HasValue)
                    {
                        var cities = ctx.DepartamentCities.Where(x => x.DepartamentId == search.Departaments.Value).ToList();
                        foreach (var city in cities)
                        {
                            var citiesname = ctx.Cities.Where(x => x.Id == city.CityId);
                            citiNames.AddRange(citiesname.Select(c => c.Name).ToList());
                        }
                        entities = entities.Where(x => citiNames.Contains(x.City));
                    }

                    if (search.Cities != null || search.CityName != null)
                    {
                            entities = entities.Where(x => search.CityName.Contains(x.City));
                    }
                    if (search.AnnouncementAdditionId != null)
                    {
                        entities = entities
                            .Where(x => x.AnnouncementAddition.Contains(search.AnnouncementAdditionId));
                    }
                    if (search.announcementtype.HasValue)
                        entities = entities.Where(x => x.AnnouncementTypeId == search.announcementtype);
                    if (search.PropertyTypes.HasValue)
                        entities = entities.Where(x => x.PropertyTypeId == search.PropertyTypes);
                    if (search.minprice.HasValue)
                        entities = entities.Where(e => e.PriceDouble >= search.minprice.Value);
                    if (search.maxprice.HasValue)
                        entities = entities.Where(e => e.PriceDouble <= search.maxprice.Value);
                    if (search.minarea.HasValue)
                        entities = entities.Where(e => e.Area >= search.minarea.Value);
                    if (search.maxarea.HasValue)
                        entities = entities.Where(e => e.Area <= search.maxarea.Value);
                    if (search.minroomcount.HasValue)
                        entities = entities.Where(e => e.RoomCount >= search.minroomcount.Value);
                    if (search.maxroomcount.HasValue)
                        entities = entities.Where(e => e.RoomCount <= search.maxroomcount.Value);
                    result = entities.Count();

                    return ActionResponse<int>.Succeed(result);
                }
                else
                    return ActionResponse<int>.Succeed(result);


            }
            catch (Exception ex)
            {
                return ActionResponse<int>.Failure(ex.Message);
            }
        }

        public override ActionResponse<IQueryable<GenericAnnouncementDto>> GetAll(params Enums.Status[] statuses)
        {
            try
            {
                var ctx = new MainDataContext();
                //40 
                const string query = "SELECT * FROM dbo.RANDOM_ANNOUNCEMENTS ORDER BY NEWID()";
                var entities = ctx.Database.SqlQuery<GenericAnnouncementDao>(query).ToArray();
                var result = entities.Select(ToDTO).AsQueryable();
                return ActionResponse<IQueryable<GenericAnnouncementDto>>.Succeed(result);


            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<GenericAnnouncementDto>>.Failure(ex.Message);
            }
        }
        public ActionResponse<GenericAnnouncementDto> GetById(Guid id, params Enums.Status[] statuses)
        {
            try
            {
                var ctx = new MainDataContext();

                var dao = ctx.Set<GenericAnnouncementDao>().FirstOrDefault(e => e.Id == id);
                var dto = ToDTO(dao);
                return ActionResponse<GenericAnnouncementDto>.Succeed(dto);


            }
            catch (Exception ex)
            {
                return ActionResponse<GenericAnnouncementDto>.Failure(ex.Message);
            }
        }

        private static GenericAnnouncementDto ToDTO(GenericAnnouncementDao dao)
        {
            var dto = new GenericAnnouncementDto()
            {
                Id = dao.Id,
                category_id = dao.Category_Id,
                Title = dao.Title,
                Description = dao.Description,
                City = dao.City,
                Region = dao.Region,
                HostSite = dao.HostSite,
                LinkText = dao.LinkText,
                LinkUrl = dao.LinkUrl,
                first_publication_date = dao.First_Publication_Date,

                //TODO bulari ver
            };
            if (!string.IsNullOrEmpty(dao.Images)) dto.Images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.Images);
            if (!string.IsNullOrEmpty(dao.ThumbImages)) dto.ThumbImages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.ThumbImages);
            if (!string.IsNullOrEmpty(dao.SmallImages)) dto.SmallImages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.SmallImages);
            if (!string.IsNullOrEmpty(dao.LargeUrls)) dto.LargeUrls = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.LargeUrls);
            dto.Price = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.Price);
            //dto.Extra = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(dao.Extra);


            return dto;
        }
        public override ActionResponse Save(GenericAnnouncementDto obj, Guid? userId = null)
        {
            throw new Exception("Olmaz");
        }

        public ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Enums.Status[] statuses)
        {
            try
            {
                using (var ctx = new MainDataContext())
                {
                    var data = ctx.GenericAnnouncements.GroupBy(e => e.City)
                        .Select(e => new { name = e.Key, count = e.Count() }).ToList()
                        .Select(e => Tuple.Create<string, int>(e.name, e.count))
                        .Where(e => e.Item2 > 150).AsQueryable();

                    return ActionResponse<IQueryable<Tuple<string, int>>>.Succeed(data);
                }

            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<Tuple<string, int>>>.Failure(ex.Message);
            }
        }
    }
}
