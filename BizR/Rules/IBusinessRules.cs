using System;
using System.Threading.Tasks;
using BizR.Into;

namespace BizR.Rules
{
    public interface IBusinessRules<TIn, TOut> where TIn : class where TOut: class
    {
        public IBusinessRules<TIn, TOut> RuleFor<T>(Action<IInto<TIn, TOut, T>> rule) where T : class;
        public Task<TOut> Execute(TIn input);
    }
}