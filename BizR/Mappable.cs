using System;

namespace BizR
{
    public class Mappable<TOriginal, TOriginalOut, TIntermediate> :
        IMappable<TOriginal, TOriginalOut, TIntermediate>, IMapExtraction<TOriginal> where TIntermediate : class where TOriginal : class where TOriginalOut : class
    {
        private readonly BusinessRules<TOriginal, TOriginalOut> _businessRules;
        private Func<TOriginal, TIntermediate> _mapper;

        public Mappable(BusinessRules<TOriginal, TOriginalOut> businessRules)
        {
            _businessRules = businessRules;
        }

        public IRegisterHandler<TOriginal, TOriginalOut, TIntermediate> Map(Func<TOriginal, TIntermediate> map)
        {
            _mapper = map;
            return new RegisterHandler<TOriginal, TOriginalOut, TIntermediate>(_businessRules);
        }


        public object Map(TOriginal obj)
        {
            return _mapper.Invoke(obj)!;
        }
    }
}