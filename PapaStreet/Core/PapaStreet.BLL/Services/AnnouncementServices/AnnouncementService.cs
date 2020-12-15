using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.Services
{
    public class AnnouncementService : IBaseService<AnnouncementDto>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IAnnouncementTypeRepository  _announcementTypeRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IRepairRepository _repairRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository,
            IAnnouncementTypeRepository announcementTypeRepository,
            IPropertyTypeRepository propertyTypeRepository,
            ICityRepository cityRepository,
            IDepartamentRepository departamentRepository,
            IRepairRepository repairRepository,
            IDocumentTypeRepository documentTypeRepository
            )
        {
            _announcementRepository = announcementRepository;
            _announcementTypeRepository = announcementTypeRepository;
            _propertyTypeRepository = propertyTypeRepository;
            _cityRepository = cityRepository;
            _departamentRepository = departamentRepository;
            _repairRepository = repairRepository;
            _documentTypeRepository = documentTypeRepository;
        }
        public ActionResponse<IQueryable<AnnouncementDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _announcementRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<AnnouncementDto> GetById(Guid id)
        {
            var response = _announcementRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _announcementRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(AnnouncementDto obj, Guid? userId = null)
        {
            try
            {
                string announcetypename = _announcementTypeRepository.GetById(obj.AnnouncementTypeId).Data.Name;
                string propertytypename = _propertyTypeRepository.GetById(obj.PropertyTypeId).Data.Name;
                string cityname = _cityRepository.GetById(obj.CityId).Data.Name;
                obj.RepairId = _repairRepository.GetAll().Data.FirstOrDefault().Id;
                obj.DocumentTypeId = _documentTypeRepository.GetAll().Data.FirstOrDefault().Id;
                obj.Title = announcetypename + " " + obj.RoomCount + " " + UI.RoomCount +
                    " " + obj.Area + " m<sup>2</sup> " + propertytypename + ", " + cityname;
                var valResult = new AnnouncementValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _announcementRepository.Save(obj);
                    return response;
                }
                else
                {
                    var valErrors = valResult.Errors.Select(e => e.ErrorMessage).ToArray();
                    return ActionResponse.Failure(valErrors);
                }

            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        public ActionResponse IncViewsCount(Guid id)
        {
            try
            {
                    var response = _announcementRepository.IncViewsCount(id);
                    return response;
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        public ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Status[] statuses) 
            => _announcementRepository.GetTopCities(statuses);
    }
}
