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
    public WordleRow()
    {
        InitializeComponent();
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
            if (result.All(Char.IsLetter))
                throw new ArgumentException();
            return result.ToLower();
        }
    }
    public void ColorWord(Status statuses)
    {

    }
}
