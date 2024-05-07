using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Bu alan 2 karakterden fazla olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Bu alan 50 karakterden fazla olmamalı");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyaadı boş bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanı boş bırakılamaz");    
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Bu alan 100 karakterden fazla olmamalı");
            RuleFor(x => x.WriterAbout).MinimumLength(3).WithMessage("Bu alan 3 karakterden az olmamalı");
        }
    }
}
