using System;
using System.Linq.Expressions;

namespace BizR
{
    public interface IInto<TOriginal, TOriginalOut, TIntermediate>
    {
        public IMappable<TOriginal, TOriginalOut, TIntermediate> When(Expression<Func<TOriginal, bool>> predicate);
    }
}