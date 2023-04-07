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
    /// DynamicResourceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DynamicResourceWindow : Window
    {
        public DynamicResourceWindow()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["CustomSolidColorBrush"] = new SolidColorBrush(Colors.Green);

            var defaultSolidColorBrush = App.Current.FindResource("DefaultSolidColorBrush");
            Console.WriteLine(defaultSolidColorBrush.ToString());
        }
    }
}
