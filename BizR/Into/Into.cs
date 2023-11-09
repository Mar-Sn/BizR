using System;
using System.Linq.Expressions;
using BizR.Mapping;

namespace BizR.Into
{
    public class Into<TOriginal, TOriginalOut, TIntermediate> : IInto<TOriginal, TOriginalOut, TIntermediate>,
        IIntoInternal<TOriginal> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        private Func<TOriginal, bool>? _predicate;
        private Mappable<TOriginal, TOriginalOut, TIntermediate>? _mapper;

        public IMappable<TOriginal, TOriginalOut, TIntermediate> When(Expression<Func<TOriginal, bool>> predicate)
        {
            _predicate = predicate.Compile();
            _mapper = new Mappable<TOriginal, TOriginalOut, TIntermediate>();
            return _mapper;
        }

        public bool Match(TOriginal obj)
        {
            return _predicate?.Invoke(obj) ?? false;
        }

        public object Map(TOriginal obj)
        {
            return _mapper?.Map(obj) ?? throw new ArgumentException("no mapper was registered");
        }

        public Type Handler()
        {
            return (_mapper as IMappableInternal<TOriginal> ?? throw new ArgumentException("no mapper was registered"))
                .Handler().HandlerType();
        }
    }
}