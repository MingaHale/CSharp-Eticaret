
namespace Bussiness.Concrete
{
    public class CategoriesService : Repositories <Categories>, ICategoriesService
    {
        public CategoriesService(EticaretContext db) : base(db)
        {

        }
    }
}
