namespace Bussiness.Concrete
{
    
    public class OrderDetailsService : Repositories<OrderDetails>, IOrderDetailsService
    {
        public OrderDetailsService(EticaretContext db) : base(db)
        {

        }
    }
}
