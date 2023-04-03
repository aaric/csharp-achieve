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
    public partial class MainForm : Form
    {
        public string Account { get; set; }

        //public MainForm(string account)
        public MainForm()
        {
            //this.Account = account;
            this.Account = StorageHelper.Instance.Account;

            InitializeComponent();

            label1.Text = $"欢迎{this.Account}使用该系统！";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
