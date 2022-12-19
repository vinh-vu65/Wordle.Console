using System.Linq;
using Wordle.Code;
using Xunit;

namespace Wordle.Tests;

public class WordPickerTests
{
    [Fact]
    public void Pick_ShouldGetWordFromWordList()
    {
        var sut = new WordPicker();
        var input = new[] {"hello", "plate", "skate"};
        
        var result = sut.Pick(input);
        
        Assert.True(input.Contains(result));
    }
}