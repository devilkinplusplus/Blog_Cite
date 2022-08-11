using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class WriterValidator :AbstractValidator<WriterWithPP>
    {
        public WriterValidator()
        {
            //AD
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad boş qala bilməz");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("Ad maksimum 30 simvol ola biler");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Ad minimum 3 simvol ola biler");
            RuleFor(x => x.WriterName).Custom((x, context) =>
            {
                if (x != null)
                {
                    foreach (var item in x)
                    {
                        if (char.IsNumber(item))
                        {
                            context.AddFailure("Adda rəqəm ola bilməz");
                            break;
                        }
                    }
                }
            });

            //Mail
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş qala bilmez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Mail adresi yanlışdır");

            //Shifre
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş qala bilmez");
            RuleFor(x => x.WriterPassword).MinimumLength(4).WithMessage("Şifre minimum 4 simvol olmalıdır");
            RuleFor(x => x.WriterPassword).MaximumLength(16).WithMessage("Şifre maksimum 16 simvol olmalıdır");
            RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifrede en az 1 reqem olmalıdır");
            //Image
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Şekil boş qala bilmez");
        }
    }
}
