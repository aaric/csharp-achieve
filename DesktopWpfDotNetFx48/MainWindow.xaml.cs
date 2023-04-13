using System.Windows;

namespace DesktopWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTest_OnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("点击事件");
            this.BtnTest.Content = "点击事件";
        }
    }
}