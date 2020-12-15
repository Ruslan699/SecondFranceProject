using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class CustomerPhoneNumberServiceFacade : BaseServiceFacade, IBaseServiceFacade<CustomerPhoneNumberDto>
    {
        private readonly CustomerPhoneNumberService _customerPhoneNumberService;

        public CustomerPhoneNumberServiceFacade(CustomerPhoneNumberService customerPhoneNumberService)
        {
            _customerPhoneNumberService = customerPhoneNumberService;
        }

        public IQueryable<CustomerPhoneNumberDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _customerPhoneNumberService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<CustomerPhoneNumberDto>().AsQueryable();
        }

        public CustomerPhoneNumberDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _customerPhoneNumberService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new CustomerPhoneNumberDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _customerPhoneNumberService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(CustomerPhoneNumberDto obj)
        {
            var response = new SiteResponse();
            var command = _customerPhoneNumberService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}