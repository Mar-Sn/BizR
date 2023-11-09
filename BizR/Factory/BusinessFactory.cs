using System;
using BizR.Rules;

namespace BizR.Factory
{
    public class BusinessFactory: IBusinessFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BusinessFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBusinessRules<TIn, TOut> Create<TIn, TOut>() where TIn : class where TOut : class
        {
            return new BusinessRules<TIn, TOut>(_serviceProvider);
        }
    }
}