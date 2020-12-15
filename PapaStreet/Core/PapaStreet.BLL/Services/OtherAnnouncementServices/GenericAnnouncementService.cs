using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Services
{
    public class GenericAnnouncementService : IBaseService<GenericAnnouncementDto>
    {
        private readonly IGenericAnnouncementRepository _genericAnnouncementRepository;
        public GenericAnnouncementService(IGenericAnnouncementRepository genericAnnouncementRepository )
        {
            _genericAnnouncementRepository = genericAnnouncementRepository;
        }

        public ActionResponse<IQueryable<GenericAnnouncementDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _genericAnnouncementRepository.GetAll(statuses);
            return response;
        }
        public ActionResponse<IQueryable<GenericAnnouncementDto>> GetAll_old(params Enums.Status[] statuses)
        {
            var response = _genericAnnouncementRepository.GetAll_Old(statuses);
            return response;
        }

        public ActionResponse<IQueryable<GenericAnnouncementDto>> SearchPagerSortBy(SearchDto search, int currentPage, int pageSize, params Enums.Status[] statuses)
        {
            var response = _genericAnnouncementRepository.SearchPagerSortBy(search,currentPage,pageSize, statuses);
            return response;
        }

        public ActionResponse<int> SearchPagerSortByCount(SearchDto search, params Enums.Status[] statuses)
        {
            var response = _genericAnnouncementRepository.SearchPagerSortByCount(search, statuses);
            return response;
        }

        public ActionResponse<GenericAnnouncementDto> GetById(Guid id, params Enums.Status[] statuses)
        {
            var response = _genericAnnouncementRepository.GetById(id,statuses);
            return response;
        }

        public ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Enums.Status[] statuses)
            => _genericAnnouncementRepository.GetTopCities(statuses);

        public ActionResponse<GenericAnnouncementDto> GetById(Guid id)
        {
            var response = _genericAnnouncementRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _genericAnnouncementRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(GenericAnnouncementDto obj, Guid? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}
