using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task AddAsynch(T entity);
        public Task<T?> GetByIdAsynch(object id);
        public Task<T?> FirstOrDefaultAsynch(Expression<Func<T, bool>> where);
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        public Task UpdateAsynch(T entity);
        public Task Delete(T @object);
        public Task DeleteMany(Expression<Func<T, bool>> where);
        public Task<IEnumerable<T>> GetAllWithIncludes(Expression<Func<T, object>> includes);
        public Task<T?> FirstOrDefaultWithIncludes(Expression<Func<T, bool>> where, Expression<Func<T, object>> includes);
    }
}
