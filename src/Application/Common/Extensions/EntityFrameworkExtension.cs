using Application.Common.Exceptions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static async ValueTask<TEntity> FindActiveAsync<TEntity>(
            this DbSet<TEntity> set, params object[] keyValues
        ) where TEntity : AuditableEntity
        {
            var entity = await set.FindAsync(keyValues);

            if (entity == null || entity.Status != "A")
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }

        public static async Task<TSource> SingleActiveOrDefaultAsync<TSource>(
            this IQueryable<TSource> source, 
            Expression<Func<TSource, bool>> predicate, 
            CancellationToken cancellationToken = default
        ) where TSource : AuditableEntity
        {
            var entity = await source.SingleOrDefaultAsync(predicate, cancellationToken);

            if (entity == null || entity.Status != "A")
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }
    }
}
