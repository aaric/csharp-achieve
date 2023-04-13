using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

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

            WeakReferenceMessenger.Default.Register<string, string>(this, "Token", (s, e) => { MessageBox.Show(e); });
        }
    }

    public class MvvmWindowModel : ObservableObject
    {
        public RelayCommand<string> MyButtonCommand { get; set; }

        private string myLabel;

        public string MyLabel
        {
            get => myLabel;
            set
            {
                myLabel = value;
                OnPropertyChanged();
            }
        }

        public MvvmWindowModel()
        {
            this.MyButtonCommand = new RelayCommand<string>(Show);
        }

        public void Show(String content)
        {
            // string tips = "hello world";
            this.MyLabel = content;
            //MessageBox.Show(tips);
            WeakReferenceMessenger.Default.Send(content, "Token");
        }
    }
}