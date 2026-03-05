namespace WordleLib;

public class Wordle
{
    private int guesses;
    private readonly string correctWord;
    private string[] words;
    private readonly int wordLength;
    private readonly int count;
    public Wordle(int guesses = 6)
    {
        this.guesses = guesses;
        words = File.ReadAllLines("valid-wordle-words.txt");
        count = words.Length;
        this.wordLength = words[0].Length;
        this.correctWord = FetchWord();
    }
    public int Guesses => guesses;
    public string CorrectWord => correctWord;
    public int WordLength => wordLength;
    private string FetchWord()
    {
        int n = new Random().Next(count);
        return words[n];
    }
    public Status[] MakeGuess(string s)
    {
        //bináris keresés, hogy a listában van-e
        int index = Array.BinarySearch(words, s);
        int i, j;
        if (index < 0)
        {
            index = -index - 10;
            if (index < 0) index = 0;
            else if (index > words.Length) index = words.Length - 21;

            int cap = index + 20;
            bool hasFound = false;
            for (i = index; i < cap; i++)
                if (hasFound = words[i].Equals(s)) break;

            if (!hasFound) throw new
                NonexistentWordException("Listában nem található szó!");
        }
        if (--guesses <= 0)
            throw new OutOfGuessesException();

        Status[] statuses = new Status[wordLength];
        bool[] isMarked = new bool[wordLength];

        //pontos egyezés (zöld) - betűnként - 1 for ciklus
        int partial = 0, correct = 0;
        for (i = 0; i < wordLength; i++)
        {
            statuses[i] = Status.Wrong;
            if (isMarked[i] = s[i] == correctWord[i])
            {
                statuses[i] = Status.Matches;
                correct++;
            }
        }
        if (correct >= wordLength) return statuses;
        //részleges egyezés (sárga) - 2 for ciklus
        for (i = 0; i < wordLength; i++)
        {
            for (j = 0; j < wordLength; j++)
                if (i != j && statuses[i] == Status.Wrong &&
                    !isMarked[j] && s[i] == correctWord[j])
                {
                    statuses[i] = Status.Contains;
                    isMarked[j] = true;
                    partial++;
                }
        }
        return statuses;
    }
    
}
