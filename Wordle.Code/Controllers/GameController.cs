namespace Wordle.Code;

public class GameController
{
    private const int MaxAttempts = 6;
    private IClueGenerator ClueGenerator { get; }
    private IPlayer Player { get; }
    private IOutput Output { get; }
    private List<(Clue[], string)> GuessHistory { get; } = new();

    public GameController(IClueGenerator clueGenerator, IPlayer player, IOutput output)
    {
        ClueGenerator = clueGenerator;
        Player = player;
        Output = output;
    }

    public void Run()
    {
        var guessList = File.ReadAllLines("../../../../Wordle.Code/GuessList.txt");
        var answerList = File.ReadAllLines("../../../../Wordle.Code/AnswerList.txt");
        var wordList = guessList.Concat(answerList).ToArray();
        var playerGuesses = 0;
        while (playerGuesses < MaxAttempts)
        {
            Output.DisplayGuessPrompt(playerGuesses + 1);
            var guess = Player.Guess().ToLower();
            if (wordList.Contains(guess))
            {
                playerGuesses++;
                var clues = ClueGenerator.Evaluate(guess);
                GuessHistory.Add((clues, guess));
                Output.DisplayClues(GuessHistory);
                if (IsCorrectGuess(clues))
                {
                    return;
                }
            } else
            {
                Output.DisplayInvalidWordPrompt();
            }
            
        }
        
        Output.DisplayWord(ClueGenerator.Word);
    }

    private static bool IsCorrectGuess(Clue[] clues)
    {
        return clues.All(c => c == Clue.Green);
    }
}