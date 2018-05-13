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
    public partial class MainFram : Form
    {
        OtherFunction otherFunction = new OtherFunction();
        public MainFram()
        {
            InitializeComponent();
            this.Load += MainFram_Load;
            timer1.Tick += Timer1_Tick;
            部门管理ToolStripMenuItem.Click += 部门管理ToolStripMenuItem_Click;
            管理员设置ToolStripMenuItem.Click += 管理员设置ToolStripMenuItem_Click;
            修改密码ToolStripMenuItem.Click += 修改密码ToolStripMenuItem_Click;
            人员管理ToolStripMenuItem.Click += 管理人员ToolStripMenuItem_Click;
            活动管理ToolStripMenuItem.Click += 活动管理ToolStripMenuItem_Click;
            管理考勤信息ToolStripMenuItem.Click += 管理考勤信息ToolStripMenuItem_Click;
            考勤信息查询ToolStripMenuItem.Click += 考勤信息查询ToolStripMenuItem_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            this.FormClosed += MainFram_FormClosed;
        }

        private void 考勤信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceSearch attendanceSearch = new AttendanceSearch();
            attendanceSearch.Show();
        }

        private void MainFram_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            otherFunction.ChangeStuPower = "False";
            otherFunction.IsSuperAdmin = "False";
            otherFunction.LoginName = "";
            this.Close();
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AttendanceSearch attendanceSearch = new AttendanceSearch();
            attendanceSearch.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StudentManage studentManage = new StudentManage();
            studentManage.ShowDialog();
            Init();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AttendanceManage attendanceManage = new AttendanceManage();
            attendanceManage.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ActivityManage activityManage = new ActivityManage();
            activityManage.ShowDialog();
        }

        private void 管理考勤信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceManage attendanceManage = new AttendanceManage();
            attendanceManage.ShowDialog();
        }

        private void 活动管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivityManage activityManage = new ActivityManage();
            activityManage.ShowDialog();
        }

        private void 管理人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentManage studentManage = new StudentManage();
            studentManage.ShowDialog();
            Init();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAdmin resetAdmin = new ResetAdmin();
            resetAdmin.ShowDialog();
            Init();

        }

        private void 管理员设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
            if (otherFunction.IsSuperAdmin == "True")
            {
                AdminManage adminManage = new AdminManage();
                adminManage.ShowDialog();
            }
            else
                MessageBox.Show("对不起！您当前没有权限对此进行访问！");
            
        }

        private void 部门管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (otherFunction.ChangeStuPower == "True")
            {
                ManageDepartments manageDepartment = new ManageDepartments();
                manageDepartment.ShowDialog();
            }else
                MessageBox.Show("对不起！您当前没有权限对此进行访问！");

        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String date = dt.ToLongDateString().ToString();
            String time = dt.ToLongTimeString().ToString();
            label2.Text = "当前时间：" + date + time;
        }

        private void MainFram_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            Init();
            
        }

        public void Init()
        {
            String isSuperAdmin = "", sumStudent;
            if (otherFunction.IsSuperAdmin == "True")
            {
                isSuperAdmin = "超级管理员";
            }

            label1.Text = "欢迎您 " + isSuperAdmin + "：" + otherFunction.LoginName;
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Student");
            DataView dataView = dataSet.Tables[0].DefaultView;
            sumStudent = dataView.Count.ToString();
            label3.Text = "电脑医院在职总人数：" + sumStudent;
        }
    }
}
