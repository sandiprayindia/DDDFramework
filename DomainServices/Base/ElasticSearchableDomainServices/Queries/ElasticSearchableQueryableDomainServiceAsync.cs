﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Base.Aggregates;
using Domain.Base.Entities;
using DomainServices.Base.QueryableDomainServices;
using Repository;
using Repository.Base;

namespace DomainServices.Base.ElasticSearchableDomainServices.Queries
{
    public class ElasticSearchableQueryableDomainServiceAsync<TId, TEntity> : QueryableDomainServiceAsync<TId, TEntity>, IElasticSearchableQueryableDomainServiceAsync<TId,TEntity>
        where TId : struct
        where TEntity : BaseEntity<TId>, IQueryableAggregateRoot, IElasticSearchable
    {
        public ElasticSearchableQueryableDomainServiceAsync(IQueryableElasticSearchRepository<TEntity> repository) : base(repository)
        {

        }

        public virtual async Task<IList<TEntity>> QueryStringAsync(string term, CancellationToken token = default(CancellationToken), Action operationToExecuteBeforeNextOperation = null)
        {
            return await (_repository as IQueryableElasticSearchRepository<TEntity>).QueryStringAsync(term, token, operationToExecuteBeforeNextOperation);
        }

        public virtual async Task<PagingTableResult<TEntity>> GetAllPagedResultAsync(string id, int startIndex, int pageSize, string sorting, CancellationToken token = default(CancellationToken), Action operationToExecuteBeforeNextOperation = null)
        {
            return await (_repository as IQueryableElasticSearchRepository<TEntity>).GetAllPagedResultAsync(id, startIndex, pageSize, sorting,token, operationToExecuteBeforeNextOperation);
        }

    }
}
