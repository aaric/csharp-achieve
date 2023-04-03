using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = textBox2.Text;
            if ("admin" == account && "123456" == password)
            {
                //MessageBox.Show("账号密码正确");
                new MainForm(account).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }
    }
}
