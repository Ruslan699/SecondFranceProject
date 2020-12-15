using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class RepairServiceFacade : BaseServiceFacade, IBaseServiceFacade<RepairDto>
    {
        private readonly RepairService _repairService;
        public RepairServiceFacade(RepairService repairService)
        {
            _repairService = repairService;
        }

        public IQueryable<RepairDto> GetAll(params Status[] statuses)
        {
            var response = _repairService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<RepairDto>().AsQueryable();
        }

        public RepairDto GetById(Guid id)
        {
            var dto = _repairService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
            return new RepairDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _repairService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(RepairDto obj)
        {
            var response = new SiteResponse();
            var command = _repairService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}