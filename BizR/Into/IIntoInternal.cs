using System;

namespace BizR.Into
{
    internal interface IIntoInternal<in T>
    {
        bool Match(T obj);

        object Map(T obj);

        Type Handler();
    }
}