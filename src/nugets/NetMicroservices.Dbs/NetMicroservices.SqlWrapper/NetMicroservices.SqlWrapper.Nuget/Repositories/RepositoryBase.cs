namespace NetMicroservices.SqlWrapper.Nuget.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

/// <summary>
/// Generic repository pattern implementation.
/// </summary>
/// <typeparam name="TEntity">Domain object that implements Generic Repository pattern.</typeparam>
/// <typeparam name="TContext">DBContext object dependency.</typeparam>
public class RepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity> where TEntity : EntityBase
{
    private readonly DbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="RepositoryBase{TEntity, TContext}"/>.
    /// </summary>
    /// <param name="dbContext">DBContext object dependency.</param>
    public RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// Adding new enttry to the target database.
    /// </summary>
    /// <param name="entity">Input domain entity.</param>
    /// <returns></returns>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Deletion of specific entry from target database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Get all entires from current Dbset.
    /// </summaryCo>
    /// <returns>Collection of entries.</returns>
    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    /// Get entries by predicate.
    /// </summary>
    /// <param name="predicate">Predicate that determinates restriction of target entity.</param>
    /// <returns></returns>
    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if (disableTracking) query = query.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    /// <summary>
    /// Get all entries with restrictions.
    /// </summary>
    /// <param name="predicate">Filter predicate.</param>
    /// <param name="orderBy">Order by restriction filter.</param>
    /// <param name="includes">Assoaciation object.</param>
    /// <param name="disableTracking">Is tracking functionality enabled?</param>
    /// <returns></returns>
    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    /// <summary>
    /// Filter entries of specified Entity by its numeric identifier.
    /// </summary>
    /// <param name="id">Identification numeric identifier.</param>
    /// <returns></returns>
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    /// <summary>
    /// Find first entry in the particular entity.
    /// </summary>
    /// <returns>First record from particular entity.</returns>
    public async Task<TEntity> GetFirstAsync()
    {
        return await _dbContext.Set<TEntity>().OrderBy(e => e.Id).FirstOrDefaultAsync();
    }
}
