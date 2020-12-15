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
    public class DocumentTypeService : IBaseService<DocumentTypeDto>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }
        public ActionResponse<IQueryable<DocumentTypeDto>> GetAll(params Enums.Status[] statuses)
        {
            var response = _documentTypeRepository.GetAll(statuses);
            return response;
        }

        public ActionResponse<DocumentTypeDto> GetById(Guid id)
        {
            var response = _documentTypeRepository.GetById(id);
            return response;
        }

        public ActionResponse Remove(Guid id, Guid? userId = null)
        {
            var response = _documentTypeRepository.Remove(id);
            return response;
        }

        public ActionResponse Save(DocumentTypeDto obj, Guid? userId = null)
        {
            try
            {
                var valResult = new DocumentTypeValidator().Validate(obj);
                if (valResult.IsValid)
                {

                    var response = _documentTypeRepository.Save(obj);
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
