using Moq;
using Wordle.Code;
using Xunit;

namespace Wordle.Tests;

public class PlayerTests
{
    private Mock<IInput> _input = new Mock<IInput>();
    
    [Fact]
    public void Guess_ShouldGuessAWordWith5Letters()
    {
        var sut = new Player(_input.Object);
        _input.Setup(x => x.Read()).Returns("hello");

        var guess = sut.Guess();
        
        Assert.Equal(5, guess.Length);
    }
}