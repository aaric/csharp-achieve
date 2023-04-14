using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Data.Sqlite;

namespace DesktopWpfDotNet70
{
    /// <summary>
    /// SQLiteWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SQLiteWindow : Window
    {
        public SQLiteWindow()
        {
            InitializeComponent();

            this.DataContext = new SQLiteWindowDataContext();
        }
    }

    /// <summary>
    /// SQLiteWindow.xaml 的数据上下文
    /// </summary>
    public class SQLiteWindowDataContext : ObservableObject
    {
        private string mySql;

        public string MySql
        {
            get => mySql;
            set
            {
                mySql = value;
                OnPropertyChanged();
            }
        }

        private string myResult;

        public string MyResult
        {
            get => myResult;
            set
            {
                myResult = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<string> MyTestCommand { get; set; }

        public SQLiteWindowDataContext()
        {
            this.mySql = string.Empty;
            this.myResult = "Hello SQLite!";
            this.MyTestCommand = new RelayCommand<string>(ExecuteSql);
        }

        private void Show(string content)
        {
            MessageBox.Show(content);
        }

        /// <summary>
        /// 参考SQL语法：
        /// 1. CREATE TABLE person ( _id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT);
        /// 2. INSERT INTO person (name) VALUES ('zhangsan');
        /// 3. UPDATE person SET name = 'wangwu' WHERE _id = 1;
        /// 4. SELECT * FROM person;
        /// </summary>
        /// <param name="content"></param>
        private void ExecuteSql(string? content)
        {
            // https://learn.microsoft.com/zh-cn/dotnet/standard/data/sqlite/?tabs=netcore-cli
            using (SqliteConnection connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = this.MySql;

                try
                {
                    if (!String.IsNullOrEmpty(this.MySql) && this.MySql.ToUpper().Contains("SELECT"))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            string result = "";
                            while (reader.Read())
                            {
                                result += $"{reader.GetString(0)}";
                                for (int i = 1; i < reader.FieldCount; i++)
                                {

                                    result += $", {reader.GetString(i)}";
                                }
                                result += "\n";
                            }

                            this.MyResult = $"结果：\n{result}";
                        }
                    }
                    else
                    {
                        int count = command.ExecuteNonQuery();
                        this.MyResult = $"已执行{count}条";
                    }
                }
                catch (Exception e)
                {
                    this.MyResult = $"异常：{e.Message}";
                }
            }
        }
    }
}