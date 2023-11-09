namespace BizR
{
    public class RegisterHandler<TOriginal, TOriginalOut, TIntermediate>: IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        private readonly BusinessRules<TOriginal, TOriginalOut> _businessRules;

        public RegisterHandler(BusinessRules<TOriginal, TOriginalOut> businessRules)
        {
            _businessRules = businessRules;
        }

        public IBusinessRules<TOriginal, TOriginalOut> WithHandler<T>() where T : Handler<TIntermediate, TOriginalOut>
        {
            return _businessRules;
        }
    }
}