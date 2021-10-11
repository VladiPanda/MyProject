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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int firstNumberContainer = 0;
        int secondNumberContainer = 0;
        string operation = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String str = button.Content.ToString();
            int number = Int32.Parse(str);

            if(operation == "")
            {
                firstNumberContainer = firstNumberContainer * 10 + number;
                TextBox.Text = firstNumberContainer.ToString();
            }
            else
            {
                secondNumberContainer = secondNumberContainer * 10 + number;
                TextBox.Text = secondNumberContainer.ToString();
            }
           
        }

        private void Button_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            
        }
        
        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumberContainer + secondNumberContainer;
                    break;
                case "-":
                    result = firstNumberContainer - secondNumberContainer;
                    break;
                case "*":
                    result = firstNumberContainer * secondNumberContainer;
                    break;
                case "/":
                    result = firstNumberContainer / secondNumberContainer;
                    break;
                case "min":
                    result = Math.Min(firstNumberContainer, secondNumberContainer);
                    break;
                case "max":
                    result = Math.Max(firstNumberContainer, secondNumberContainer);
                    break;
                case "avg":
                    result = (firstNumberContainer + secondNumberContainer) / 2;
                    break;
                case "x^y":
                    result = (int)Math.Pow(firstNumberContainer, secondNumberContainer);
                    break;

            }
            TextBox.Text = result.ToString();
            operation = "";
            firstNumberContainer = result;
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            firstNumberContainer = 0;
            secondNumberContainer = 0;
            operation = "";
            TextBox.Text = "0";
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                firstNumberContainer = 0;
            }
            else
            {
                secondNumberContainer = 0;
            }
            TextBox.Text = "0";
        }

        private void Button_backspace_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                firstNumberContainer = firstNumberContainer / 10;
                TextBox.Text = firstNumberContainer.ToString();
            }
            else
            {
                secondNumberContainer = secondNumberContainer / 10;
                TextBox.Text = secondNumberContainer.ToString();
            }
        }

        private void Button_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                firstNumberContainer *= -1;
                TextBox.Text = firstNumberContainer.ToString();
            }
            else
            {
                secondNumberContainer *= -1;
                TextBox.Text = secondNumberContainer.ToString();
            }
        }
    }
}
