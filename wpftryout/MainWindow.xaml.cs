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
using System.Runtime.CompilerServices;

namespace Matching_game
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        string time = "0";
        string besttime = "0";

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
                "𓄃", "𓄃",
                "𓃬", "𓃬",
                "𓃠", "𓃠",
                "𓃟", "𓃟",
                "𓃗", "𓃗",
                "𓅞", "𓅞",
                "𓅮", "𓅮"

            };
            Random rndm = new Random();

            List<string> animals = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                int index = rndm.Next(animalEmoji.Count);
                animals.Add(animalEmoji[index]);
                if (index % 2 == 0)
                {
                    animals.Add(animalEmoji[index + 1]);
                    animalEmoji.RemoveAt(index);
                    animalEmoji.RemoveAt(index);
                }
                else
                {
                    animals.Add(animalEmoji[index - 1]);
                    animalEmoji.RemoveAt(index);
                    animalEmoji.RemoveAt(index - 1);
                }
            }
            foreach (TextBlock tb in mainGrid.Children.OfType<TextBlock>())
            {
                if (tb.Name != "timeTextBlock" && tb.Name != "scoreTextBox")
                {
                    tb.Visibility = Visibility.Visible;
                    tb.Foreground = new SolidColorBrush(Colors.Transparent);
                    int index2 = rndm.Next(animals.Count);
                    string nextEmoji = animals[index2];
                    tb.Text = nextEmoji;
                    animals.RemoveAt(index2);


                    //tb.Background = new SolidColorBrush(Colors.Gray);
                }
                
            }
            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;
            Best_Time();

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
                time = timeTextBlock.Text.Substring(0,3);
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }
        private void Best_Time()
        {
            if (double.Parse(time) < double.Parse(besttime) || besttime == "0")
            {
                besttime = time;
            }
            scoreTextBox.Text = ("Best time:  " + besttime + "s");
        } 

        TextBlock lastTextBoxClicked;
        bool lookingForMatch = false;

        private async void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTextBlock = (TextBlock)sender;
            if (lookingForMatch == false)
            {
                currentTextBlock.Foreground = new SolidColorBrush(Colors.ForestGreen);
                lastTextBoxClicked = currentTextBlock;
                lookingForMatch = true;
            }
            else if (lastTextBoxClicked.Text == currentTextBlock.Text)
            {
                matchesFound++;
                lookingForMatch = false;
                currentTextBlock.Foreground = new SolidColorBrush(Colors.Gray);
                lastTextBoxClicked.Foreground = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                currentTextBlock.Foreground = new SolidColorBrush(Colors.ForestGreen);
                lookingForMatch = false;
                await Task.Delay(300);
                currentTextBlock.Foreground = new SolidColorBrush(Colors.Transparent);
                lastTextBoxClicked.Foreground = new SolidColorBrush(Colors.Transparent);
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
