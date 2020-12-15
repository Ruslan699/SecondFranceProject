﻿using PapaStreet.BLL.DTOs;
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
    public class PhoneNumberService : IBaseService<PhoneNumberDto>
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }
        public ActionResponse<IQueryable<PhoneNumberDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _phoneNumberRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<PhoneNumberDto> GetById(Guid id)
        {
            var response = _phoneNumberRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _phoneNumberRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(PhoneNumberDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new PhoneNumberValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _phoneNumberRepository.Save(obj);
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
