using System;
using BizR.HandlerRegister;

namespace BizR.Mapping
{
    public interface IMappable<TOriginal, TOriginalOut, TIntermediate> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        public IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> Map(Func<TOriginal, TIntermediate> map);
    }
}