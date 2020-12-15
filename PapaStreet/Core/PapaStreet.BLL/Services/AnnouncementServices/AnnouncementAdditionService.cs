using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Linq;

namespace PapaStreet.BLL.Services
{
    public class AnnouncementAdditionService : IBaseService<AnnouncementAdditionDto>
    {
        private readonly IAnnouncementAdditionRepository _announcementAdditionRepository;

        public AnnouncementAdditionService(IAnnouncementAdditionRepository announcementAdditionRepository)
        {
            _announcementAdditionRepository = announcementAdditionRepository;
        }

        public ActionResponse<IQueryable<AnnouncementAdditionDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _announcementAdditionRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<AnnouncementAdditionDto> GetById(Guid id)
        {
            var response = _announcementAdditionRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _announcementAdditionRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(AnnouncementAdditionDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new AnnouncementAdditionValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _announcementAdditionRepository.Save(obj);
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
    }
}
