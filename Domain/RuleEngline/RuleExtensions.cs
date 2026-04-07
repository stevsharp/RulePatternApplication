using Infrastructure;

namespace Domain.RuleEngline;

public static class RuleExtensions
{
    public static Result ToResult<T>(this BaseRule<T> rule, T entity)
    {
        return rule.IsSatisfiedBy(entity)
            ? Result.Success()
            : Result.Failure(rule.ErrorMessage);
    }
}