using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.MySql.IService
{
    /// <summary>
    /// EF顶级数据接口
    /// </summary>
    public interface IEFRepository : IDisposable
    {
        /// <summary>
        /// T实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Table<TEntity>() where TEntity : class;

        /// <summary>
        /// 查询T实体集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;

        /// <summary>
        /// 查询T实体集合,支持Lambd表达式
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

        /// <summary>
        /// 提交变更
        /// </summary>
        void SubmitChanges();
    }
}
