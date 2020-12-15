using AutoMapper;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class GenericAnnouncementServiceFacade : BaseServiceFacade, IBaseServiceFacade<GenericAnnouncementDto>
    {
        private readonly GenericAnnouncementService _genericAnnouncementService;
        public GenericAnnouncementServiceFacade( GenericAnnouncementService genericAnnouncementService)
        {
            _genericAnnouncementService = genericAnnouncementService;
        }
        public IQueryable<GenericAnnouncementDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _genericAnnouncementService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<GenericAnnouncementDto>().AsQueryable();
        }

        public GenericAnnouncementDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _genericAnnouncementService.GetById(id, statuses);
            if (all.IsSucceed)
                return all.Data;
            return new GenericAnnouncementDto();
        }

        public IQueryable<Tuple<string, int>> GetTopCities(params Enums.Status[] statuses)
        {
            var all = _genericAnnouncementService.GetTopCities(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<Tuple<string, int>>().AsQueryable();
        }

        public IQueryable<GenericAnnouncementDto> SearchPagerSortBy(Search search, int currentPage, int pageSize)
        {
            var searchDto = Mapper.Map<SearchDto>(search);
            var all = _genericAnnouncementService.SearchPagerSortBy(searchDto, currentPage, pageSize);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<GenericAnnouncementDto>().AsQueryable();
        }


        public int SearchPagerSortByCount(Search search)
        {
            var searchDto = Mapper.Map<SearchDto>(search);
            var count = _genericAnnouncementService.SearchPagerSortByCount(searchDto);
            if(count.IsSucceed)
                return count.Data;
            return Enumerable.Empty<int>().AsQueryable().Count();

        }

        public SiteResponse Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public SiteResponse Save(GenericAnnouncementDto obj)
        {
            throw new NotImplementedException();
        }
    }
}