using System.Collections.Generic;

namespace GenericSequenceGenerators;

public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
{
    protected SequenceGenerator(T first, T second)
    {
        Previous = first;
        Current = second;
        Count = 2;
    }

    public T Previous { get; protected set; }

    public T Current { get; protected set; }

    public T Next => GetNext();

    public int Count { get; private set; }

    protected abstract T GetNext();

    public T Advance()
    {
        var next = GetNext();
        Previous = Current;
        Current = next;
        checked { Count++; }
        return Current;
    }

    public IEnumerable<T> Generate(int count)
    {
        if (count <= 0)
        {
            yield break;
        }

        yield return Previous;
        if (count == 1)
        {
            yield break;
        }

        yield return Current;

        var produced = 2;
        while (produced < count)
        {
            yield return Advance();
            produced++;
        }
    }
}
