namespace Account.Persistence;
public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : class;
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
public class UnitOfWork : IUnitOfWork
{
    private readonly AccountContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    public UnitOfWork(AccountContext context)
    {
        _context = context;
    }
    public IRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repoInstance = new GeneralRepository<T>(_context);
            _repositories[type] = repoInstance;
        }

        return (IRepository<T>)_repositories[type];
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}

