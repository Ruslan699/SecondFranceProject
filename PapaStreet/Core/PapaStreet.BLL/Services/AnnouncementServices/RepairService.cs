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
    public class RepairService : IBaseService<RepairDto>
    {
        private readonly IRepairRepository _repairRepository;

        public RepairService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }
        public ActionResponse<IQueryable<RepairDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _repairRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<RepairDto> GetById(Guid id)
        {
            var response = _repairRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _repairRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(RepairDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new RepairValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _repairRepository.Save(obj);
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
