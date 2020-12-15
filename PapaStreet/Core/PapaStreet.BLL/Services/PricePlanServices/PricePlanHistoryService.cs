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
    public class PricePlanHistoryService : IBaseService<PricePlanHistoryDto>
    {
        private readonly IPricePlanHistoryRepository _pricePlanHistoryRepository;
        public PricePlanHistoryService(IPricePlanHistoryRepository pricePlanHistoryRepository)
        {
            _pricePlanHistoryRepository = pricePlanHistoryRepository;
        }

        public ActionResponse<IQueryable<PricePlanHistoryDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _pricePlanHistoryRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<PricePlanHistoryDto> GetById(Guid id)
        {
            var response = _pricePlanHistoryRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _pricePlanHistoryRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(PricePlanHistoryDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new PricePlanHIstoryValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _pricePlanHistoryRepository.Save(obj);
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

        public ActionResponse DecUsedAnnouncementCount(Guid id)
        {
            try
            {
                var response = _pricePlanHistoryRepository.DecUsedAnnouncementCount(id);
                return response;
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}
