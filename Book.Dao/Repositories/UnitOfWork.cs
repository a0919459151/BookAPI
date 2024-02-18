using Book.Dao.Interfaces;

namespace Book.Dao.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookApiDBContext _dbContext;

    public UnitOfWork(BookApiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChanges()
    {
        return await _dbContext.SaveChangesAsync();
    }
}