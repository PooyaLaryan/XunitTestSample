using System.Linq.Expressions;

namespace SampleApi.Infrastructure
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Queryable { get; }
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(IEnumerable<TEntity> entities);
        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        void Delete(long id);

        Task<TEntity?> GetByIDAsync(long id);
        TEntity? GetByID(long id);
        Task<IEnumerable<TEntity>> GetAsync(
                Expression<Func<TEntity, bool>> filter = null,
                IEnumerable<string> includeProperties = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "");
    }
}
