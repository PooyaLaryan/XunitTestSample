using Microsoft.EntityFrameworkCore;
using SampleApi.Infrastructure;
using System.Linq.Expressions;
using SampleApi.Data;
using SampleApi.Data.Entities;

namespace SampleApi.Repository;

public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    protected readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

    public IQueryable<TEntity> Queryable => dbSet.AsQueryable<TEntity>();

    public virtual void Insert(TEntity entity)
    {
        entity.CreateTime = DateTime.Now;
        dbSet.Add(entity);
    }
    public virtual async Task InsertAsync(TEntity entity)
    {
        entity.CreateTime = DateTime.Now;
        await dbSet.AddAsync(entity);
    }

    public virtual async Task InsertAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreateTime = DateTime.Now;
        }
        await dbSet.AddRangeAsync(entities);
    }

    public virtual void Insert(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreateTime = DateTime.Now;
        }
        dbSet.AddRangeAsync(entities);
    }

    public virtual void Update(TEntity entity)
    {
        entity.UpdateTime = DateTime.Now;
        dbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        entity.IsDelete = true;
        Update(entity);
    }

    public virtual void Delete(long id)
    {
        var entityToDelete = dbSet.Single(x => x.Id == id);
        entityToDelete.IsDelete = true;
        Update(entityToDelete);
    }

    public virtual Task<TEntity?> GetByIDAsync(long id)
    {
        var result = dbSet.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public virtual TEntity? GetByID(long id)
    {
        return dbSet.FirstOrDefault(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            IEnumerable<string> includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        /*foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }*/

        if (includeProperties != null)
        {
            foreach (var Property in includeProperties)
            {
                query = query.Include(Property);
            }
        }


        return orderBy != null
           ? await orderBy(query).ToListAsync()
           : await query.ToListAsync();
    }

    public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return [.. orderBy(query)];
        }
        else
        {
            return [.. query];
        }
    }
}
