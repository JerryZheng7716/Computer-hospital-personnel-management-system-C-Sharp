using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DNYY
{
    public partial class AdminManage : Form
    {
        String adminName, pwd, changeStuPower, isSuperAdmin,rePwd;
        String oldAdminName;
        OtherFunction otherFunction = new OtherFunction();
        public AdminManage()
        {
            InitializeComponent();
            this.Load += AdminManage_Load;
            button1.Click += Button1_Click;  // 绑定添加管理员
            button2.Click += Button2_Click;  // 绑定修改管理员
            dataGridView1.Click += DataGridView1_Click;
            button3.Click += Button3_Click;// 绑定删除管理员
        }

        
        // 点击Grid 填充数据
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = otherFunction.GetSelectValue(dataGridView1)[0];
                oldAdminName = textBox1.Text;
                if (otherFunction.GetSelectValue(dataGridView1)[2] == "True")
                {
                    radioButton1.Select();
                }
                else { 
                    radioButton2.Select();
                }
                if (otherFunction.GetSelectValue(dataGridView1)[3] == "True")
                {
                    radioButton3.Select();
                }
                else { 
                    radioButton4.Select();
                }
                button2.Enabled = true;
                button3.Enabled = true;
            }      
        }
        
        // 添加管理员
        private void Button1_Click(object sender, EventArgs e)
        {
            adminName = textBox1.Text;
            pwd = textBox2.Text;
            rePwd = textBox3.Text;
            if (radioButton1.Checked)
                changeStuPower = "1";
            else
                changeStuPower = "0";
            if (radioButton3.Checked)
                isSuperAdmin = "1";
            else
                isSuperAdmin = "0";
            if (adminName != "" || pwd != "")
            {
                if (pwd == rePwd)
                {
                    pwd = otherFunction.SHA1(pwd, Encoding.UTF8);
                    DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Admin Where adminName='" + adminName + "'");
                    DataView dataView = dataSet.Tables[0].DefaultView;
                    if (dataView.Count == 0)  // 先和数据库里的进行判断 是否存在
                    {
                        String sqlLanguage = "INSERT Admin VALUES('" + adminName + "','" + pwd + "','" + changeStuPower + "','" + isSuperAdmin + "')";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            MessageBox.Show("插入成功！");
                            GetNewValues();
                        }
                        else { 
                            MessageBox.Show("插入失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经存在当前管理员");
                    }
                }
                else
                {
                    MessageBox.Show("确认密码不相符，请确认密码");
                }
            }
            else {
                MessageBox.Show("用户名和密码均不能空！！");
            }
                
            

        }
        // 修改 管理员
        private void Button2_Click(object sender, EventArgs e)
        {
            adminName = textBox1.Text;
            pwd = textBox2.Text;
            rePwd = textBox3.Text;
            // 人员修改权限
            if (radioButton1.Checked)
                changeStuPower = "1";
            else
                changeStuPower = "0";
            // 超级管理员权限
            if (radioButton3.Checked)
                isSuperAdmin = "1";
            else
                isSuperAdmin = "0";
            if (adminName != "" || pwd != "")
            {
                if (pwd == rePwd)
                {
                    pwd = otherFunction.SHA1(pwd, Encoding.UTF8);  // 密码加密
                    DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Admin Where adminName='" + adminName + "'");
                    DataView dataView = dataSet.Tables[0].DefaultView;
                    if (dataView.Count == 0 || adminName == oldAdminName)
                    {
                        if (MessageBox.Show("确认修改？", "是否提交修改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            String sqlLanguage = "UPDATE Admin SET adminName='" + adminName + "',pwd='" + pwd + "',changeStuPower='" + changeStuPower + "',isSuperAdmin='" + isSuperAdmin + "' WHERE AdminName='" + oldAdminName + "'";
                            if (SqlFunction.Execute(sqlLanguage) > 0)
                            {
                                MessageBox.Show("修改成功！");
                                if (adminName == otherFunction.LoginName)
                                {
                                    otherFunction.LoginName = adminName;
                                }
                                GetNewValues();
                            }
                            else
                                MessageBox.Show("修改失败！");
                        }
                    }
                    else MessageBox.Show("已经存在当前管理员");
                }
                else MessageBox.Show("确认密码不相符，请确认密码");
            }
            else
                MessageBox.Show("用户名和密码均不能空！！");
        }
        // 删除管理员
        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "是否删除 " + oldAdminName + " 管理员？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String sqlLanguage = "DELETE Admin WHERE AdminName='" + oldAdminName + "'";
                if (SqlFunction.Execute(sqlLanguage) > 0)
                {
                    MessageBox.Show("删除成功！");
                    GetNewValues();
                }
                else
                    MessageBox.Show("妈呀！删除失败咯！！！！怎么肥事？");
            }
        }
        private void AdminManage_Load(object sender, EventArgs e)
        {
            GetNewValues();
            radioButton2.Select();
            radioButton4.Select();
            button2.Enabled = false;
            button3.Enabled = false;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void GetNewValues()
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Admin");
            DataView dataView = dataSet.Tables[0].DefaultView;
            dataGridView1.DataSource = dataView;         
            button3.Enabled = false;
            button2.Enabled = false;
            dataGridView1.Columns[0].HeaderCell.Value = "用户名";
            dataGridView1.Columns[1].HeaderCell.Value = "密码";
            dataGridView1.Columns[2].HeaderCell.Value = "用户修改权限";
            dataGridView1.Columns[3].HeaderCell.Value = "超级管理员";
        }
        

    }
}
