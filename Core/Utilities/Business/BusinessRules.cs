using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {

        public static IResult<T> Run<T>(params IResult<T>[] rules)
        {

            foreach (var rule in rules)
            {
                if (!rule.success)
                {
                    return rule;
                }
            }
            return null;
        }
    }
}
