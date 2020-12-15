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
    public class RegionDepartamentService : IBaseService<RegionDepartamentDto>
    {
        private readonly IRegionDepartamentRepository _regionDepartamentRepository;
        public RegionDepartamentService(IRegionDepartamentRepository regionDepartamentRepository)
        {
            _regionDepartamentRepository = regionDepartamentRepository;
        }
        public ActionResponse<IQueryable<RegionDepartamentDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _regionDepartamentRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<RegionDepartamentDto> GetById(Guid id)
        {
            var response = _regionDepartamentRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _regionDepartamentRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(RegionDepartamentDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new RegionDepartamentValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _regionDepartamentRepository.Save(obj);
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
