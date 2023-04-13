using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public void NotifyPropertyChanged(string propertyName)
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyViewModel : BaseViewModel
    {

        public MvvmCommand MyCommand { get; set; }

        private string myName;

        public string MyName {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyName"));
                //NotifyPropertyChanged("MyName");
                NotifyPropertyChanged();
            }
        }

        public MyViewModel()
        {
            this.MyCommand = new MvvmCommand(Show);
            this.MyName = "hello pwf";
        }

        public void Show()
        {
            string tips = "hello world";
            MessageBox.Show(tips);
            this.MyName = tips;
        }
    }

    public class MvvmCommand : ICommand
    {
        public Action MyAction { get; set; }

        public MvvmCommand(Action myAction)
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
