using System;
using BizR.Handler;

namespace BizR.HandlerRegister
{
    public class RegisterHandler<TOriginal, TOriginalOut, TIntermediate> :
        IRegisterHandler<TOriginal, TOriginalOut, TIntermediate>, IRegisterHandlerInternal
        where TIntermediate : class
        where TOriginal : class
        where TOriginalOut : class
    {
        private Type? _handler;

        public void WithHandler<T>() where T : Handler<TIntermediate, TOriginalOut>
        {
            _handler = typeof(T);
        }


        public Type HandlerType()
        {
            return _handler  ?? throw new ArgumentException("no handler was registered");
        }
    }
}