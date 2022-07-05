using Bussiness.Concrete;
using Bussiness.FluentValidations;
using Bussiness.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Extensions
{
    public static class ContainerDependency 
    {
        public static IServiceCollection MyService(this IServiceCollection services)
        {
            services.AddDbContext<EticaretContext>();
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            //Doğrulamalar herkese aynı olduğu için herkese tek bir nesne üzerinden erişim sağlama izni veriyoruz.
            services.AddSingleton<IValidator<Categories>, ValidationCategories>();
            services.AddSingleton<IValidator<Customers>, ValidationCustomers>();
            services.AddSingleton<IValidator<OrderAddress>, ValidationOrderAdress>();
            services.AddSingleton<IValidator<Products>, ValidationProducts>();

            return services;
        }
    }
}
