using TastyPoint.API.Shared.Persistence.Contexts;

namespace TastyPoint.API.Shared.Persistence.Repositories;

public class BaseRespository
{
    protected readonly TastyPointDbContext _tastyPointDbContext;

    public BaseRespository(TastyPointDbContext tastyPointDbContext)
    {
        _tastyPointDbContext = tastyPointDbContext;
    }
}