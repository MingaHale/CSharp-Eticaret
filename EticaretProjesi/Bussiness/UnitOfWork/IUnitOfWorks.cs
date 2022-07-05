using Bussiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.UnitOfWork
{
    public interface IUnitOfWorks
    {
        public ICategoriesService CategoriesService { get; }
        public ICustomerService CustomerService { get; }
        public IOrderAddressService OrderAddressService { get; }
        public IOrderDetailsService OrderDetailsService { get; }
        public IOrdersService OrdersService { get; }
        public IProductsImagesService ProductsImagesService { get; }
        public IProductsService ProductsService { get; }
        public ITemporaryService TemporaryService { get; }
       
    }
}
