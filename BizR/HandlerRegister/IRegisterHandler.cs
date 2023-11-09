using BizR.Handler;

namespace BizR.HandlerRegister
{
    public interface IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        public void WithHandler<T>() where T : Handler<TIntermediate, TOriginalOut>;
    }
}