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
    public partial class ResetAdmin : Form
    {
        OtherFunction otherFunction = new OtherFunction();
        public ResetAdmin()
        {
            InitializeComponent();
            this.Load += ResetAdmin_Load;
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String adminName = textBox1.Text;
            String pwd = textBox2.Text;
            String rePwd = textBox3.Text;
            if (adminName != "" || pwd != "")
            {
                if (pwd == rePwd)
                {
                    pwd = otherFunction.SHA1(pwd, Encoding.UTF8);
                    DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Admin Where adminName='" + adminName + "'");
                    DataView dataView = dataSet.Tables[0].DefaultView;
                    if (dataView.Count == 0 || adminName == otherFunction.LoginName)
                    {
                        if (MessageBox.Show("确认修改？", "是否提交修改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            String sqlLanguage = "UPDATE Admin SET adminName='" + adminName + "',pwd='" + pwd + "' WHERE adminName = '" + otherFunction.LoginName + "'";
                            if (SqlFunction.Execute(sqlLanguage) > 0)
                            {
                                MessageBox.Show("修改成功！");
                                otherFunction.LoginName = adminName;
                            }
                            else
                                MessageBox.Show("妈呀！修改失败咯！！！！怎么肥事？");
                        }
                    }
                    else MessageBox.Show("已经存在当前管理员");
                }
                else MessageBox.Show("确认密码不相符，请确认密码");
            }
            else
                MessageBox.Show("用户名和密码均不能空！！");
        }

        private void ResetAdmin_Load(object sender, EventArgs e)
        {
            
            label5.Text = otherFunction.LoginName;
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }
    }
}
