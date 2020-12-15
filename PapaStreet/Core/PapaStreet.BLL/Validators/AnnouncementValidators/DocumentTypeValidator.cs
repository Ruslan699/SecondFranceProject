using FluentValidation;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.BLL.Validators
{
    public class DocumentTypeValidator : AbstractValidator<DocumentTypeDto>
    {
        public DocumentTypeValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
        }
    }
}
