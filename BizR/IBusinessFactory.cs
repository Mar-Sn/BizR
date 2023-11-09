namespace BizR
{
    public interface IBusinessFactory
    {
          public IBusinessRules<TIn, TOut> Create<TIn, TOut>() where TIn : class where TOut : class; 
    }
}