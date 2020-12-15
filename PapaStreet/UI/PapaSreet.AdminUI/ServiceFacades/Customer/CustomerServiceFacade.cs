using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class CustomerServiceFacade : BaseServiceFacade, IBaseServiceFacade<CustomerDto>
    {
        private readonly CustomerService _customerService;

        public CustomerServiceFacade(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IQueryable<CustomerDto> GetAll(params Status[] statuses)
        {
            var response = _customerService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<CustomerDto>().AsQueryable();
        }

        public CustomerDto GetById(Guid id)
        {
            var response = _customerService.GetAll();
            if (response.IsSucceed)
            {
                var dto = response.Data.FirstOrDefault(x => x.Id == id);
                if (dto == null)
                    return new CustomerDto();
                return dto;
            }
            return new CustomerDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _customerService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(CustomerDto obj)
        {
            var response = new SiteResponse();
            var command = _customerService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse ResetPassword(string email, string newPassword, params Status[] statuses)
        {
            var response = new SiteResponse();
            var command = _customerService.ResetPassword(email, newPassword, statuses);
            SetResponse(command, ref response);
            return response;
        }
    }
}