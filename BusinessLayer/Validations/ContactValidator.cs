using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Ad boş buraxıla bilmez");
            RuleFor(x => x.ContactName).MinimumLength(3).WithMessage("Minimum 3 simvol olmalıdır");
            RuleFor(x => x.ContactName).MaximumLength(16).WithMessage("Maksimum simvol limitini keçdiniz");

            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail boş buraxıla bilmez");
            RuleFor(x => x.ContactMail).EmailAddress().WithMessage("Mail adresi keçərsizdir");

            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Mövzu boş buraxıla bilmez");
            RuleFor(x => x.ContactSubject).MaximumLength(255).WithMessage("Maksimum simvol limitini keçdiniz");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesaj boş buraxıla bilmez");
            RuleFor(x => x.ContactMessage).MaximumLength(255).WithMessage("Maksimum simvol limitini keçdiniz");
        }
    }
}
