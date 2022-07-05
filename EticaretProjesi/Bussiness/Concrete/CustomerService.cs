
namespace Bussiness.Concrete
{
    public class CustomerService : Repositories<Customers>, ICustomerService
    {
        public CustomerService(EticaretContext db) : base(db)
        {

        }
    }
}
