﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using NHibernate;
using NHibernate.Criterion;

namespace WL_OA
{
    public static class QueryEx
    {
        public static IQueryOver<T,T> WhereIfNotEmpty<T>(this IQueryOver<T,T> query, string param, Expression<Func<T, bool>> expression)
        {
            if(!param.NullOrEmpty())
            {
                query.And(expression);
            }
            return query;
        }


        public static IQueryOver<T, T> WhereifNotNull<T>(this IQueryOver<T, T> query, object param, Expression<Func<T, bool>> expression)
        {
            if (null != param)
            {
                query.And(expression);
            }
            return query;
        }
    }
}