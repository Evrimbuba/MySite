using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProfileSite.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // ElemanUzmani GenericRepository
        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, TEntity>> select = null, 
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Expression<Func<TEntity, object>> orderby = null, 
            bool disableTracking = true, 
            int activePage = -1, 
            int recordCount = 15, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> newOrderBy = null);
        Task<TEntity> Get(
            Expression<Func<TEntity, TEntity>> select = null, 
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = true);
        bool Any(Expression<Func<TEntity, TEntity>> select = null, Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> groupBy = null);
        bool Update(IEnumerable<TEntity> entities);

        // Fatih Çakıroğlu GenericRepository
        bool AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        int DeleteRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);

        //Task<TEntity> GetByIdAsync(int id);
        //Task<IEnumerable<TEntity>> GetAllAsync();
        //Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        //Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}