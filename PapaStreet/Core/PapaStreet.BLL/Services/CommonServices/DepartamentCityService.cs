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
    public class DepartamentCityService : IBaseService<DepartamentCityDto>
    {
        private readonly IDepartamentCityRepository _departamentCityRepository;
        public DepartamentCityService(IDepartamentCityRepository departamentCityRepository)
        {
            _departamentCityRepository = departamentCityRepository;
        }
        public ActionResponse<IQueryable<DepartamentCityDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _departamentCityRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<DepartamentCityDto> GetById(Guid id)
        {
            var response = _departamentCityRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _departamentCityRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(DepartamentCityDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new DepartamentCityValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _departamentCityRepository.Save(obj);
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
