using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce_Shop_Online_MVC_Data.Infrastructure
{
    public interface IRepository<T, TK> where T : class
    {
        /// <summary>
        /// Tạo 1 entity mới.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Chỉnh sửa 1 Entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Xóa 1 entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Delete(T entity);

        /// <summary>
        /// Xóa bản ghi theo Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Delete(TK id);

        /// <summary>
        /// Xóa nhiều bản ghi.
        /// </summary>
        /// <param name="where">The where.</param>
        void DeleteMulti(Expression<Func<T, bool>> where);

        /// <summary>
        /// Lấy 1 bản ghi thông qua Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetSingleById(TK id);

        /// <summary>
        /// Lấy 1 bản ghi thông qua trạng thái.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        /// <summary>
        /// Nhiều Bản Ghi Theo Where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);


        /// <summary>
        /// Lấy Tất Cả Bản Ghi Dùng IQueryable.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(string[] includes = null);

        /// <summary>
        /// Lấy Bản Ghi Theo Trang.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="total">The total.</param>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        /// <summary>
        /// Lấy Nhiều Bản Ghi.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> where);

        /// <summary>
        /// Checks the contains.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}