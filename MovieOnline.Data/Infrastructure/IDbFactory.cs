using MovieOnline.Data;
using System;

namespace MovieOnline.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MovieOnlineDbContext Init();
    }
}