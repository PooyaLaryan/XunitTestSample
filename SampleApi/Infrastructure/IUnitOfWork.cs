using SampleApi.Repository;

namespace SampleApi.Infrastructure
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }

        Task CommitAsync();
        Task RollbackAsync();
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
    }
}
