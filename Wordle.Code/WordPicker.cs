namespace Wordle.Code;

public class WordPicker
{
    public string Pick(String[] wordList)
    {
        var random = new Random();
        return wordList[random.Next(0, wordList.Length)];
    }
}