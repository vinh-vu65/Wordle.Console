namespace Wordle.Code;

public class ClueGenerator : IClueGenerator
{
    public string Word { get; }
    public Dictionary<char, int> WordTally = new();

    public ClueGenerator(string word)
    {
        Word = word.ToUpper();
        foreach (var c in Word)
        {
            if (WordTally.ContainsKey(c))
            {
                WordTally[c]++;
            }
            else
            {
                WordTally.Add(c, 1);
            }
        }
    }

    public Clue[] Evaluate(string guess)
    {
        guess = guess.ToUpper();
        var clues = new[] {Clue.Black, Clue.Black, Clue.Black, Clue.Black, Clue.Black};
        var letterTally = new Dictionary<char, int>(WordTally);
        for (var i = 0; i < guess.Length; i++)
        {
            if (guess[i] != Word[i]) continue;
            clues[i] = Clue.Green;
            letterTally[guess[i]]--;
        }
        
        for (var i = 0; i < guess.Length; i++)
        {
            if (!letterTally.Keys.Contains(guess[i])) continue;
            letterTally[guess[i]]--;
            if (letterTally[guess[i]] >= 0)
            {
                clues[i] = Clue.Yellow;
            }
        }
        
        return clues;
    }
}