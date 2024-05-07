using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Bu alan 50 karakterden fazla olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Bu alan 3 karakter veya daha fazla olmalıdır.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
