using BP.Api.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Validations
{
    public class ContactValidator: AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(i => i.FullName).NotEmpty().WithMessage("İsim Soyisim Boş Olamaz");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100 den büyük olamaz");
        }
    }
}
