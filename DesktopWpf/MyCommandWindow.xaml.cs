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
using System.Windows.Shapes;

namespace DesktopWpf
{
    /// <summary>
    /// ICommandWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MyCommandWindow : Window
    {
        public MyCommandWindow()
        {
            InitializeComponent();

            this.DataContext = new MyViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world");
        }
    }

    public class MyViewModel
    {
        public MyCommand MyCommand { get; set; }

        public MyViewModel()
        {
            this.MyCommand = new MyCommand(Show);
        }

        public void Show()
        {
            MessageBox.Show("hello world");
        }
    }

    public class MyCommand : ICommand
    {
        public Action MyAction { get; set; }

        public MyCommand(Action myAction)
        {
            this.MyAction = myAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.MyAction();
        }
    }
}
