namespace Domain;


public interface IRule<T>
{
    bool IsSatisfiedBy(T entity);
    string ErrorMessage { get; }
}
public abstract class BaseRule<T> : IRule<T>
{
    public abstract bool IsSatisfiedBy(T entity);
    public abstract string ErrorMessage { get; }

    public BaseRule<T> And(IRule<T> other) => new AndRule<T>(this, other);
    public BaseRule<T> Or(IRule<T> other) => new OrRule<T>(this, other);
    public BaseRule<T> Not() => new NotRule<T>(this);
}