using WordleLib;
namespace WordleConsole;
internal class Program
{
    private static Wordle wordle;
    private static int wordLength;
    private static Dictionary<Status, ConsoleColor> fgColors =
        new Dictionary<Status, ConsoleColor>()
        {
            {Status.Wrong, ConsoleColor.Red},
            {Status.Contains, ConsoleColor.Yellow},
            {Status.Matches, ConsoleColor.Green}
        };
    static void Main(string[] args)
    {
        wordle = new Wordle(8);
        wordLength = wordle.WordLength;
        bool hasGuessed = false;
        Console.WriteLine($"Találja ki a megfelelő szót. Van {wordle.Guesses} próbálkozása!");
        while (wordle.Guesses > 0 && !(hasGuessed = AskWord()) );
        if (hasGuessed)
            Console.WriteLine("Gratulálok, kitalálta a helyes szót!");
    }
    static bool AskWord()
    {
        bool hasGuessed = false;
        try
        {
            string word;
            do
                word = Input($"Kérem adjon meg egy {wordLength} betűs szót: ");
            while (word.Length != wordLength);

            word = word.ToLower();
            Status[] guessStatuses = wordle.MakeGuess(word);

            hasGuessed = guessStatuses.CheckAll(Status.Matches);
            PrintGuess(word, guessStatuses);
        }
        catch (OutOfGuessesException ex)
        {
            Console.WriteLine($"Sajnálom, nem nyert. A helyes szó: {wordle.CorrectWord}");
        }
        catch (NonexistentWordException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return hasGuessed;
    }
    static void PrintGuess(string word, Status[] statuses)
    {
        int length = word.Length;
        for (int i = 0; i < length; i++)
        {
            Console.ForegroundColor = fgColors[statuses[i]];
            Console.Write(word[i]);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"\nMég {wordle.Guesses} próbálkozása van!");
    }
    static string Input(string input)
    {
        Console.Write(input);
        return Console.ReadLine();
    }
}
