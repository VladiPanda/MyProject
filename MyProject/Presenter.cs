using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Presenter
    {
        Model model;
        MainWindow mainWindow;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.model = new Model();
            this.mainWindow.SomeEvent += MainWindow_SomeEvent;

        }

         void MainWindow_SomeEvent(object sender, EventArgs e)
        {
            this.mainWindow.TextBox1.Text = this.model.SomeMethod(this.mainWindow.TextBox1.Text);
        }
    }
}
