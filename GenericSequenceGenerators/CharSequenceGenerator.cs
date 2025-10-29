namespace GenericSequenceGenerators;

public sealed class CharSequenceGenerator : SequenceGenerator<char>
{
    public CharSequenceGenerator(char first, char second) : base(first, second)
    {
    }

    protected override char GetNext()
    {
        // Assumption: use a linear recurrence on character codes
        // x_{n+1} = 2*x_n - x_{n-1}, wrapped to 16-bit char range
        int next = (2 * Current) - Previous;
        next = Mod(next, 0x10000); // wrap into [0, 65535]
        return (char)next;
    }

    private static int Mod(int value, int modulus)
    {
        int r = value % modulus;
        return r < 0 ? r + modulus : r;
    }
}
