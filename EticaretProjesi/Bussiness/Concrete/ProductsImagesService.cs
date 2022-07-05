namespace Bussiness.Concrete
{
    public class ProductsImagesService : Repositories<ProductsImages>, IProductsImagesService
    {
        public ProductsImagesService(EticaretContext db) : base(db)
        {

        }
    }
}
