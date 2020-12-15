using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class FrequencyServiceFacade : BaseServiceFacade, IBaseServiceFacade<FrequencyDto>
    {
        private readonly FrequencyService _frequencyService;
        public FrequencyServiceFacade(FrequencyService frequencyService)
        {
            _frequencyService = frequencyService;
        }
        public IQueryable<FrequencyDto> GetAll(params Enums.Status[] statuses)
        {
            var response = _frequencyService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<FrequencyDto>().AsQueryable();
        }

        public FrequencyDto GetById(Guid id)
        {
            var response = _frequencyService.GetAll();
            if (response.IsSucceed)
            {
                var dto = response.Data.FirstOrDefault(x => x.Id == id);
                if (dto == null)
                    return new FrequencyDto();
                return dto;
            }
            return new FrequencyDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _frequencyService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(FrequencyDto obj)
        {
            var response = new SiteResponse();
            var command = _frequencyService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}