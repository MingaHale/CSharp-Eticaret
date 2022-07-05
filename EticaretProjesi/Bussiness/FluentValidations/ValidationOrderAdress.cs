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
    internal class ValidationOrderAdress : AbstractValidator<OrderAddress>
    {
        public ValidationOrderAdress()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.City).Must(HarfKontrol).MaximumLength(30).WithMessage("Sadece Harf ve Maksimum 30 Karakter Girilebilir");

            RuleFor(x => x.Distrinct).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Distrinct).Must(HarfKontrol).MaximumLength(40).WithMessage("Sadece Harf ve Maksimum 40 Karakter Girilebilir");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Maksimum 15 karakter girilebilir");

            RuleFor(x => x.FullAddress).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            RuleFor(x => x.FullAddress).MaximumLength(500).WithMessage("Maksimum 500 karakter girilebilir");

        }
        public bool HarfKontrol(string data)
        {
            Regex SadeceHarf = new Regex(@"^[a-zA-Z]*$");
            return SadeceHarf.IsMatch(data);
        }

    }

}
