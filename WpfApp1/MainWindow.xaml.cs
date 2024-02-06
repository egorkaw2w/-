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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button[] buttons;
        Button[] truebut;
        bool Player;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            truebut = buttons.Where(b => b.IsEnabled == true).ToArray();
            Player = false;
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            if (Player == true)
            {
                (sender as Button).Content = "X";
                (sender as Button).IsEnabled = false;
            }
            else
            {
                (sender as Button).Content = "O";
                (sender as Button).IsEnabled = false;
            }

            checkingWin();

            bot();
        }
        void bot()
        {

            /*           Button[] buttons = { _1, _2, _3, _4, _5, _6, _7, _8, _9 };*/
            Random random = new Random();
            Button[] truebut = buttons.Where(b => b.IsEnabled == true).ToArray();
            int choice = random.Next(0, truebut.Length);
            if (truebut.Length == 0)
            {
                return;
            }

            truebut[choice].Content = Player ? "O" : "X";
            truebut[choice].IsEnabled = false;
            checkingWin();
        }
        private void NewGameBut_Click(object sender, RoutedEventArgs e)
        {
            /*      Button[] buttons = { _1, _2, _3, _4, _5, _6, _7, _8, _9 };*/
            changing();
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            truebut = buttons.Where(b => b.IsEnabled == true).ToArray();
            if (Player == false)
            {
                bot();
            }

        }

        void checkingWin()
        {

            truebut = buttons.Where(b => b.IsEnabled == true).ToArray();

            if (_1.Content != "" && _1.Content == _2.Content && _2.Content == _3.Content)
            {
                MessageBox.Show($"Победа {_1.Content}"); blocking();
            }
            else if (_4.Content != "" && _4.Content == _5.Content && _5.Content == _6.Content)
            {
                MessageBox.Show($"Победа {_4.Content}"); blocking();
            }
            else if (_7.Content != "" && _7.Content == _8.Content && _8.Content == _9.Content)
            {
                MessageBox.Show($"Победа {_7.Content}"); blocking();
            }
            else if (_1.Content != "" && _1.Content == _4.Content && _4.Content == _7.Content)
            {
                MessageBox.Show($"Победа {_1.Content}"); blocking();
            }
            else if (_2.Content != "" && _2.Content == _5.Content && _5.Content == _8.Content)
            {
                MessageBox.Show($"Победа {_2.Content}"); blocking();
            }
            else if (_3.Content != "" && _3.Content == _6.Content && _6.Content == _9.Content)
            {
                MessageBox.Show($"Победа {_3.Content}"); blocking();
            }

            else if (_1.Content != "" && _1.Content == _5.Content && _5.Content == _9.Content)
            {
                MessageBox.Show($"Победа {_1.Content}"); blocking();
            }
            else if (_3.Content != "" && _3.Content == _5.Content && _5.Content == _7.Content)
            {
                MessageBox.Show($"Победа {_3.Content}"); blocking();
            }
            else if (truebut.Length == 0)
            {
                MessageBox.Show("Ничя :("); blocking();
            }


        }
        void changing() //смена стороны
        {
            if (Player == true)
            {
                Player = false;
                lablya.Content = "ты играешь (ахуеть) за Нолики";
            }
            else
            {
                Player = true;
                lablya.Content = "ты играешь (пизданёшься) за Крестики";
            }
        }
        void blocking()
        {
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

    }
}
