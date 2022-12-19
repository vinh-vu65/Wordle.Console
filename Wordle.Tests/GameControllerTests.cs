using Moq;
using Wordle.Code;
using Xunit;

namespace Wordle.Tests;

public class GameControllerTests
{
    private readonly Mock<IClueGenerator> _clueGenerator = new();
    private readonly Mock<IPlayer> _player = new();
    private readonly Mock<IOutput> _output = new();

    // [Fact]
    // public void Run_ShouldEvaluatePlayerGuessMaximumSixTimes()
    // {
    //     var sut = new GameController(_clueGenerator.Object, _player.Object, _output.Object);
    //     _player.Setup(p => p.Guess()).Returns("PLATE");
    //
    //     sut.Run();
    //
    //     _clueGenerator.Verify(x => x.Evaluate(It.IsAny<string>()), Times.AtMost(6));
    // }
    
    [Fact]
    public void Run_ShouldAllowPlayerToGuessMaximumSixTimes()
    {
        var clue = new ClueGenerator("SLATE");
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.Setup(p => p.Guess()).Returns("PLATE");

        sut.Run();

        _player.Verify(x => x.Guess(), Times.AtMost(6));
    }

    [Fact]
    public void Run_ShouldEndWhenPlayerEntersCorrectGuess()
    {
        var word = "PLATE";
        var clue = new ClueGenerator(word);
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.Setup(x => x.Guess()).Returns(word);

        sut.Run();

        _player.Verify(x => x.Guess(), Times.Once);
    }

    [Fact]
    public void Run_ShouldDisplayTheWord_WhenPlayerDoesNotGuessIn6Attempts()
    {
        var word = "PLATE";
        var clue = new ClueGenerator(word);
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.Setup(x => x.Guess()).Returns("MANGO");

        sut.Run();

        _output.Verify(o => o.DisplayWord(word), Times.Once);
    }

    [Fact]
    public void Run_ShouldDisplayInvalidWordPrompt_WhenPlayerGuessesInvalidWord()
    {
        var word = "PLATE";
        var clue = new ClueGenerator(word);
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.SetupSequence(x => x.Guess()).Returns("ASDFG").Returns("MANGO").Returns("MANGO")
            .Returns("MANGO").Returns("MANGO").Returns("MANGO").Returns("MANGO").Returns("MANGO");

        sut.Run();

        _output.Verify(o => o.DisplayInvalidWordPrompt(), Times.AtLeastOnce);
    }

    [Fact]
    public void Run_ShouldLetPlayerGuessMaximumOf6ValidWords()
    {
        var word = "PLATE";
        var clue = new ClueGenerator(word);
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.SetupSequence(x => x.Guess()).Returns("ASDFG").Returns("MANGO").Returns("MANGO")
            .Returns("MANGO").Returns("MANGO").Returns("MANGO").Returns("MANGO").Returns("MANGO");
        var totalGuesses = 7;  // 1 invalid guess + 6 valid guesses = 7
        
        sut.Run();

        _player.Verify(o => o.Guess(), Times.Exactly(totalGuesses));
    }

    [Fact]
    public void Run_ShouldDisplayClues_WhenPlayerInputsValidGuess()
    {
        var word = "PLATE";
        var clue = new ClueGenerator(word);
        var sut = new GameController(clue, _player.Object, _output.Object);
        _player.Setup(x => x.Guess()).Returns("BOBBY");
        var expectedClues = new[] {Clue.Black, Clue.Black, Clue.Black, Clue.Black, Clue.Black};
        
        sut.Run();

        //_output.Verify(o => o.DisplayClues(expectedClues, "bobby"), Times.AtLeastOnce);
    }
}

