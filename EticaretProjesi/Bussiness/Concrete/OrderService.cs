namespace Bussiness.Concrete
{
    public class OrderService : Repositories<Orders>,IOrdersService
    {
        public OrderService(EticaretContext db) : base(db)
        {

        }
    }
}
