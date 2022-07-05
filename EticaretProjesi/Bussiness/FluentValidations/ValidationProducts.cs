using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bussiness.FluentValidations
{
    public class ValidationProducts : AbstractValidator<Products>
    {
        public ValidationProducts()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Karakter Sayısını Aştınız(Max 100)");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter giriniz");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.CategoriesId).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.ImagesName).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Discount).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");

            RuleFor(x => x.Stock).Must(SayiKontrol).WithMessage("Lütfen Sayı Giriniz");
        }
        private bool SayiKontrol (int Data)
        {
            Regex Sayi = new Regex(@"^[0-9]*$");
            return Sayi.IsMatch(Data.ToString());
        }
    }
}
