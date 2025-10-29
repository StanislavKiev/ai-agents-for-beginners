using System;

namespace GenericSequenceGenerators;

public sealed class DelegateSequenceGenerator<T> : SequenceGenerator<T>
{
    private readonly Func<T, T, T> _recurrence;

    public DelegateSequenceGenerator(T first, T second, Func<T, T, T> recurrence)
        : base(first, second)
    {
        _recurrence = recurrence ?? throw new ArgumentNullException(nameof(recurrence));
    }

    protected override T GetNext()
    {
        return _recurrence(Current, Previous);
    }
}
