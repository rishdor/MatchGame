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

namespace wpftryout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "𓆏", "𓆏",
                "𓆈", "𓆈",
                "𓆙", "𓆙",
                "𓃰", "𓃰",
                "𓃯", "𓃯",
                "𓃱", "𓃱",
                "𓄇", "𓄇",
                "𓄃", "𓄃"
            };
            Random rndm = new Random();
            foreach (TextBlock tb in mainGrid.Children.OfType<TextBlock>())
            {
                int i = rndm.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[i];
                tb.Text = nextEmoji;
                animalEmoji.RemoveAt(i);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

    }
}
