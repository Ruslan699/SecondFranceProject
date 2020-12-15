using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Services;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.ServiceFacades
{
    public class DocumentTypeServiceFacade : BaseServiceFacade, IBaseServiceFacade<DocumentTypeDto>
    {
        private readonly DocumentTypeService _documentTypeService;

        public DocumentTypeServiceFacade(DocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        public IQueryable<DocumentTypeDto> GetAll(params Status[] statuses)
        {
            var response = _documentTypeService.GetAll(statuses);
            if (response.IsSucceed)
                return response.Data;
            return Enumerable.Empty<DocumentTypeDto>().AsQueryable();
        }

        public DocumentTypeDto GetById(Guid id)
        {
            var dto = _documentTypeService.GetById(id);
            if (dto.IsSucceed)
                return dto.Data;
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