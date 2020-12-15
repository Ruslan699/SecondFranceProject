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
    public class CustomerPhoneServiceFacade : BaseServiceFacade, IBaseServiceFacade<CustomerPhoneNumberDto>
    {
        private readonly CustomerPhoneNumberService _customerPhoneNumberService;

        public CustomerPhoneServiceFacade(CustomerPhoneNumberService customerPhoneNumberService)
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

        public CustomerPhoneNumberDto GetById(Guid id)
        {
            var dto = _customerPhoneNumberService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new CustomerPhoneNumberDto();
            //var response = _customerPhoneNumberService.GetAll();
            //if (response.IsSucceed)
            //{
            //    var dto = response.Data.FirstOrDefault(x => x.Id == id);
            //    if (dto == null)
            //        return new CustomerPhoneNumberDto();
            //    return dto;
            //}
            //return new CustomerPhoneNumberDto();
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