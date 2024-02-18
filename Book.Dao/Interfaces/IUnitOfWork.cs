namespace Book.Dao.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChanges();
}