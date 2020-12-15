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
    public class DepartamentService : IBaseService<DepartamentDto>
    {
        private readonly IDepartamentRepository _departamentRepository;
        public DepartamentService(IDepartamentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }
        public ActionResponse<IQueryable<DepartamentDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _departamentRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<DepartamentDto> GetById(Guid id)
        {
            var response = _departamentRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _departamentRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(DepartamentDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new DepartamentValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _departamentRepository.Save(obj);
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
