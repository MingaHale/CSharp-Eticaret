using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.FluentValidations
{
    public class ValidationCategories : AbstractValidator <Categories>
    {
        public ValidationCategories()
        {
            //Kullanıcı boş bırakırsa verilecek mesaj.
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Boş Bırakmayınız");
            
            //Karakter sayısı aşılırsa
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Karakter Sayısını Aştınız(Max 50)");

            //Minimum 3
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter giriniz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Boş Bırakılamaz");
        }
    }
}
