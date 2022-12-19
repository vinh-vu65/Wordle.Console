namespace Wordle.Code;

public class Player : IPlayer
{
    private IInput Input { get; }
    public Player(IInput input)
    {
        Input = input;
    }
    
    public string Guess()
    {
        var guess = Input.Read();
        while (guess.Length != 5)
        {
            guess = Input.Read();
        }

        return guess;
    }
}