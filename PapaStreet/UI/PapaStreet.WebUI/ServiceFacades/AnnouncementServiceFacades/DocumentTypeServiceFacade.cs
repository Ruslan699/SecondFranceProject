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
    public class DocumentTypeServiceFacade : BaseServiceFacade, IBaseServiceFacade<DocumentTypeDto>
    {
        private readonly DocumentTypeService _documentTypeService;

        public DocumentTypeServiceFacade(DocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }
        public IQueryable<DocumentTypeDto> GetAll(params Enums.Status[] statuses)
        {
            var all = _documentTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<DocumentTypeDto>().AsQueryable();
        }

        public DocumentTypeDto GetById(Guid id, params Enums.Status[] statuses)
        {
            var all = _documentTypeService.GetAll(statuses);
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(e => e.Id == id);
            return new DocumentTypeDto();
        }

        public SiteResponse Remove(Guid id)
        {
            var response = new SiteResponse();
            var command = _documentTypeService.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(DocumentTypeDto obj)
        {
            var response = new SiteResponse();
            var command = _documentTypeService.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}