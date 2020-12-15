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
    public class CityService : IBaseService<CityDto>
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public ActionResponse<IQueryable<CityDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _cityRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<CityDto> GetById(Guid id)
        {
            var response = _cityRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _cityRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(CityDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new CityValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _cityRepository.Save(obj);
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
