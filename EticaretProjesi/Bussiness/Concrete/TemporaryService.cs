namespace Bussiness.Concrete
{
    public class TemporaryService : Repositories<TemporaryBaskets>,ITemporaryService
    {
        public TemporaryService(EticaretContext db) : base(db)
        {
        }
    }
}
