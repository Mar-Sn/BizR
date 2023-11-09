using BizR.HandlerRegister;

namespace BizR.Mapping
{
    internal interface IMappableInternal<in T>
    {
        public object Map(T obj);

        public IRegisterHandlerInternal Handler();
    }
}