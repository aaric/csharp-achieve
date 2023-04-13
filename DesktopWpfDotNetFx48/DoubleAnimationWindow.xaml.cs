using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DesktopWpf
{
    /// <summary>
    /// AnimationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DoubleAnimationWindow : Window
    {
        public DoubleAnimationWindow()
        {
            InitializeComponent();
        }

        private void AnimationButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = this.AnimationButton.Width;
            // animation.To = this.AnimationButton.Width - 15;
            // animation.Duration = TimeSpan.FromSeconds(2);
            animation.By = -15;
            animation.AutoReverse = true;
            // animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.RepeatBehavior = new RepeatBehavior(3);
            animation.Completed += Animation_Completed;

            this.AnimationButton.BeginAnimation(WidthProperty, animation);
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            this.AnimationButton.Content = "动画结束";
        }
    }
}