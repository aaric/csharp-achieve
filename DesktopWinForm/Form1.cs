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
    public partial class Form1 : Form
    {
        public Button buttonCode { get; set; }

        public Form1()
        {
            InitializeComponent();

            // 1.代码按钮
            buttonCode = new Button();
            buttonCode.Location = new Point(10, 10);
            buttonCode.Size = new Size(100, 40);
            buttonCode.Text = "代码按钮";

            // 2.添加按钮事件
            buttonCode.Click += new System.EventHandler(buttonCode_Click);

            // 3.添加按钮到界面
            this.Controls.Add(buttonCode);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "点击事件";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "鼠标悬浮";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "鼠标离开";
        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            //buttonCode.Text = "点击OK";
            Button btnCode = (Button)sender;
            btnCode.Text = "点击OK";
        }
    }
}
