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
    public class AnnouncementImageService : IBaseService<AnnouncementImageDto>
    {
        private readonly IAnnouncementImageRepository _announcementImageRepository;

        public AnnouncementImageService(IAnnouncementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }
        public ActionResponse<IQueryable<AnnouncementImageDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _announcementImageRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<AnnouncementImageDto> GetById(Guid id)
        {
            var response = _announcementImageRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _announcementImageRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(AnnouncementImageDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new AnnouncementImageValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _announcementImageRepository.Save(obj);
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
