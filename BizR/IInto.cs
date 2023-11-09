using System;
using System.Linq.Expressions;

namespace BizR
{
    public interface IInto<TOriginal, TOriginalOut, TIntermediate> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        public IMappable<TOriginal, TOriginalOut, TIntermediate> When(Expression<Func<TOriginal, bool>> predicate);
    }
}