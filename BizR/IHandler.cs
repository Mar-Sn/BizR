using System.Threading.Tasks;

namespace BizR
{
    public interface IHandler<TIn, TOut>
    {
          public Task<TOut> Handle(TIn input);
    }
}