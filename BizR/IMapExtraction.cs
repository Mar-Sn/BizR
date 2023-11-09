using System;

namespace BizR
{
    internal interface IMapExtraction<in T>
    {
        public object Map(T obj);
    }
}