using MovieOnline.Data;

namespace MovieOnline.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MovieOnlineDbContext dbContext;

        public MovieOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new MovieOnlineDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}