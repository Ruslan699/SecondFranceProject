using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Services
{
    public class AnnouncementTypeService : IBaseService<AnnouncementTypeDto>
    {
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;

        public AnnouncementTypeService(IAnnouncementTypeRepository announcementTypeRepository)
        {
            _announcementTypeRepository = announcementTypeRepository;
        }
        public ActionResponse<IQueryable<AnnouncementTypeDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _announcementTypeRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<AnnouncementTypeDto> GetById(Guid id)
        {
            var response = _announcementTypeRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _announcementTypeRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(AnnouncementTypeDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new AnnouncementTypeValidator().Validate(obj);
                if (valResult.IsValid)
                {
                    var response = _announcementTypeRepository.Save(obj);
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
