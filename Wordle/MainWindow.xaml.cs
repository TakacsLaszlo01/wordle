using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordleLib;
namespace Wordle;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int guessCounter;
    private int guessCap;
    private WordleLib.Wordle wordle;
    public MainWindow()
    {
        InitializeComponent();
        guessCap = 6;
        wordle = new WordleLib.Wordle(guessCap);
        guessCounter = guessCap - wordle.Guesses;

        GuessRow_0.SetReadOnly(false);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        WordleRow guessRow = GetGuessRow(guessCounter);
        if (guessRow != null)
        {
            try
            {
                Status[] statuses = wordle.MakeGuess(guessRow.InputWord);
                guessRow.ColorWord(statuses);
                guessCounter = guessCap - wordle.Guesses;
                GetGuessRow(guessCounter).SetReadOnly(false);

            }
            catch (OutOfGuessesException ex)
            {
                MessageBox.Show(ex.Message, "Hiba!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!");
            }
            //try-catch hiányzik még
        }
    }
    private WordleRow GetGuessRow(int n)
    {
        if (FindName($"GuessRow_{n}") is WordleRow guessRow)
            return guessRow;
        return null;
    }
}
