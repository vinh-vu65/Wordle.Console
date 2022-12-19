namespace Wordle.Code;

public class ConsoleWriter : IOutput
{
    public void DisplayWord(string word)
    {
        Console.WriteLine($"The word was {word}");
    }

    public void DisplayGuessPrompt(int guessCount)
    {
        Console.WriteLine($"Input guess [{guessCount}/6]:");
    }

    public void DisplayInvalidWordPrompt()
    {
        Console.WriteLine("Invalid guess");
    }

    public void DisplayClues(List<(Clue[], string)> guessHistory)
    {
        Console.Clear();
        foreach (var (clue, guess) in guessHistory)
        {
            var upperGuess = guess.ToUpper();
            for (var i = 0; i < upperGuess.Length; i++)
            {
                Console.BackgroundColor = clue[i] switch
                {
                    Clue.Green => ConsoleColor.Green,
                    Clue.Yellow => ConsoleColor.Yellow,
                    _ => ConsoleColor.DarkBlue
                };
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(upperGuess[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}