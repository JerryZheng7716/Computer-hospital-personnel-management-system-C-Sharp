using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DNYY
{
    public partial class AttendanceManage : Form
    {
        OtherFunction otherFunction = new OtherFunction();
        String[] psStudent = { "%", "%" };
        String[] psActivity = { "%", "%" };
        String[] departArry;
        String atId, stuNo, acid, atTime, notAcTime, laterTime, mark;
        public AttendanceManage()
        {
            InitializeComponent();
            this.Load += AttendanceManage_Load;
            textBox4.TextChanged += TextBox4_TextChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            button4.Click += Button4_Click;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            textBox1.TextChanged += TextBox1_TextChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
            dataGridView2.Click += DataGridView2_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            dataGridView1.Click += DataGridView1_Click;
            button3.Click += Button3_Click;
        }

        private void Button3_Click(object sender, EventArgs e)//删除操作
        {
            if (MessageBox.Show("确认删除？", "是否删除编号为 " + atId + "的记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String sqlLanguage = "DELETE Attendance WHERE atId='" + atId + "'";
                if (SqlFunction.Execute(sqlLanguage) > 0)
                {
                    MessageBox.Show("删除成功！");
                    GetNewValues();
                }
                else
                    MessageBox.Show("妈呀！删除失败咯！！！！怎么肥事？");
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)//表单被点击获取数据并赋值
        {
            String[] selectValue = otherFunction.GetSelectValue(dataGridView1);
            atId = selectValue[0];
            richTextBox1.Text = selectValue[1];
            textBox2.Text = selectValue[2];
            textBox3.Text = selectValue[3];
            textBox5.Text = selectValue[4];
            textBox6.Text = selectValue[5];
            richTextBox2.Text = selectValue[6];
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)//更新数据
        {
            SetPsString();
            String name = richTextBox1.Text.Trim();
            string[] stuNameArray = Regex.Split(name, " ", RegexOptions.IgnoreCase);
            for (int i = 0; i < stuNameArray.Length; i++)
            {

                String sqlLangauge = "SELECT stuNo From Student WHERE stuName='" + stuNameArray[i] + "'";
                DataSet dataSet = SqlFunction.GetDs(sqlLangauge);
                DataView dataView = dataSet.Tables[0].DefaultView;
                if (dataView.Count != 0)
                {
                    stuNo = dataView[0][0].ToString();
                }
                else
                    stuNo = "查无此人";

                if (stuNo != "" && acid != "")
                {
                    //atId, stuNo, acid, atTime, notAcTime, laterTime, mark;
                    if (stuNo != "查无此人")
                    {
                        String sqlLanguage = "UPDATE Attendance SET stuNo='" + stuNo + "',acid='" + acid + "', atTime='" + atTime + "',notAcTime='" + notAcTime +
                            "',laterTime='" + laterTime + "',mark='" + mark + "' WHERE atId='" + atId + "'";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            MessageBox.Show("成功更新 ", "执行完毕");
                            GetNewValues();
                        }
                        else
                            MessageBox.Show("妈呀！插入失败咯！！！！怎么肥事？");
                    }
                    else
                    {
                        MessageBox.Show("电脑医院不存在名为 " + stuNameArray[i] + " 的人！！", "请检查负责人姓名！");
                    }
                }
                else
                    MessageBox.Show("学生姓名和活动编号不能为空！！");

            }            
        }



        private void Button1_Click(object sender, EventArgs e)//插入数据
        {
            SetPsString();
            int sucessSum = 0, failedSum = 0;
            String name =richTextBox1.Text.Trim();
            string[] stuNameArray = Regex.Split(name, " ", RegexOptions.IgnoreCase);
            for (int i = 0; i < stuNameArray.Length; i++)
            {
                
                String sqlLangauge = "SELECT stuNo From Student WHERE stuName='" + stuNameArray[i] + "'";
                DataSet dataSet = SqlFunction.GetDs(sqlLangauge);
                DataView dataView = dataSet.Tables[0].DefaultView;
                if (dataView.Count != 0)
                {
                    stuNo = dataView[0][0].ToString();
                }
                else
                    stuNo = "查无此人";

                if (stuNo != "" && acid != "")
                {
                    //atId, stuNo, acid, atTime, notAcTime, laterTime, mark;
                    if (stuNo != "查无此人")
                    {
                        String sqlLanguage = "INSERT Attendance(stuNo, acid, atTime, notAcTime, laterTime, mark) VALUES('" + stuNo+ "','" + acid + "','" + atTime +
                             "','" + notAcTime + "','" + laterTime + "','" + mark + "')";
                        if (SqlFunction.Execute(sqlLanguage) > 0)
                        {
                            sucessSum++;
                        }
                        else
                            MessageBox.Show("妈呀！插入失败咯！！！！怎么肥事？");
                    }
                    else
                    {
                        MessageBox.Show("电脑医院不存在名为 " + stuNameArray[i] + " 的人！！", "请检查负责人姓名！");
                        failedSum++;
                    }
                }
                else
                    MessageBox.Show("学生姓名和活动编号不能为空！！");

            }
            MessageBox.Show("成功更新 "+sucessSum+" 个记录，失败"+failedSum+"个", "执行完毕");
            GetNewValues();

        }

        private void SetPsString()//设定筛选语句的关键词
        {
            acid = textBox2.Text;
            atTime = textBox3.Text;
            notAcTime = textBox5.Text;
            laterTime = textBox6.Text;
            mark = richTextBox2.Text;
        }

        private void DataGridView2_Click(object sender, EventArgs e)//获取活动编号给文本框
        {
            textBox2.Text = otherFunction.GetSelectValue(dataGridView2)[0];
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)//执行查询筛选
        {
            GetNewActivelyValues(GetPsActivity());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetNewActivelyValues(GetPsActivity());
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetNewActivelyValues(GetPsActivity());
        }

        private void Button4_Click(object sender, EventArgs e)//将选择列表的名单放入姓名文本框
        {

            string strCollected = string.Empty;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)//得到全部选中的值 ，并将选中的项的文本组合成为一个字符串。
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (strCollected == string.Empty)
                    {
                        strCollected = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                    else
                    {
                        strCollected = strCollected + " " + checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    }
                }
            }
            richTextBox1.Text = richTextBox1.Text + strCollected+ " ";
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)//是否对姓名进行全选
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);//选中所有名字
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);//取消选中所有名字
                }
            }


        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)//执行筛选查询
        {
            GetNewStudentValues(GetPsStudent());
            checkBox1.Checked = false;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            GetNewStudentValues(GetPsStudent());
            checkBox1.Checked = false;
        }

        private void AttendanceManage_Load(object sender, EventArgs e)//加载各种初始化
        {
            GetNewStudentValues(psStudent);
            GetNewActivelyValues(psActivity);
            String sqlLangauge = "SELECT departName FROM Department";
            comboBox1.Items.Add("所有科室");
            otherFunction.GetComboBoxValues(sqlLangauge, comboBox1, "departName");
            comboBox1.SelectedIndex = 0;
            DataSet dataSet = SqlFunction.GetDs(sqlLangauge);
            DataView dataView = dataSet.Tables[0].DefaultView;
            departArry = new String[dataView.Count + 1];
            departArry[0] = "所有科室";
            for (int i = 1; i < dataView.Count + 1; i++)
            {
                departArry[i] = dataView[i - 1]["departName"].ToString();
            }
            checkBox2.Checked=true;
            GetNewValues();

        }

        private String[] GetPsStudent()//获取查询学生条件字段
        {
            String[] arryStr= { "",""};
            arryStr[1] = textBox4.Text;
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "所有科室")
                {
                    arryStr[0] = "%";
                }
                else
                {
                    for (int i = 0; i < departArry.Length; i++)
                    {
                        if (departArry[i] == comboBox1.SelectedItem.ToString())
                        {
                            arryStr[0] = (i).ToString();
                            break;
                        }
                        else
                        {
                            arryStr[0] = "%";
                        }
                    }
                }
            }
            else
                arryStr[0] = comboBox1.SelectedItem.ToString();
            return arryStr;
            
        }

        private String[] GetPsActivity()//获取查询活动的条件字段
        {
            String[] arryStr = { "", "" };
            
            if (checkBox2.Checked)
            {
                arryStr[0] = "%";
            }else
                arryStr[0] = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            arryStr[1] = textBox1.Text;
            return arryStr;
        }

        private void GetNewStudentValues(String[] psString)//设定学生表单的数据
        {
            checkedListBox1.Items.Clear();
            DataSet dataSet = SqlFunction.GetDs("SELECT stuNo, stuName, departNo FROM Student Where DepartNo like '" + psString[0] + "' AND stuName like '%" + psString[1] + "%'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            for (int i = 0; i < dataView.Count; i++)
            {
                DataSet dataSet1 = SqlFunction.GetDs("SELECT departName FROM Department WHERE departNo='" + dataView[i]["departNo"] + "'");
                DataView dataView1 = dataSet1.Tables[0].DefaultView;
                dataView[i]["departNo"] = dataView1[0][0];
            }
            for (int i = 0; i < dataView.Count; i++)
            {
                checkedListBox1.Items.Add(dataView[i][1].ToString());
            }
        }

        private void GetNewActivelyValues(String[] psString)//获取活动表单的数据
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT acId,acName,acTime FROM Activity Where acTime like '" + psString[0] + "' AND acName like '%" + psString[1] + "%'");
            DataView dataView = dataSet.Tables[0].DefaultView;
            dataGridView2.DataSource = dataView;
            dataGridView2.Columns[0].HeaderCell.Value = "活动编号";
            dataGridView2.Columns[1].HeaderCell.Value = "活动名称";
            dataGridView2.Columns[2].HeaderCell.Value = "活动日期";
        }

        private void GetNewValues()//初始化获取考勤表数据
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Attendance");
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
           // atId, stuNo, acid, atTime, notAcTime, laterTime, mark;
            dataGridView1.Columns[0].HeaderCell.Value = "记录编号";
            dataGridView1.Columns[1].HeaderCell.Value = "学生姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "活动编号";
            dataGridView1.Columns[3].HeaderCell.Value = "出勤时长";
            dataGridView1.Columns[4].HeaderCell.Value = "缺勤时长";
            dataGridView1.Columns[5].HeaderCell.Value = "迟到时长";
            dataGridView1.Columns[6].HeaderCell.Value = "备注";
        }
    }
}
