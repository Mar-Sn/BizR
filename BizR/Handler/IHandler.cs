using System.Threading.Tasks;

namespace BizR.Handler
{
    internal interface IHandler
    {
        Task<object> HandleInternal(object input);
    }
}