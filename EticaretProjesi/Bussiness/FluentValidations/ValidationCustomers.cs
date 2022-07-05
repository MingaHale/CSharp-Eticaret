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
    public class ValidationCustomers : AbstractValidator<Customers>
    {
        public ValidationCustomers()
        {
            RuleFor(x => x.NameSurname).MaximumLength(150).WithMessage("Karakter Sayısını Aştınız(Max 150)");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Karakter Sayısını Aştınız(Max 50)");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini doğru girdiğinizden emin olun.");
            RuleFor(x => x.Passwords).Must(Parola).WithMessage("1 Büyük harf, 1 Küçük harf, 1 Sayı, 1 Özel Karakter giriniz.");
            RuleFor(x => x.Passwords).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Passwords).MinimumLength(6).MaximumLength(20).WithMessage("Şifreniz 6 ile 20 karakter arasında olmalıdır.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.AdvertNotice).NotEmpty().WithMessage("Boş Bırakılamaz");
        }

        public bool Parola(string data)
        {
            Regex KisaYol = new Regex(@"^(?=.*[A-Z])(?=.*([+]|[-]|[*]))(?=.*[a-z])(?=.*[0-9])");
            return KisaYol.IsMatch(data);
        }

    }
}
