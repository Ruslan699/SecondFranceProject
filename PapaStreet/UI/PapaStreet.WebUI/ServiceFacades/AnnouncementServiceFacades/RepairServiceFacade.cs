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
    public class RepairServiceFacade : BaseServiceFacade, IBaseServiceFacade<RepairDto>
    {
        private readonly RepairService _repairService;

        public RepairServiceFacade(RepairService repairService)
        {
            _repairService = repairService;
        }
        public IQueryable<RepairDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _repairService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<RepairDto>().AsQueryable();
        }

        public RepairDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _repairService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
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