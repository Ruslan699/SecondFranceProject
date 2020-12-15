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
    public class FrequencyService : IBaseService<FrequencyDto>
    {
        private readonly IFrequencyRepository _frequencyRepository;
        public FrequencyService(IFrequencyRepository frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;
        }
        public ActionResponse<IQueryable<FrequencyDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _frequencyRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<FrequencyDto> GetById(Guid id)
        {
            var response = _frequencyRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _frequencyRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(FrequencyDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new FrequencyValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _frequencyRepository.Save(obj);
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
