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
    public partial class ManageDepartments : Form
    {
        public ManageDepartments()
        {
            InitializeComponent();
            this.Load += ManageDepartments_Load;
            dataGridView1.Click += DataGridView1_Click;
            button1.Click += Button1_Click; // 修改
            button2.Click += Button2_Click; // 删除
            button3.Click += Button3_Click; // 添加
        }      
        // 修改部门名字
        private void Button1_Click(object sender, EventArgs e)
        {
            if(label2.Text== "请选择一项")
            {
                MessageBox.Show("请选择需要修改哪个部门");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入部门名称");
                }
                else
                {
                    if (MessageBox.Show("确认修改？", "是否提交修改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        String sqlLanguage = "UPDATE Department SET departName='"+ textBox1.Text + "'  WHERE departNo='" + label2.Text + "'";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            MessageBox.Show("修改成功！");
                            GetNewValues();
                        }
                        else
                            MessageBox.Show("修改失败！");
                    }
                }
            }
            
        }
        // 删除部门
        private void Button2_Click(object sender, EventArgs e)
        {

            if (label2.Text == "请选择一项")
            {
                MessageBox.Show("请选择需要删除哪个部门");
            }
            else
            {
                DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Department where departNo='" + label2.Text + "'");
                DataView dataView = dataSet.Tables[0].DefaultView;
                if (dataView.Count == 0)
                {
                    MessageBox.Show("此部门不存在");
                }
                else
                {
                    if (MessageBox.Show("确认删除？", "是否删除" + dataView[0]["departName"] + "部门？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        String sqlLanguage = "DELETE Department WHERE departNo='" + label2.Text + "'";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            MessageBox.Show("删除成功！");
                            GetNewValues();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }

            }
        }
        // 添加部门
        // 先比对有没有部门，再执行sql
        private void Button3_Click(object sender, EventArgs e)
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Department");
            DataView dataView = dataSet.Tables[0].DefaultView;
            bool haveDpt = false;
            String departNo = "";
            for (int i = 0; i < dataView.Count; i++)
            {
                if (dataView[i]["departName"].ToString() == textBox2.Text)
                {
                    MessageBox.Show("已存在此部门，请检查部门名称");
                    haveDpt = true;
                    break;
                }
                departNo = (Convert.ToInt32(dataView[i]["departNo"]) + 1).ToString();
            }
            if (departNo == "") departNo = "1";
            if (!haveDpt)
            {
                String sqlLanguage = "INSERT Department VALUES('" + departNo + "','" + textBox2.Text + "')";
                if (SqlFunction.Execute(sqlLanguage) > 0)
                {
                    MessageBox.Show("插入成功！");
                    GetNewValues();
                }
                else
                    MessageBox.Show("插入失败！");
            }
        }

        // 点击table 填充数据 激活按钮
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                OtherFunction otherFunction = new OtherFunction();
                label2.Text = otherFunction.GetSelectValue(dataGridView1)[0];
                textBox1.Text = otherFunction.GetSelectValue(dataGridView1)[1];
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void ManageDepartments_Load(object sender, EventArgs e)
        {
            GetNewValues();
        }


        public void GetNewValues()
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Department");
            DataView dataView = dataSet.Tables[0].DefaultView;
            dataGridView1.DataSource = dataView;
            label2.Text = "请选择一项";
            textBox1.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            dataGridView1.Columns[0].HeaderCell.Value = "部门编号";
            dataGridView1.Columns[1].HeaderCell.Value = "部门名称";

        }

        private void ManageDepartments_Load_1(object sender, EventArgs e)
        {

        }
    }
}
