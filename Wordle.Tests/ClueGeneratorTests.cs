using Wordle.Code;
using Xunit;

namespace Wordle.Tests;

public class ClueGeneratorTests
{
    [Fact]
    public void Evaluate_ShouldReturnAllBlacks_WhenNoLetterIsInTheWord()
    {
        var sut = new ClueGenerator("PLATE");
        var guess = "SKINS";
        var expectedResult = new[] {Clue.Black, Clue.Black, Clue.Black, Clue.Black, Clue.Black};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnYellow_WhenLetterIsInTheWordButInWrongPosition()
    {
        var sut = new ClueGenerator("PLATE");
        var guess = "MEALY";
        var expectedResult = Clue.Yellow;
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result[1]);
        Assert.Equal(expectedResult, result[3]);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnGreen_WhenLetterIsInTheWordAndInCorrectPosition()
    {
        var sut = new ClueGenerator("PLATE");
        var guess = "MEALY";
        var expectedResult = Clue.Green;
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result[2]);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnGreen_WhenGuessIsSameAsWord()
    {
        var sut = new ClueGenerator("PLATE");
        var guess = "PLATE";
        var expectedResult = new[] {Clue.Green, Clue.Green, Clue.Green, Clue.Green, Clue.Green};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Evaluate_ShouldReturnOneYellow_WhenGuessHasARepeatedLetterButWordDoesNot()
    {
        var sut = new ClueGenerator("PLANS");
        var guess = "HELLO";
        var expectedResult = new[] {Clue.Black, Clue.Black, Clue.Yellow, Clue.Black, Clue.Black};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnOneYellow_WhenWordHasARepeatedLetterButGuessDoesNot()
    {
        var sut = new ClueGenerator("HELLO");
        var guess = "PLANS";
        var expectedResult = new[] {Clue.Black, Clue.Yellow, Clue.Black, Clue.Black, Clue.Black};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnTwoYellow_WhenWordAndGuessHasARepeatedLetter()
    {
        var sut = new ClueGenerator("FLEET");
        var guess = "ELITE";
        var expectedResult = new[] {Clue.Yellow, Clue.Green, Clue.Black, Clue.Yellow, Clue.Yellow};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnYellow_WhenWordAndGuessHasARepeatedLetter()
    {
        var sut = new ClueGenerator("FLEET");
        var guess = "ELIPL";
        var expectedResult = new[] {Clue.Yellow, Clue.Green, Clue.Black, Clue.Black, Clue.Black};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Evaluate_ShouldReturnBlack_WhenGuessHasARepeatedLetterWithOneInRightSpotAndWordHasOneLetter()
    {
        var sut = new ClueGenerator("SHAWL");
        var guess = "SHALL";
        var expectedResult = new[] {Clue.Green, Clue.Green, Clue.Green, Clue.Black, Clue.Green};
        
        var result = sut.Evaluate(guess);
        
        Assert.Equal(expectedResult, result);
    }
}

