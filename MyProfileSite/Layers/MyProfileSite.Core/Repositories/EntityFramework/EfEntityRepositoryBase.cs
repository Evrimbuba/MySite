using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProfileSite.Core.Repositories.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public bool AddAsync(TEntity entity)
        {
            using TContext context = new TContext();
            context.Entry(entity).State = EntityState.Added;
            return context.SaveChanges() > 0;
        }

        public void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using TContext context = new TContext();
            foreach (var item in entities)
            {
                context.Entry(item).State = EntityState.Added;
            }
            context.SaveChanges();
        }

        public bool Delete(TEntity entity)
        {
            using TContext context = new TContext();
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
        public int DeleteRange(IEnumerable<TEntity> entities)
        {
            using TContext context = new TContext();
            foreach (var item in entities)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
            int recordsAffected = context.SaveChanges();
            return recordsAffected;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, TEntity>> select = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                        bool disableTracking = true)
        {

            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                return await query.Select(select).SingleOrDefaultAsync();
            else
                return await query.FirstOrDefaultAsync();
            //TODO:Hata verdiği için firstordefault yapıldı, muhammet kontrol.

        }

        public bool Update(TEntity entity)
        {
            using TContext context = new TContext();

            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;

        }
        public bool Update(IEnumerable<TEntity> entities)
        {
            using TContext context = new TContext();
            foreach (var item in entities)
            {
                context.Entry(item).State = EntityState.Modified;
            }
            return context.SaveChanges() > 0;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> select = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Expression<Func<TEntity, object>> orderby = null, bool disableTracking = true, int activePage = -1, int recordCount = 15, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> newOrderBy = null)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }
            if (newOrderBy != null)
            {
                query = newOrderBy(query);
            }

            if (select != null)
                query = query.Select(select);

            if (orderby != null)
                query = query.OrderByDescending(orderby);

            if (activePage != -1)
                query = query.Skip(activePage * recordCount).Take(recordCount);

            return await query.ToListAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> groupBy = null)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (groupBy != null)
                return query.GroupBy(groupBy).Count();

            return query.Count();
        }

        public bool Any(Expression<Func<TEntity, TEntity>> select = null, Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Any();
        }
    }
}
