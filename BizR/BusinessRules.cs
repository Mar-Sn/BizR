using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BizR
{
    public class BusinessRules<TIn, TOut> : IBusinessRules<TIn, TOut> where TIn : class where TOut : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, object> _rules = new Dictionary<Type, object>();

        public BusinessRules(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBusinessRules<TIn, TOut> RuleFor<T>(Action<IInto<TIn, TOut, T>> rule) where T : class
        {
            var into = new Into<TIn, TOut, T>();
            rule(into);
            _rules.Add(typeof(T), into);
            return this;
        }

        public async Task<TOut> Execute(TIn input)
        {
            var rules = _rules
                .Select(e => e.Value as IIntoInternal<TIn>)
                .Where(e => e != null)
                .Where(e => e!.Match(input)).ToArray();

            if (rules.Length > 1)
            {
                throw new ArgumentException("ambiguous rules, there is to much overlap");
            }

            var rule = rules.First();
            var mapped = rule!.Map(input);
            var handlerType = rule.Handler();
            var service = _serviceProvider.GetRequiredService(handlerType);
            var handler = service as IHandler;
            return (await handler.HandleInternal(mapped)) as TOut;
        }
    }
}