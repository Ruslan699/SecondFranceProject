using AutoMapper;
using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class CustomerServiceFacade : BaseServiceFacade, IBaseServiceFacade<CustomerDto>
    {
        private readonly CustomerService _customerService;
        public CustomerServiceFacade(CustomerService customerService)
        {
            _customerService = customerService;
        }
        public IQueryable<CustomerDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _customerService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<CustomerDto>().AsQueryable();
        }

        public CustomerDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _customerService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
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

        public SiteResponse Login(CustomerDto obj)
        {
            var response = new SiteResponse();
            var command = _customerService.Login(obj.Email, obj.Password);
            if (command.IsSucceed)
                Identity.Customer = command.Data;
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Register(CustomerDto obj)
        {
            var response = new SiteResponse();
            var command = _customerService.Register(obj);
            if (command.IsSucceed)
                Identity.Customer = obj;
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