namespace Wordle.Code;

public interface IOutput
{
    void DisplayWord(string word);
    void DisplayGuessPrompt(int guessCount);
    void DisplayInvalidWordPrompt();
    void DisplayClues(List<(Clue[], string)> guessHistory);
}