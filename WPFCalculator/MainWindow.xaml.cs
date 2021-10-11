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
        double firstNumberContainer = 0;
        double secondNumberContainer = 0;
        string operation = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String strNumber = button.Content.ToString();

            if (TextBox.Text == "0")
            {
                TextBox.Text = strNumber;
            }
            else
            {
                TextBox.Text += strNumber;
            }

            if(operation == "")
            {
                firstNumberContainer = double.Parse(TextBox.Text);
            }
            else
            {
                secondNumberContainer = double.Parse(TextBox.Text);
            }
           
        }

        private void Button_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            TextBox.Text = "0";
        }
        
        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;

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
                    result = Math.Pow(firstNumberContainer, (int)secondNumberContainer);
                    break;

            }
            TextBox.Text = result.ToString();
            operation = "";
            firstNumberContainer = result;
            secondNumberContainer = 0;
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
            

            TextBox.Text = DeleteLastChar(TextBox.Text);

            if(operation == "")
            {
                firstNumberContainer = double.Parse(TextBox.Text);

            }
            else
            {
                secondNumberContainer = double.Parse(TextBox.Text);
            }
        }

        private string DeleteLastChar(string textNumber)
        {
            // convert the number to string and remove the last character

            if (textNumber.Length == 1)
            {
                textNumber = "0";
            }
            else
            {
                textNumber = textNumber.Remove(textNumber.Length - 1, 1);
                if (textNumber[textNumber.Length - 1] == ',')
                {
                    textNumber = textNumber.Remove(textNumber.Length - 1, 1);
                }
            }
            return textNumber;
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

        private void Button_comma_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                SetComma(firstNumberContainer);
            }
            else
            {
                SetComma(secondNumberContainer);
            }
        }

        private void SetComma(double number)
        {
            if(TextBox.Text.Contains(','))
            {
                return;
            }
            else
            {
                TextBox.Text += ',';
            }
            
        }
    }
}
