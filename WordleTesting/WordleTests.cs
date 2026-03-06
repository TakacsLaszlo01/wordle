namespace WordleTesting;
using WordleLib;
public class WordleTests
{
    [Fact]
    public void CorrectWordTest()
    {
        Wordle wordle = new Wordle();
        Status[] actual = wordle.MakeGuess(wordle.CorrectWord);
        Status[] expected = new Status[5];
        for (int i = 0; i < 5; i++)
            expected[i] = Status.Matches;

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void NonexistentWordException()
    {
        Wordle wordle = new Wordle();
        Assert.Throws<Exception>(() => wordle.MakeGuess("asdfg"));
    }
}