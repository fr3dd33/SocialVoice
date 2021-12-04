using Domain.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Common.Extensions
{
    public static class LinqExtension
    {
        public static IQueryable<TSource> WhereActive<TSource>(this IQueryable<TSource> source)
            where TSource : AuditableEntity
        {
            return source.Where(x => x.Status == "A");
        }

        public static IQueryable<TSource> WhereActive<TSource>(
            this IQueryable<TSource> source, 
            Expression<Func<TSource, bool>> predicate
        ) where TSource : AuditableEntity
        {
            return source.Where(predicate).Where(x => x.Status == "A");
        }
    }
}
