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
    public partial class ActivityManage : Form
    {
        String acId, acName, acPlace, acTime, stuNo, mark,oldName;
        OtherFunction otherFunction = new OtherFunction();
        String[] psString = { "%", "%" };
        String[] departArry;
        public ActivityManage()
        {
            InitializeComponent();
            this.Load += ActivityManage_Load;
            textBox4.TextChanged += TextBox4_TextChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            dataGridView2.Click += DataGridView2_Click;
            dataGridView1.Click += DataGridView1_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
        }

        private void Button3_Click(object sender, EventArgs e)//执行删除
        {
            if (MessageBox.Show("确认删除？", "是否删除 " + oldName+ " ？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String sqlLanguage = "DELETE Activity WHERE acId='" + acId + "'";
                if (SqlFunction.Execute(sqlLanguage) > 0)
                {
                    MessageBox.Show("删除成功！");
                    GetNewValues();
                }
                else
                    MessageBox.Show("妈呀！删除失败咯！！！！怎么肥事？");
            }
        }

        private void Button2_Click(object sender, EventArgs e)//执行更新数据
        {
            GetStringValues();
            if (acName != "" && acPlace != "" && stuNo != "")
            {
                //acId, acName, acPlace, acTime, stuNo, mark,oldName;
                if (stuNo != "查无此人")
                {
                    if (MessageBox.Show("确认修改？", "是否提交修改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        String sqlLanguage = "UPDATE Activity SET acName='" + acName + "',acPlace='" + acPlace + "', acTime='" + acTime + "',stuNo='" + stuNo +
                            "',mark='" + mark + "' WHERE acid='"+acId+"'";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            MessageBox.Show("插入成功！");
                            GetNewValues();
                        }
                        else
                            MessageBox.Show("妈呀！插入失败咯！！！！怎么肥事？");
                    }
                }
                else
                    MessageBox.Show("电脑医院不存在名为 " + textBox3.Text + " 的人！！", "请检查负责人姓名！");

            }
            else
                MessageBox.Show("所有内容均不可以为空！！");
        }

        private void Button1_Click(object sender, EventArgs e)//执行插入数据
        {
            GetStringValues();
            if (acName!=""&& acPlace!=""&& stuNo!="")
            {
                //acId, acName, acPlace, acTime, stuNo, mark,oldName;
                if(stuNo!= "查无此人")
                {
                    String sqlLanguage = "INSERT Activity(acName, acPlace, acTime, stuNo, mark) VALUES('" + acName + "','" + acPlace + "','" + acTime +
                         "','" + stuNo + "','" + mark + "')";
                    if (SqlFunction.Execute(sqlLanguage) > 0)
                    {
                        MessageBox.Show("插入成功！");
                        GetNewValues();
                    }
                    else
                        MessageBox.Show("妈呀！插入失败咯！！！！怎么肥事？");
                }
                else
                    MessageBox.Show("电脑医院不存在名为 "+ textBox3.Text+" 的人！！","请检查负责人姓名！");

            }
            else
                MessageBox.Show("所有内容均不可以为空！！");
        }

        private void GetStringValues()//获取文本框的数据
        {
            //acId, acName, acPlace, acTime, stuNo, mark;
            acName = textBox1.Text;
            acPlace = textBox2.Text;
            acTime = dateTimePicker1.Value.ToString();
            DataSet dataSet = SqlFunction.GetDs("SELECT stuNo FROM Student WHERE stuName='"+ textBox3.Text+"'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            if (dataView.Count != 0)
            {
                stuNo = dataView[0][0].ToString();
            }
            else stuNo = "查无此人";
            
            mark = richTextBox1.Text;
        }

        private void DataGridView1_Click(object sender, EventArgs e)//获取活动表单数据
        {
            if (dataGridView1.RowCount != 0)
            { 
                String[] selectValue = otherFunction.GetSelectValue(dataGridView1);
                textBox1.Text = selectValue[1];
                oldName= selectValue[1];
                textBox2.Text = selectValue[2];
                dateTimePicker1.Value = Convert.ToDateTime(selectValue[3]);
                textBox3.Text = selectValue[4];
                richTextBox1.Text= selectValue[5];
                button2.Enabled = true;
                button3.Enabled = true;
                acId = selectValue[0];
            }
            
        }

        private void DataGridView2_Click(object sender, EventArgs e)//将学生表数据赋值给文本框
        {
            textBox3.Text = otherFunction.GetSelectValue(dataGridView2)[1];
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)//执行学生表单筛选查询
        {
            GetNewStudentValues(GetSeachValues());
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            GetNewStudentValues(GetSeachValues());
        }

        private void ActivityManage_Load(object sender, EventArgs e)//加载各种初始化
        {
            GetNewStudentValues(psString);
            GetNewValues();
            String sqlLangauge = "SELECT departName FROM Department";
            comboBox1.Items.Add("所有科室");
            otherFunction.GetComboBoxValues(sqlLangauge, comboBox1, "departName");            
            DataSet dataSet = SqlFunction.GetDs(sqlLangauge);
            DataView dataView = dataSet.Tables[0].DefaultView;
            departArry = new String[dataView.Count+1];
            departArry[0] = "所有科室";
            for (int i = 1; i < dataView.Count+1; i++)
            {
                departArry[i] = dataView[i-1]["departName"].ToString();
            }
            comboBox1.SelectedIndex = 0;
        }
        private String[] GetSeachValues()//获取搜索框参数
        {
            String departNo="%", stuName;
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "所有科室")
                {
                    departNo = "%";
                }
                else
                {
                    for (int i = 0; i < departArry.Length; i++)
                    {
                        if (departArry[i] == comboBox1.SelectedItem.ToString())
                        {
                            departNo = (i).ToString();
                            break;
                        }
                        else
                        {
                            departNo = "%";
                        }
                    }
                }
            }
            stuName = textBox4.Text;
            String[] arry = { departNo, stuName };
            return arry;
        }


        private void GetNewStudentValues(String[] psString)//获取学生表单数据
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT stuNo, stuName, departNo FROM Student Where DepartNo like '" + psString[0] + "' AND stuName like '%" + psString[1] +  "%'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            for (int i = 0; i < dataView.Count; i++)
            {
                DataSet dataSet1 = SqlFunction.GetDs("SELECT departName FROM Department WHERE departNo='" + dataView[i]["departNo"] + "'");
                DataView dataView1 = dataSet1.Tables[0].DefaultView;
                dataView[i]["departNo"] = dataView1[0][0];
            }
            dataGridView2.DataSource = dataView;
            //学号，姓名，部门编号，职务，班级，性别，生日，加入日期，联系方式，离职标记
            dataGridView2.Columns[0].HeaderCell.Value = "学号";
            dataGridView2.Columns[1].HeaderCell.Value = "姓名";
            dataGridView2.Columns[2].HeaderCell.Value = "所在部门";
        }


        private void GetNewValues()//获取活动表单数据
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Activity");
            DataView dataView = dataSet.Tables[0].DefaultView;          
            for (int i = 0; i < dataView.Count; i++)
            {
                DataSet dataSet1 = SqlFunction.GetDs("SELECT stuName FROM Student WHERE stuNo='" + dataView[i]["stuNo"] + "'");
                DataView dataView1 = dataSet1.Tables[0].DefaultView;
                dataView[i]["stuNo"] = dataView1[0][0];
            }
            dataGridView1.DataSource = dataView;
            button2.Enabled = false;
            button3.Enabled = false;
            dataGridView1.Columns[0].HeaderCell.Value = "活动编号";
            dataGridView1.Columns[1].HeaderCell.Value = "活动名称";
            dataGridView1.Columns[2].HeaderCell.Value = "活动地点";
            dataGridView1.Columns[3].HeaderCell.Value = "活动时间";
            dataGridView1.Columns[4].HeaderCell.Value = "活动负责人";
            dataGridView1.Columns[5].HeaderCell.Value = "备注";
        }
    }

}
