using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Validators;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.Services
{
    public class CustomerService : IBaseService<CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ActionResponse<IQueryable<CustomerDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _customerRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<CustomerDto> GetById(Guid id)
        {
            var response = _customerRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _customerRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(CustomerDto obj, Guid? userId = null)
        {
            try
            {
                if (obj.Password == null)
                {
                    var c = _customerRepository.GetById(obj.Id);
                    obj.Password = c.Data.Password;
                }
                var valResult = new CustomerValidator().Validate(obj);
                if (valResult.IsValid)
                {
                    var customer = _customerRepository.GetById(obj.Id);
                    obj.Email = customer.Data.Email;
                    var response = _customerRepository.Save(obj);
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

        public ActionResponse<CustomerDto> Login(string email, string password)
        {
            try
            {
                var customers = _customerRepository.GetAll(Status.Active);
                if (customers.IsSucceed)
                {
                    var customer = customers.Data.FirstOrDefault(e => e.Email == email);
                    if (customer == null)
                        return ActionResponse<CustomerDto>.Failure(UI.CustomerNotFound);
                    var verify = HashHelper.Verify(customer.Password, password);
                    if (!verify)
                        return ActionResponse<CustomerDto>.Failure(UI.PasswordIsIncorrect);

                    return ActionResponse<CustomerDto>.Succeed(customer);
                }
                else return ActionResponse<CustomerDto>.Failure(string.Join(", ", customers.FailureResult));
            }
            catch (Exception ex)
            {
                return ActionResponse<CustomerDto>.Failure(ex.Message);
            }
        }

        public ActionResponse Register(CustomerDto customerDto, Guid? userId = null)
        {
            try
            {
                var customers = _customerRepository.GetAll();
                if (customers.IsSucceed)
                {
                    var email = customerDto.Email;
                    var customer = customers.Data.FirstOrDefault(e => e.Email == email);
                    if (customer != null)
                        return ActionResponse<CustomerDto>.Failure(UI.EmailAlreadyExists);
                    customerDto.Password = HashHelper.ComputeHash(customerDto.Password);
                    var save =  _customerRepository.Save(customerDto, userId);
                    if (!save.IsSucceed)
                        return ActionResponse<CustomerDto>.Failure(save.FailureResult);
                    return ActionResponse.Succeed();
                }
                else return ActionResponse<CustomerDto>.Failure(string.Join(", ", customers.FailureResult));
            }
            catch (Exception ex)
            {
                return ActionResponse<CustomerDto>.Failure(ex.Message);
            }
        }

        public ActionResponse ResetPassword(string email, string newPassword, params Status[] statuses)
        {
            try
            {
                var all = _customerRepository.GetAll(statuses);
                if (all.IsSucceed)
                {
                    var customer = all.Data.FirstOrDefault(e => e.Email == email);
                    if (customer != null)
                    {
                        customer.Password = HashHelper.ComputeHash(newPassword);
                        return _customerRepository.Save(customer);
                    }
                    else return ActionResponse.Failure(UI.CustomerNotFound);
                }
                else return ActionResponse.Failure(all.FailureResult);
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}
