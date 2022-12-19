namespace Wordle.Code;

public class ConsoleReader : IInput
{
    public string Read()
    {
        return Console.ReadLine();
    }
}