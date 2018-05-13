using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNYY
{
    public partial class AdminLogin : Form
    {
        OtherFunction otherFunction = new OtherFunction();
        public AdminLogin()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            this.Load += AdminLogin_Load;
            this.FormClosing += AdminLogin_FormClosing;
        }

        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string adminName = textBox1.Text, pwd = otherFunction.SHA1(textBox2.Text,Encoding.UTF8);
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Admin WHERE adminName='"+adminName+"' AND pwd='"+pwd+"'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            if (dataView.Count != 0)
            {              
                otherFunction.LoginName = dataView[0]["adminName"].ToString();
                otherFunction.ChangeStuPower = dataView[0]["changeStuPower"].ToString();
                otherFunction.IsSuperAdmin = dataView[0]["isSuperAdmin"].ToString();
                if (MessageBox.Show("登陆成功", "登陆成功，是否进入系统？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {               
                    this.Hide();
                    MainFram mainFram = new MainFram();
                    mainFram.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误！！");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示  
                textBox2.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示  
                textBox2.PasswordChar = '*';
            }
        }

        

    }
}
