using System;

namespace PhuotShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PhuotShopDbContext Init();
    }
}