using System.Threading.Tasks;

namespace BizR
{
    public abstract class Handler<TIn, TOut> : IHandler where TIn : class
    {
          public abstract Task<TOut> Handle(TIn input);
          
          public async Task<object> HandleInternal(object input)
          {
              return await Handle(input as TIn);
          }
    }
}