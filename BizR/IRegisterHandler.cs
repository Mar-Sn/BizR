namespace BizR
{
    public interface IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        public IBusinessRules<TOriginal, TOriginalOut> WithHandler<T>() where T : Handler<TIntermediate, TOriginalOut>;
    }
}