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
    public class CustomerPhoneNumberService : IBaseService<CustomerPhoneNumberDto>
    {
        private readonly ICustomerPhoneNumberRepository _customerPhoneNumberRepository;

        public CustomerPhoneNumberService(ICustomerPhoneNumberRepository customerPhoneNumberRepository)
        {
            _customerPhoneNumberRepository = customerPhoneNumberRepository;
        }
        public ActionResponse<IQueryable<CustomerPhoneNumberDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _customerPhoneNumberRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<CustomerPhoneNumberDto> GetById(Guid id)
        {
            var response = _customerPhoneNumberRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _customerPhoneNumberRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(CustomerPhoneNumberDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new CustomerPhoneNumberValidator().Validate(obj);
                if (valResult.IsValid)
                {
                    var response = _customerPhoneNumberRepository.Save(obj);
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
