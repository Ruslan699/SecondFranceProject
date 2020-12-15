using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class AnnouncementServiceFacade : BaseServiceFacade, IBaseServiceFacade<AnnouncementDto>
    {
        private readonly AnnouncementService _announcementService;
        private readonly RegionDepartamentService _regionDepartamentService;
        private readonly DepartamentCityService _departamentCityService;
        private readonly CityService _cityService;

        public AnnouncementServiceFacade(AnnouncementService announcementService,
            RegionDepartamentService regionDepartamentService,
            DepartamentCityService departamentCityService,
            CityService cityService)
        {
            _announcementService = announcementService;
            _regionDepartamentService = regionDepartamentService;
            _departamentCityService = departamentCityService;
            _cityService = cityService;
        }

        public IQueryable<AnnouncementDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _announcementService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.Where(x => x.SourceType == 0);
            return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public IQueryable<AnnouncementDto> GetAllOther(params Enums.Status[] statuses)
        {
            var all = _announcementService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.Where(x => x.SourceType == SourceType.Other).Take(30);
            return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public IQueryable<Tuple<string, int>> GetTopCities(params Enums.Status[] statuses)
        {
            var all = _announcementService.GetTopCities(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<Tuple<string, int>>().AsQueryable();
        }

        public IQueryable<AnnouncementDto> GetAll(int pageNo, int pageSize, string Email, params Enums.Status[] statuses)
        {
            var result = _announcementService.GetAll(statuses);
            if (result.IsSucceed)
                return result.Data.Where(x => x.SourceType == 0 && x.Email == Email).OrderByDescending(x => x.CreatedDate).Skip((pageNo - 1) * pageSize).Take(pageSize);
            return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public AnnouncementDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _announcementService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
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
            obj.Status = Status.Pending;
            var command = _announcementService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }

        public void SendConfirmation(string email, string link, string subject, Guid announceId)
        {
            var body = string.Format(UI.MailConfirmText, subject, announceId, string.Format(link, announceId));
            MailHelper.SendEmail(email, subject, body);
        }

        public SiteResponse IncViewsCount(Guid id)
        {
            var response = new SiteResponse();
            var command = _announcementService.IncViewsCount(id);
            SetResponse(command, ref response);
            return response;
        }


        public IQueryable<AnnouncementDto> PagerSortBy(int? sortBy, int currentPage, int pageSize)
        {
            var announcements = _announcementService.GetAll(Status.Active);
            if (announcements.IsSucceed)
            {
                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 1:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                            break;
                        case 2:
                            announcements.Data = announcements.Data.OrderBy(s => s.Area);
                            break;
                        case 3:
                            announcements.Data = announcements.Data.OrderBy(s => s.Amount);
                            break;
                        case 4:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.Amount);
                            break;
                        default:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                            break;
                    }
                }
                else
                    announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                return announcements.Data.Where(x => x.SourceType == SourceType.Default).Skip((currentPage - 1) * pageSize).Take(pageSize);
            }

            else return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }

        public IQueryable<AnnouncementDto> SearchPagerSortBy(Search search, int currentPage, int pageSize)
        {
            var announcements = _announcementService.GetAll(Status.Active);
            if (announcements.IsSucceed)
            {
                List<Guid> citiIds = new List<Guid>();
                //if (search.Regions.HasValue && !search.Departaments.HasValue)
                //{
                    
                //    var departaments = _regionDepartamentService.GetAll(Status.Active).Data.Where(x => x.RegionId == search.Regions.Value);
                //    foreach (var departament in departaments)
                //    {
                //        var cities = _departamentCityService.GetAll(Status.Active).Data.Where(x => x.DepartamentId == departament.DepartamentId);
                //        citiIds.AddRange(cities.Select(c => c.CityId).ToList());
                //    }
                //    announcements.Data = announcements.Data.Where(x => citiIds.Contains(x.CityId));
                //}
                if (search.Departaments.HasValue && search.Cities==null)
                {
                    var cities = _departamentCityService.GetAll(Status.Active).Data.Where(x => x.DepartamentId == search.Departaments.Value);
                    citiIds.AddRange(cities.Select(c => c.CityId).ToList());
                    announcements.Data = announcements.Data.Where(x => citiIds.Contains(x.CityId));
                }
                if (search.announcementtype.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.AnnouncementTypeId == search.announcementtype);
                if (search.PropertyTypes.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.PropertyTypeId == search.PropertyTypes);
                //if (search.repair.HasValue)
                //    announcements.Data = announcements.Data.Where(x => x.RepairId == search.repair);

                if (search.Cities != null && search.CityName != null)
                {
                        announcements.Data = announcements.Data.Where(x => search.Cities.Contains(x.CityId));
                }
                if (search.CityName != null && search.Cities == null)
                {
                    var cityId = _cityService.GetAll(Status.Active).Data.FirstOrDefault(x => x.Name == search.CityName.FirstOrDefault())?.Id;
                    announcements.Data = announcements.Data.Where(x => x.CityId == cityId);
                }
                if (search.AnnouncementAdditionId != null)
                {
                    announcements.Data = announcements.Data
                        .Where(x => x.AnnouncementAddition.Contains(search.AnnouncementAdditionId));
                }
                if (search.minroomcount.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.RoomCount >= search.minroomcount.Value);
                if (search.maxroomcount.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.RoomCount <= search.maxroomcount.Value);
                if (search.minarea.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Area >= search.minarea.Value);
                if (search.maxarea.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Area <= search.maxarea.Value);
                if (search.minprice.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Amount >= search.minprice.Value);
                if (search.maxprice.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Amount <= search.maxprice.Value);
                if (search.sortBy.HasValue)
                {
                    switch (search.sortBy)
                    {
                        case 1:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                            break;
                        case 2:
                            announcements.Data = announcements.Data.OrderBy(s => s.Area);
                            break;
                        case 3:
                            announcements.Data = announcements.Data.OrderBy(s => s.Amount);
                            break;
                        case 4:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.Amount);
                            break;
                        default:
                            announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                            break;
                    }
                }
                else
                    announcements.Data = announcements.Data.OrderByDescending(s => s.CreatedDate);
                return announcements.Data.Where(x => x.SourceType == SourceType.Default).Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
            else return Enumerable.Empty<AnnouncementDto>().AsQueryable();
        }


        public int SearchPagerSortByCount(Search search)
        {
            var announcements = _announcementService.GetAll(Status.Active);
            if (announcements.IsSucceed)
            {
                List<Guid> citiIds = new List<Guid>();
                //if (search.Regions.HasValue && !search.Departaments.HasValue)
                //{

                //    var departaments = _regionDepartamentService.GetAll(Status.Active).Data.Where(x => x.RegionId == search.Regions.Value);
                //    foreach (var departament in departaments)
                //    {
                //        var cities = _departamentCityService.GetAll(Status.Active).Data.Where(x => x.DepartamentId == departament.DepartamentId);
                //        citiIds.AddRange(cities.Select(c => c.CityId).ToList());
                //    }
                //    announcements.Data = announcements.Data.Where(x => citiIds.Contains(x.CityId));
                //}
                if (search.Departaments.HasValue)
                {
                    var cities = _departamentCityService.GetAll(Status.Active).Data.Where(x => x.DepartamentId == search.Departaments.Value);
                    citiIds.AddRange(cities.Select(c => c.CityId).ToList());
                    announcements.Data = announcements.Data.Where(x => citiIds.Contains(x.CityId));
                }
                if (search.announcementtype.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.AnnouncementTypeId == search.announcementtype);
                if (search.PropertyTypes.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.PropertyTypeId == search.PropertyTypes);
                //if (search.repair.HasValue)
                //    announcements.Data = announcements.Data.Where(x => x.RepairId == search.repair);
                if (search.Cities != null && search.CityName != null)
                {
                    announcements.Data = announcements.Data.Where(x => search.Cities.Contains(x.CityId));
                }
                if (search.CityName != null && search.Cities == null)
                {
                    var cityId = _cityService.GetAll(Status.Active).Data.FirstOrDefault(x => x.Name == search.CityName.FirstOrDefault())?.Id;
                    announcements.Data = announcements.Data.Where(x => x.CityId == cityId);
                }
                if (search.AnnouncementAdditionId != null)
                {
                    announcements.Data = announcements.Data
                        .Where(x => x.AnnouncementAddition.Contains(search.AnnouncementAdditionId));
                }
                if (search.minroomcount.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.RoomCount >= search.minroomcount.Value);
                if (search.maxroomcount.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.RoomCount <= search.maxroomcount.Value);
                if (search.minarea.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Area >= search.minarea.Value);
                if (search.maxarea.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Area <= search.maxarea.Value);
                if (search.minprice.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Amount >= search.minprice.Value);
                if (search.maxprice.HasValue)
                    announcements.Data = announcements.Data.Where(x => x.Amount <= search.maxprice.Value);

                return announcements.Data.Where(x => x.SourceType == SourceType.Default).Count();
            }

            return Enumerable.Empty<AnnouncementDto>().AsQueryable().Count();
        }

    }
}