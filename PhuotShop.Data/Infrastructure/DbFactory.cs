namespace PhuotShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PhuotShopDbContext dbContext;

        public PhuotShopDbContext Init()
        {
            return dbContext ?? (dbContext = new PhuotShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}