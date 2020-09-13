using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce_Shop_Online_MVC_Data.Infrastructure
{
    public abstract class RepositoryBase<T, TK> : IRepository<T, TK> where T : class
    {
        #region Properties

        private ECommerceShopDbContext _dataContext;

        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory
        {
            get;
        }

        protected ECommerceShopDbContext DbContext => _dataContext ??= DbFactory.Init();

        #endregion Properties

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public T Delete(TK id)
        {
            var entity = _dbSet.Find(id);
            return _dbSet.Remove(entity);
        }

        public void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public T GetSingleById(TK id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return _dbSet.Count(where);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    return query.AsQueryable();
                }
            }

            return _dataContext.Set<T>().AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _dataContext.Set<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where(predicate).AsQueryable();
            }

            return _dataContext.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resetSet = predicate != null ? _dataContext.Set<T>().Where(predicate).AsQueryable() : _dataContext.Set<T>().AsQueryable();
            }

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return _dataContext.Set<T>().Count(predicate) > 0;
        }

        #endregion Implementation

        
    }
}