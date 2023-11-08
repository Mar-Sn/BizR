using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BizR
{
    public interface IBusinessRules<TIn, TOut>
    {
        public IBusinessRules<TIn, TOut> RuleFor<T>(Action<IInto<TIn, TOut, T>> rule);
        public void WithHandler<T>() where T : IHandler<TIn, TOut>;
        public Task<TOut> Execute(TIn input);
    }
}