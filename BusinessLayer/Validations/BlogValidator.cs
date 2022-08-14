using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class BlogValidator:AbstractValidator<BlogWithImg>
    {
        public BlogValidator()
        {
            //Title
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlıq məcburidir");
            RuleFor(x => x.BlogTitle).MaximumLength(75).WithMessage("Karakter limitini keçdiniz");

            //Content
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Yazınız görünmür");
            RuleFor(x => x.BlogContent).MaximumLength(255).WithMessage("Karakter limitini keçdiniz");

            //Image
            //RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Şəkil lazımdır");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kateqoriya seçin");
        }
    }
}
