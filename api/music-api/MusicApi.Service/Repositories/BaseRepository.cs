using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories
{
    public abstract class BaseRepository<T> :IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        protected BaseRepository(ApplicationDbContext context){
            _context = context;
            _dbSet=_context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task AddAsynch(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<T?> GetByIdAsynch(object id) => await _dbSet.FindAsync(id);
        public virtual async Task<T?> FirstOrDefaultAsynch(Expression<Func<T,bool>> where)
            => await _dbSet.FirstOrDefaultAsync(where);
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) 
            => _dbSet.Where(where);

        public virtual async Task UpdateAsynch(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public virtual async Task Delete(T @object)
        {
              _dbSet.Remove(@object);
              await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteMany(Expression<Func<T, bool>> where)
        {
            var objs=_dbSet.Where(where).AsEnumerable();
            foreach (var obj in objs)
            {
                _dbSet.Remove(obj);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludes(Expression<Func<T, object>> includes)
        {
            var query=_dbSet.AsQueryable().ApplyIncludes(includes);
            return await query.ToListAsync();
        }
        public async Task<T?> FirstOrDefaultWithIncludes(Expression<Func<T,bool>> where, Expression<Func<T, object>> includes)
        {
            IQueryable<T> query =_dbSet.AsQueryable().ApplyIncludes(includes);
            return await query.FirstOrDefaultAsync(where);
        }
    }
    internal static class RepositoryExtensions
    {
        public static IQueryable<T> ApplyIncludes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
