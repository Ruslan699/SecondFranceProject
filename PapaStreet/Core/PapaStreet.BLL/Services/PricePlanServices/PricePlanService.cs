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
    public class PricePlanService : IBaseService<PricePlanDto>
    {
        private readonly IPricePlanRepository _pricePlanRepository;
        public PricePlanService(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepository = pricePlanRepository;
        }
        public ActionResponse<IQueryable<PricePlanDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _pricePlanRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<PricePlanDto> GetById(Guid id)
        {
            var response = _pricePlanRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _pricePlanRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(PricePlanDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new PricePlanValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _pricePlanRepository.Save(obj);
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
