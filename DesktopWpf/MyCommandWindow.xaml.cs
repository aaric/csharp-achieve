using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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

    public class MyViewModel : INotifyPropertyChanged
    {

        public MyCommand MyCommand { get; set; }

        private string myName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MyName {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyName"));
            }
        }

        public MyViewModel()
        {
            this.MyCommand = new MyCommand(Show);
            this.MyName = "hello pwf";
        }

        public void Show()
        {
            string tips = "hello world";
            MessageBox.Show(tips);
            this.MyName = tips;
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
