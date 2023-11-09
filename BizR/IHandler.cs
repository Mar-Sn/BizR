using System.Threading.Tasks;

namespace BizR
{
    internal interface IHandler
    {
        Task<object> HandleInternal(object input);
    }
}