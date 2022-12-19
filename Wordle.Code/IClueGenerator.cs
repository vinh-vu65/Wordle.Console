namespace Wordle.Code;

public interface IClueGenerator
{
    string Word { get; }
    public Clue[] Evaluate(string guess);
}