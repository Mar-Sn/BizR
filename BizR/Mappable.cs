using System;

namespace BizR
{
    public class Mappable<TOriginal, TOriginalOut, TIntermediate> :
        IMappable<TOriginal, TOriginalOut, TIntermediate>, IMappableInternal<TOriginal>
        where TIntermediate : class
        where TOriginal : class
        where TOriginalOut : class
    {
        private Func<TOriginal, TIntermediate> _mapper;
        private RegisterHandler<TOriginal, TOriginalOut, TIntermediate> _handler;

        public IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> Map(Func<TOriginal, TIntermediate> map)
        {
            _mapper = map;
            _handler = new RegisterHandler<TOriginal, TOriginalOut, TIntermediate>();
            return _handler;
        }

        public object Map(TOriginal obj)
        {
            return _mapper.Invoke(obj)!;
        }

        IRegisterHandlerInternal IMappableInternal<TOriginal>.Handler()
        {
            return _handler;
        }
    }
}