using System;
using System.Linq.Expressions;

namespace BizR
{
    internal interface IIntoInternal<in T>
    {
        bool Match(T obj);

        object Map(T obj);

        Type Handler();
    }
}