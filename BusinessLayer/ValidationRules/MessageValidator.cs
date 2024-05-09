using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş bırakılamaz").EmailAddress().WithMessage("Geçersiz E-Posta Adresi");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden az olamaz.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu 100 karakterden fazla olamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İçerik boş bırakılamaz");
        }
    }
}
