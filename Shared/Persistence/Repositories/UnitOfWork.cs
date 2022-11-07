using TastyPoint.API.Shared.Domain.Repositories;
using TastyPoint.API.Shared.Persistence.Contexts;

namespace TastyPoint.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly TastyPointDbContext _tastyPointDbContext;

    public UnitOfWork(TastyPointDbContext tastyPointDbContext)
    {
        _tastyPointDbContext = tastyPointDbContext;
    }

    public async Task CompleteAsync()
    {
        await _tastyPointDbContext.SaveChangesAsync();
    }
}