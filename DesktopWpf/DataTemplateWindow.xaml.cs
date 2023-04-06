using System.Collections.Generic;
using System.Windows;

namespace DesktopWpf
{
    /// <summary>
    /// DataTemplateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateWindow : Window
    {
        public DataTemplateWindow()
        {
            InitializeComponent();

            // origin
            /*for (int i = 0; i < 10; i++)
            {
                listBoxSimple.Items.Add(new ListBoxItem() { 
                    Content= i.ToString()
                });
            }*/

            // new
            List<ListBoxItemData> list = new List<ListBoxItemData>();
            list.Add(new ListBoxItemData() { Name = "Red", Value = "Red" });
            list.Add(new ListBoxItemData() { Name = "Yellow", Value = "Yellow" });
            list.Add(new ListBoxItemData() { Name = "Green", Value = "Green" });
            list.Add(new ListBoxItemData() { Name = "Blue", Value = "Blue" });
            list.Add(new ListBoxItemData() { Name = "Purple", Value = "Purple" });

            ListBoxSimple.ItemsSource = list;
            DataGridSimple.ItemsSource = list;
        }
    }

    public class ListBoxItemData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}