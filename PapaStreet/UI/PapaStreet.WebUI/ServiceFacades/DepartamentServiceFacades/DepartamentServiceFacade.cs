using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class DepartamentServiceFacade : BaseServiceFacade, IBaseServiceFacade<DepartamentDto>
    {
        private readonly DepartamentService _departamentService;
        public DepartamentServiceFacade(DepartamentService departamentService)
        {
            _departamentService = departamentService;
        }
        public IQueryable<DepartamentDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _departamentService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<DepartamentDto>().AsQueryable();
        }

        public DepartamentDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _departamentService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new DepartamentDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _departamentService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(DepartamentDto obj)
        {
            var response = new SiteResponse();
            var command = _departamentService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}