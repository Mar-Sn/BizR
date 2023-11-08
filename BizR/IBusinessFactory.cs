namespace BizR
{
    public interface IBusinessFactory
    {
          public IBusinessRules<TIn, TOut> Create<TIn, TOut>(); 
    }
}