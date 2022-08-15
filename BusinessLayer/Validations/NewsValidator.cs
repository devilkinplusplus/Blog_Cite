using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class NewsValidator:AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsMail).NotEmpty().WithMessage("Mail boş buraxıla bilməz");
        }
    }
}
