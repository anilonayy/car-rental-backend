using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static ICustomResult<T> Run<T>(params ICustomResult<T>[] rules)
        {
            foreach(var rule in rules)
            {
                if(!rule.isSuccess)
                {
                    return rule;
                }
            }
            return null;
        }
    }
}
