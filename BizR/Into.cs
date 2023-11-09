using System;
using System.Linq.Expressions;

namespace BizR
{
    public class Into<TOriginal, TOriginalOut, TIntermediate> : IInto<TOriginal, TOriginalOut, TIntermediate>, 
        IIntoInternal<TOriginal> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        private readonly BusinessRules<TOriginal, TOriginalOut> _businessRules;
        private Func<TOriginal, bool>? _predicate;
        private Mappable<TOriginal,TOriginalOut,TIntermediate> _mapper;

        public Into(BusinessRules<TOriginal, TOriginalOut> businessRules)
        {
            _businessRules = businessRules;
        }

        public IMappable<TOriginal, TOriginalOut, TIntermediate> When(Expression<Func<TOriginal, bool>> predicate)
        {
            _predicate = predicate.Compile();
            _mapper = new Mappable<TOriginal, TOriginalOut, TIntermediate>(_businessRules);
            return _mapper;
        }

        public bool Match(TOriginal obj)
        {
            return _predicate?.Invoke(obj) ?? false;
        }

        public object Map(TOriginal obj)
        {
            return _mapper.Map(obj);
        }

        public Type Handler()
        {
            throw new NotImplementedException();
        }
    }
}