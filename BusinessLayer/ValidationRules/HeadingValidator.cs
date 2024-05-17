using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz");
            RuleFor(x => x.HeadingName).MinimumLength(10).WithMessage("Başlık alanı 10 karakterden az olamaz.");
            RuleFor(x => x.HeadingName).MaximumLength(30).WithMessage("Başlık alanı 30 karakterden fazla olmamalı");
        }
    }
}
