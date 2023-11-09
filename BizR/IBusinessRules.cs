using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BizR
{
    public interface IBusinessRules<TIn, TOut> where TIn : class where TOut: class
    {
        public IBusinessRules<TIn, TOut> RuleFor<T>(Action<IInto<TIn, TOut, T>> rule) where T : class;
        public Task<TOut> Execute(TIn input);
    }
}