namespace Bussiness.Concrete
{
    public class ProductsService : Repositories<Products>, IProductsService
    {
        public ProductsService(EticaretContext db) : base(db)
        {

        }
    }
}
