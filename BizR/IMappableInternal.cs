using System;

namespace BizR
{
    internal interface IMappableInternal<in T>
    {
        public object Map(T obj);

        public IRegisterHandlerInternal Handler();
    }
}