namespace MovieOnline.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}