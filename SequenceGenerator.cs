namespace Sequences;

public abstract class SequenceGenerator<T>
{
    public abstract T GetNext();
}