using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
/// Interaction logic for WordleRow.xaml
/// </summary>
public partial class WordleRow : Grid
{
    private Dictionary<Status, Color> bgColors = new Dictionary<Status, Color>()
    {
        {Status.Wrong, Color.FromRgb(255, 64, 64)},
        {Status.Contains, Color.FromRgb(240, 240, 64)},
        {Status.Matches, Color.FromRgb(32, 255, 96)}
    };
    public WordleRow() : this(true) { }
    public WordleRow(bool isReadOnly)
    {
        InitializeComponent();
        SetReadOnly(isReadOnly);
    }
    public string InputWord
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (UIElement element in this.Children)
            {
                if (element is LetterBox lb)
                    sb.Append(lb.Text);
            }
            string result = sb.ToString(); 
            if (!result.All(Char.IsLetter))
                throw new ArgumentException(result);
            return result.ToLower();
        }
    }
    public void ColorWord(Status[] statuses)
    {
        int n = statuses.Length;
        for (int i = 0; i < n; i++)
        {
            if (FindName($"Letter_{i}") is LetterBox lb)
            {
                lb.Background = new SolidColorBrush(bgColors[statuses[i]]);
                lb.IsReadOnly = true;
            }
        }
    }
    public void SetReadOnly(bool value)
    {
        foreach(LetterBox lb in Children)
            lb.IsReadOnly = value;
    }
}
