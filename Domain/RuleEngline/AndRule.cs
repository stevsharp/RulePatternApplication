namespace Domain;

public class AndRule<T> : BaseRule<T>
{
    private readonly IRule<T> _left, _right;
    public AndRule(IRule<T> left, IRule<T> right) => (_left, _right) = (left, right);

    public override bool IsSatisfiedBy(T entity) =>
        _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);

    public override string ErrorMessage =>
        _left.ErrorMessage + "; " + _right.ErrorMessage;
}
public class OrRule<T> : BaseRule<T>
{
    private readonly IRule<T> _left, _right;
    public OrRule(IRule<T> left, IRule<T> right) => (_left, _right) = (left, right);

    public override bool IsSatisfiedBy(T entity) =>
        _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);

    public override string ErrorMessage => _left.ErrorMessage;
}

public class NotRule<T> : BaseRule<T>
{
    private readonly IRule<T> _inner;
    public NotRule(IRule<T> inner) => _inner = inner;

    public override bool IsSatisfiedBy(T entity) => !_inner.IsSatisfiedBy(entity);
    public override string ErrorMessage => $"Negated: {_inner.ErrorMessage}";
}