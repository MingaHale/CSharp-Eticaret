namespace Bussiness.Concrete
{
    public class OrderAddressService : Repositories<OrderAddress>, IOrderAddressService
    {
        public OrderAddressService(EticaretContext db) : base(db)
        {

        }
    }
}
