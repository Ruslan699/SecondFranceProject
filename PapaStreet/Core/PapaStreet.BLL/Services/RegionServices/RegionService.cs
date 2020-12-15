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
    public class RegionService : IBaseService<RegionDto>
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public ActionResponse<IQueryable<RegionDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _regionRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<RegionDto> GetById(Guid id)
        {
            var response = _regionRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _regionRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(RegionDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new RegionValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _regionRepository.Save(obj);
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
