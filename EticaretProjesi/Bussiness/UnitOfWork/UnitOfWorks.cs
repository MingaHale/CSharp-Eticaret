using Bussiness.Concrete;

namespace Bussiness.UnitOfWork 
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private CategoriesService ServiceCategories;
        private CustomerService ServiceCustomer;
        private OrderAddressService ServiceOrderAddress;
        private OrderDetailsService ServiceOrderDetails;
        private OrderService ServiceOrder;
        private ProductsImagesService ServiceProductsImages;
        private ProductsService ServiceProducts;
        private TemporaryService ServiceTemporary;
        private readonly EticaretContext context;

        public ICategoriesService CategoriesService => ServiceCategories ?? new CategoriesService(context);

        public ICustomerService CustomerService => ServiceCustomer ?? new CustomerService(context);

        public IOrderAddressService OrderAddressService => ServiceOrderAddress ?? new OrderAddressService(context);

        public IOrderDetailsService OrderDetailsService => ServiceOrderDetails ?? new OrderDetailsService(context);

        public IOrdersService OrdersService => ServiceOrder ?? new OrderService(context);

        public IProductsImagesService ProductsImagesService => ServiceProductsImages ?? new ProductsImagesService(context);

        public IProductsService ProductsService => ServiceProducts ?? new ProductsService(context);

        public ITemporaryService TemporaryService => ServiceTemporary ?? new TemporaryService(context);

        public UnitOfWorks(EticaretContext _context)
        {
            context = _context;
        }
        
    }
}
