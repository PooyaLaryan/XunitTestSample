using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SampleApi.Infrastructure;
using SampleApi.Repository;

namespace SampleApi.Data
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        public IPersonRepository PersonRepository => appDbContext.GetService<IPersonRepository>();

        public Task CommitAsync()
        {
            if (appDbContext.Database.CurrentTransaction != null)
            {

                return appDbContext.Database.CurrentTransaction.CommitAsync();
            }

            return Task.CompletedTask;
        }

        public Task RollbackAsync()
        {
            if (appDbContext.Database.CurrentTransaction != null)
            {

                return appDbContext.Database.CurrentTransaction.RollbackAsync();
            }

            return Task.CompletedTask;
        }

        public Task BeginTransactionAsync()
        {
            return appDbContext.Database.BeginTransactionAsync();
        }

        public Task SaveChangesAsync()
        {
            return appDbContext.SaveChangesAsync();
        }
    }
}
