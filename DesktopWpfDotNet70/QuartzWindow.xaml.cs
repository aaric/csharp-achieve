using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Quartz;
using Quartz.Impl;

namespace DesktopWpfDotNet70
{
    /// <summary>
    /// QuartzWindow.xaml 的交互逻辑
    /// </summary>
    public partial class QuartzWindow : Window
    {
        public QuartzWindow()
        {
            InitializeComponent();

            this.DataContext = new QuartzWindowDataContext(this);
        }
    }

    /// <summary>
    /// QuartzWindow.xaml 的数据上下文
    /// </summary>
    public class QuartzWindowDataContext : ObservableObject
    {
        public Window? Window;
        public RelayCommand<string> MyTestCommand { get; set; }
        public IScheduler? Scheduler;
        public bool SchedulerPauseState = false;

        private string myLog;

        public string MyLog
        {
            get => myLog;
            set
            {
                myLog = value;
                OnPropertyChanged();
            }
        }

        public QuartzWindowDataContext(Window window)
        {
            this.MyTestCommand = new RelayCommand<string>(click);
            this.myLog = "日志内容：\n";
            
            WeakReferenceMessenger.Default.Register<string, string>(this, "JobMsg", (s, e) =>
            {
                this.MyLog += $"{e}\n";
            });
        }

        // https://www.quartz-scheduler.net/documentation/quartz-3.x/quick-start.html
        private async void click(string? action)
        {
            switch (action)
            {
                case "start":
                    // 启动任务
                    if (null == this.Scheduler)
                    {
                        ISchedulerFactory factory = new StdSchedulerFactory();
                        IScheduler scheduler = await factory.GetScheduler();
                        await scheduler.Start();

                        IJobDetail job = JobBuilder.Create<SimpleJob>()
                            .WithIdentity("job1", "group1")
                            .Build();
                        ITrigger trigger = TriggerBuilder.Create()
                            .WithIdentity("trigger1", "group1")
                            .WithSimpleSchedule(o => o.WithIntervalInSeconds(3).RepeatForever())
                            .Build();
                        await scheduler.ScheduleJob(job, trigger);

                        this.Scheduler = scheduler;
                        this.MyLog += "start ok\n";
                    }
                    
                    break;
                case "pause":
                    // 暂停任务
                    if (null != this.Scheduler)
                    {
                        if (!this.SchedulerPauseState)
                        {
                            await this.Scheduler.PauseAll();
                            this.SchedulerPauseState = true;
                            this.MyLog += "pause ok\n";
                        }
                        else
                        {
                            await this.Scheduler.ResumeAll();
                            this.SchedulerPauseState = false;
                            this.MyLog += "start ok\n";
                        }
                    }
                    break;
            }
        }
    }

    public class SimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            { 
                WeakReferenceMessenger.Default.Send("hello world", "JobMsg");
            });
        }
    }
}
