using System;

namespace BizR
{
    public interface IMappable<TOriginal, TOriginalOut, TIntermediate>
    {
        public IBusinessRules<TIntermediate, TOriginalOut> Map(Func<TOriginal, TIntermediate> map);
    }
}