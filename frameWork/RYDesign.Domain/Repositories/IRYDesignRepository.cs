﻿using System.Linq.Expressions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace RYDesign.Domain.Rep
{
    public interface IRYDesignRepository<TEntity,TKey>:IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        Task<(int, List<TEntity>)> GetPagedListAsync<Key>(int skipCount, int taskCount, Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true);
        Task<(int, List<TEntity>)> GetPagedListAsync<Key>(Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true, int pageIndex = 1, int pageSize = 10);

    }
}
