namespace Sequences;

public sealed class CharSequenceGenerator : SequenceGenerator<char>
{
    private char previousValue;
    private char currentValue;
    private int generatedCount;

    public CharSequenceGenerator(char firstValue, char secondValue)
    {
        previousValue = firstValue;
        currentValue = secondValue;
        generatedCount = 0;
    }

    public override char GetNext()
    {
        if (generatedCount == 0)
        {
            generatedCount++;
            return previousValue;
        }

        if (generatedCount == 1)
        {
            generatedCount++;
            return currentValue;
        }

        var nextValue = (char)(currentValue + previousValue);
        previousValue = currentValue;
        currentValue = nextValue;
        generatedCount++;
        return nextValue;
    }
}