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
using System.Threading;
using System.Windows.Threading;

namespace wpftryout
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        
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
                if (tb.Name != "timeTextBlock")
                {
                    tb.Visibility = Visibility.Visible;
                    int i = rndm.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[i];
                    tb.Text = nextEmoji;
                    animalEmoji.RemoveAt(i);
                }
                
            }
            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;
            
        }
        
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed/10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        TextBlock lastTextBoxClicked;
        bool lookingForMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTextBlock = (TextBlock)sender;
            if (lookingForMatch == false)
            {
                currentTextBlock.Visibility= Visibility.Hidden;
                lastTextBoxClicked = currentTextBlock;
                lookingForMatch = true;
            }
            else if (lastTextBoxClicked.Text == currentTextBlock.Text)
            {
                matchesFound++;
                currentTextBlock.Visibility= Visibility.Hidden;
                lookingForMatch= false;
            }
            else
            {
                lastTextBoxClicked.Visibility = Visibility.Visible;
                lookingForMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
