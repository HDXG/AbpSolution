using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RYDesign.Domain.Rep;
using RYDesign.EntityFrameWorkCore.EfCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RYDesign.EntityFrameWorkCore.Repositories
{
    public abstract class RYDesignRepository<TDbContext, TEntity, TKey>(IDbContextProvider<TDbContext> dbContextProvider) : EfCoreRepository<TDbContext, TEntity, TKey>(dbContextProvider), IRYDesignRepository<TEntity, TKey> where TDbContext :
        IRYDesignContext where TEntity : class, IEntity<TKey>
    {
        public async Task<(int, List<TEntity>)> GetPagedListAsync<Key>(int skipCount, int taskCount, Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true)
        {
            List<TEntity> queryable = await (await GetQueryableAsync()).Where(wherePredicate).ToListAsync();
            var count = queryable.Count();
            var queryable2 = (isReverse ? queryable.OrderByDescending(orderPredicate) : queryable.OrderBy(orderPredicate));
            return (count, queryable2.Skip(skipCount).Take(taskCount).ToList());
        }

        /// <summary>
        /// 默认分页内容
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="wherePredicate"></param>
        /// <param name="orderPredicate"></param>
        /// <param name="pageIndex">默认第一页</param>
        /// <param name="pageSize">页数</param>
        /// <param name="isReverse">true 倒叙</param>
        /// <returns></returns>
        public virtual Task<(int, List<TEntity>)> GetPagedListAsync<Key>(Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true, int pageIndex = 1, int pageSize = 10)
        {
            return GetPagedListAsync((pageIndex - 1) * pageSize, pageSize, wherePredicate, orderPredicate, isReverse);
        }
    }
}
