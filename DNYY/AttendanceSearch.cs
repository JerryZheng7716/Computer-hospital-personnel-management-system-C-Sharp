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
    public partial class AttendanceSearch : Form
    {
        String stuNo;
        OtherFunction otherFunction = new OtherFunction();
        String[] psString = { "%", "%" };
        String[] departArry;
        public AttendanceSearch()
        {
            InitializeComponent();
            dataGridView2.Click += DataGridView2_Click;
            this.Load += AttendanceSearch_Load;
            textBox4.TextChanged += TextBox4_TextChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)//执行搜索
        {
            SetSearchResult();
        }

        private void SetSearchResult()//获取搜索得到的数据
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT stuNo FROM Student WHERE stuName='" + textBox1.Text + "'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            if (dataView.Count != 0)
            {
                stuNo = dataView[0][0].ToString();
                textBox2.Text = dataView[0][0].ToString(); 
            }
            else stuNo = "查无此人";
            if (stuNo != "查无此人")
            {
                DataSet dataSet1 = SqlFunction.GetDs("Select SUM(atTime),SUM(notAcTime),SUM(laterTime),COUNT(atTime),COUNT(notAcTime),COUNT(laterTime) From Attendance Where stuNo='" + stuNo+"'");
                DataView dataView1 = dataSet1.Tables[0].DefaultView;
                if (dataView1.Count != 0)
                {
                    textBox3.Text = dataView1[0][0].ToString();
                    textBox5.Text = dataView1[0][1].ToString();
                    textBox6.Text = dataView1[0][2].ToString();
                    textBox7.Text = dataView1[0][3].ToString();
                    textBox8.Text = dataView1[0][4].ToString();
                    textBox9.Text = dataView1[0][5].ToString();
                }
                else
                {
                    textBox3.Text = "此人没有出勤记录";
                    textBox5.Text = "此人没有缺勤记录";
                    textBox6.Text = "此人没有迟到记录";
                    textBox7.Text = "此人没有出勤记录";
                    textBox8.Text = "此人没有缺勤记录";
                    textBox9.Text = "此人没有迟到记录";

                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)//执行学生表单查询筛选
        {
            GetNewStudentValues(GetSeachValues());
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            GetNewStudentValues(GetSeachValues());
        }

        private void AttendanceSearch_Load(object sender, EventArgs e)//加载各类初始化
        {
            String sqlLangauge = "SELECT departName FROM Department";
            comboBox1.Items.Add("所有科室");
            otherFunction.GetComboBoxValues(sqlLangauge, comboBox1, "departName");
            DataSet dataSet = SqlFunction.GetDs(sqlLangauge);
            DataView dataView = dataSet.Tables[0].DefaultView;
            departArry = new String[dataView.Count + 1];
            departArry[0] = "所有科室";
            for (int i = 1; i < dataView.Count + 1; i++)
            {
                departArry[i] = dataView[i - 1]["departName"].ToString();
            }
            comboBox1.SelectedIndex = 0;
        }

        private void DataGridView2_Click(object sender, EventArgs e)//将表单选择的名字赋值给文本框
        {
            textBox1.Text = otherFunction.GetSelectValue(dataGridView2)[1];
        }

        private String[] GetSeachValues()//获取搜索框参数
        {
            String departNo = "%", stuName;
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

        private void GetNewStudentValues(String[] psString)//获取学生表单
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT stuNo, stuName, departNo FROM Student Where DepartNo like '" + psString[0] + "' AND stuName like '%" + psString[1] + "%'");
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
    }
}
