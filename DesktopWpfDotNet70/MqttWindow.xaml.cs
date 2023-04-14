using System;
using System.Text;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DesktopWpfDotNet70
{
    /// <summary>
    /// MqttWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MqttWindow : Window
    {
        public MqttWindow()
        {
            InitializeComponent();

            this.DataContext = new MqttWindowDataContext(this);
        }
    }

    /// <summary>
    /// MqttWindow.xaml 的数据上下文
    /// </summary>
    public class MqttWindowDataContext : ObservableObject
    {
        private string myMsg;

        public string MyMsg
        {
            get => myMsg;
            set
            {
                myMsg = value;
                OnPropertyChanged();
            }
        }

        private string myReply;

        public string MyReply
        {
            get => myReply;
            set
            {
                myReply = value;
                OnPropertyChanged();
            }
        }

        public Window MqttWindow;

        public RelayCommand<string> MyTestCommand { get; set; }

        public MqttClient? Client;

        public MqttWindowDataContext(Window current)
        {
            this.myMsg = "hello world";
            this.myReply = "Hello Mqtt!\n";
            this.MqttWindow = current;
            this.MqttWindow.Closed += Window_Closed;
            this.MyTestCommand = new RelayCommand<string>(click);
        }

        private void Window_Closed(object? sender, EventArgs e)
        {
            // 释放资源
            if (null != this.Client && this.Client.IsConnected)
            {
                // MessageBox.Show("shutdown window...");
                this.Client.Disconnect();
            }
        }

        // https://docs.emqx.com/zh/cloud/latest/connect_to_deployments/c_sharp_sdk.html
        private void click(string? content)
        {
            switch (content)
            {
                case "connect":
                    // 连接
                    if (null == this.Client || !this.Client.IsConnected)
                    {
                        MqttClient client = new MqttClient("broker.emqx.io", 1883,
                            false, MqttSslProtocols.None, null, null);
                        client.Connect("csharp-client");
                        // client.Connect("csharp-client", null, null,
                        //     false, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true, "/msg/server/default", "886", true, 60);
                        if (client.IsConnected)
                        {
                            this.Client = client;

                            // MessageBox.Show("connect ok");
                            this.MyReply += "mqtt connect ok\n";
                        }
                        else
                        {
                            // MessageBox.Show("connect failure");
                            this.MyReply += "mqtt connect failure\n";
                        }
                    }
                    else
                    {
                        // MessageBox.Show("connected");
                        this.MyReply += "mqtt connected\n";
                    }

                    break;
                case "sub":
                    // 订阅消息
                    if (null != this.Client && this.Client.IsConnected)
                    {
                        this.Client.MqttMsgPublishReceived += MqttMsgPublishReceived_Topic;
                        this.Client.Subscribe(new string[] { "/msg/client/1" },
                            new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                    }

                    break;
                case "pub":
                    // 发布消息
                    if (null != this.Client && this.Client.IsConnected)
                    {
                        this.Client.Publish("/msg/server/default", Encoding.UTF8.GetBytes(this.myMsg));
                    }

                    break;
            }
        }

        private void MqttMsgPublishReceived_Topic(object sender, MqttMsgPublishEventArgs e)
        {
            string payload = Encoding.UTF8.GetString(e.Message);
            this.MyReply += $"{payload}\n";
        }
    }
}