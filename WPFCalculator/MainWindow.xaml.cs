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
        int numberContainer = 0;
        int secondNumberContainer = 0;
        string operation = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                numberContainer = numberContainer * 10 + 7;
                TextBox.Text = numberContainer.ToString();
            }
            else
            {
                secondNumberContainer = secondNumberContainer * 10 + 7;
                TextBox.Text = secondNumberContainer.ToString();
            }
           
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                numberContainer = numberContainer * 10 + 8;
                TextBox.Text = numberContainer.ToString();
            }
            else
            {
                secondNumberContainer = secondNumberContainer * 10 + 8;
                TextBox.Text = secondNumberContainer.ToString();
            }
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
        }

        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            switch (operation)
            {
                case "+":
                    result = numberContainer + secondNumberContainer;
                    break;

            }

            TextBox.Text = result.ToString();
            operation = "";
            numberContainer = result;
        }
    }
}
