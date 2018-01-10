using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LolDataEntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Common.IService;
using System.Data;
using Common.Globals;

namespace Common.Service
{
    public class EFRepository<TContent> : IEFRepository where TContent : DbContext, new()
    {
        private TContent _dbContext;
        /// <summary>
        /// EF Content实体
        /// </summary>
        public TContent DbContext
        {
            get
            {
                _dbContext = _dbContext ?? new TContent();
                return _dbContext;
            }
        }

        private DbHelper _dbHelp;
        /// <summary>
        /// 数据库Helper
        /// </summary>
        public DbHelper DbHelp
        {
            get
            {
                if(_dbHelp == null)
                {
                    _dbHelp = new DbHelper(DbContext.Database.Connection.ConnectionString);
                }
                return _dbHelp;
            }
        }

        /// <summary>
        /// T实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public DbSet<TEntity> Table<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>();
        } 

        /// <summary>
        /// 获取T实体集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return Table<TEntity>();
        }

        /// <summary>
        /// 查询T实体集合,支持Lambd表达式
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            IQueryable<TEntity> Query = Table<TEntity>();
            return expression == null ? Query : Table<TEntity>().Where(expression);
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDateTime()
        {
            try
            {
                return DbContext.Database.SqlQuery<DateTime>("Select Now()").FirstOrDefault();
            }
            catch(Exception)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 提交更改操作
        /// </summary>
        public void SubmitChanges()
        {
            try
            {
                this.DbContext.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                throw ex;
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 释放DbContext资源
        /// </summary>
        public void Dispose()
        {
            if(_dbContext != null)
            {
                _dbContext.Dispose();
                DbContext.Dispose();
            }
        }

        /// <summary>
        /// 设置监听可用性
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetDetectChanges(bool isEnabled)
        {
            this.DbContext.Configuration.AutoDetectChangesEnabled = isEnabled;
        }

        /// <summary>
        /// 设置延迟加载可用性
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetLazyLoading(bool isEnabled)
        {
            this.DbContext.Configuration.LazyLoadingEnabled = isEnabled;
        }
    }
}
