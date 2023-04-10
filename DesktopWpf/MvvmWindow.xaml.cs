using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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
    /// MvvmWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MvvmWindow : Window
    {
        public MvvmWindow()
        {
            InitializeComponent();

            this.DataContext = new MvvmWindowModel();
        }
    }

    public class MvvmWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MyButtonCommand MyButtonCommand { get; set; }

        private string myLabel;

        public string MyLabel
        {
            get => myLabel;
            set
            {
                myLabel = value;
                NotifyPropertyChanged();
            }
        }

        public MvvmWindowModel()
        {
            this.MyButtonCommand = new MyButtonCommand(Show);
        }

        public void Show()
        {
            string tips = "hello world";
            this.MyLabel = tips;
            MessageBox.Show(tips);
        }
    }

    public class MyButtonCommand : ICommand
    {
        public Action MvvmWindowAction { get; set; }

        public MyButtonCommand(Action action)
        {
            this.MvvmWindowAction = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.MvvmWindowAction();
        }
    }
}
