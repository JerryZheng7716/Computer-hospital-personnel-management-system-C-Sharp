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
    public partial class StudentManage : Form
    {
        String stuNo, stuName, departNo, post, class1, sex, birthday, enjoyDate, contactWay, isWorking, oldStuNo, oldStuName;
        OtherFunction otherFunction = new OtherFunction();
        String[] departArry;
        String[] posttArry = {"干事","会长","副会长","科长","副科长"};  //定义职位。时间关系没写数据库
        String[] psString = { "", "", "%", "%" ,"%"};
        public StudentManage()
        {
            InitializeComponent();
            this.Load += AdminManage_Load;
            button1.Click += Button1_Click; // 录入人员
            button2.Click += Button2_Click; // 修改人员
            dataGridView1.Click += DataGridView1_Click;
            button3.Click += Button3_Click; // 修改人员
            textBox5.TextChanged += TextBox5_TextChanged;  // 筛选姓名
            textBox6.TextChanged += TextBox6_TextChanged;  // 筛选学号
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;  // 职位
            comboBox4.SelectedIndexChanged += ComboBox4_SelectedIndexChanged;  // 部门
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged; // 在职
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged; // 离职
        }
        
        // 获取搜索框参数
        private String[] GetSeachValues()
        {
            String stuNo, stuName, departNo = "%", post = "";
            stuNo = textBox6.Text;
            stuName = textBox5.Text;
            if (comboBox4.SelectedItem != null)
            {
                if (comboBox4.SelectedItem.ToString() == "所有部门")
                {
                    departNo = "%";
                }
                else
                {
                    for (int i = 0; i < departArry.Length; i++)
                    {
                        if (departArry[i] == comboBox4.SelectedItem.ToString())
                        {
                            departNo = (i + 1).ToString();
                            break;
                        }
                        else
                        {
                            departNo = "%";
                        }
                    }
                }
            }
            if (comboBox3.SelectedItem != null)
            {
                if (comboBox3.SelectedItem.ToString() == "所有职务")
                {
                    post = "%";
                }
                else
                    post = comboBox3.SelectedItem.ToString();
            }

            if (checkBox1.Checked && checkBox2.Checked)
            {
                isWorking = "%";
            }
            else if (checkBox1.Checked && !checkBox2.Checked)
            {
                isWorking = "1";
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                isWorking = "0";
            }
            else
            {
                isWorking = "什么都没有";
            }

            String[] psString = { stuNo, stuName, departNo, post, isWorking };
            return psString;
        }


        // 筛选姓名
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }
        // 筛选学号
        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }

        // 筛选部门
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }
        // 筛选职位
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }

        // 筛选在职
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }
        // 筛选离职
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            String[] psString = GetSeachValues();
            GetNewValues(psString);
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }     
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 填充学号
                textBox1.Text = otherFunction.GetSelectValue(dataGridView1)[0];
                oldStuNo = textBox1.Text;
                // 填充姓名
                textBox2.Text = otherFunction.GetSelectValue(dataGridView1)[1];
                oldStuName = textBox2.Text;
                // 填充部门
                for (int i = 0; i < departArry.Length; i++)
                {
                    if (departArry[i] == otherFunction.GetSelectValue(dataGridView1)[2])
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }
                // 填充职位
                for (int i = 0; i < posttArry.Length; i++)
                {
                    if (posttArry[i] == otherFunction.GetSelectValue(dataGridView1)[3])
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }
                // 填充班级
                textBox4.Text = otherFunction.GetSelectValue(dataGridView1)[4];
                // 填充性别
                if (otherFunction.GetSelectValue(dataGridView1)[5] == "男")
                {
                    radioButton1.Select();
                }
                else
                {
                    radioButton2.Select();
                }
                // 生日
                dateTimePicker1.Value = Convert.ToDateTime(otherFunction.GetSelectValue(dataGridView1)[6]);
                // 加入日期
                dateTimePicker2.Value = Convert.ToDateTime(otherFunction.GetSelectValue(dataGridView1)[7]);
                // 联系方式
                textBox3.Text = otherFunction.GetSelectValue(dataGridView1)[8];
                // 是否在职
                if (otherFunction.GetSelectValue(dataGridView1)[9] == "True")
                {
                    radioButton4.Select();
                }
                else
                {
                    radioButton5.Select();
                }
                // 激活按钮
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        // 获取文本框的信息 进行添加修改
        private void GetStringValues()
        {
            stuNo = textBox1.Text;
            stuName = textBox2.Text;
            for (int i = 0; i < departArry.Length; i++)
            {
                if (departArry[i] == comboBox1.SelectedItem.ToString())
                {
                    departNo = (i + 1).ToString();
                    break;
                }
            }
            post = comboBox2.SelectedItem.ToString();
            class1 = textBox4.Text;
            if (radioButton1.Checked)
            {
                sex = "男";
            }
            else sex = "女";
            birthday = dateTimePicker1.Value.ToString();
            enjoyDate = dateTimePicker2.Value.ToString();
            contactWay = textBox3.Text;
            if (radioButton4.Checked)
            {
                isWorking = "1";
            }
            else isWorking = "0";
        }
        // 录入人员信息
        private void Button1_Click(object sender, EventArgs e)
        {
            GetStringValues();
            if (stuNo != "" && stuName != "" && class1 != "" && contactWay != "")
            {
                DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Student Where stuNo='" + stuNo + "'");
                DataView dataView = dataSet.Tables[0].DefaultView;
                if (dataView.Count == 0)
                {
                    //stuNo, stuName, departNo, post, class1, sex, birthday, enjoyDate, contactWay, isWorking
                    String sqlLanguage = "INSERT Student VALUES('" + stuNo + "','" + stuName + "','" + departNo + "','" + post +
                        "','" + class1 + "','" + sex + "','" + birthday + "','" + enjoyDate + "','" + contactWay +
                        "','" + isWorking + "')";
                    if (SqlFunction.Execute(sqlLanguage) > 0)
                    {
                        MessageBox.Show("插入成功！");
                        GetNewValues(psString);
                    }
                    else
                        MessageBox.Show("插入失败！");
                }
                else
                    MessageBox.Show("已经存在当前学号");
            }
            else { 
                MessageBox.Show("所有内容均不可以为空！！");
            }

        }
        // 修改人员信息
        private void Button2_Click(object sender, EventArgs e)
        {
            if (otherFunction.ChangeStuPower == "True")
            {
                GetStringValues();
                if (stuNo != "" && stuName != "" && class1 != "" && contactWay != "")
                {
                    DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Student Where stuNo='" + stuNo + "'");
                    DataView dataView = dataSet.Tables[0].DefaultView;
                    if (dataView.Count == 0 || stuNo == oldStuNo)
                    {
                        if (MessageBox.Show("确认修改？", "是否提交修改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {

                            String sqlLanguage = "UPDATE Student SET stuNo='" + stuNo + "',stuName='" + stuName + "',departNo='" + departNo + "',post='" + post +
                                "',class='" + class1 + "',sex='" + sex + "',birthday='" + birthday + "',enjoyDate='" + enjoyDate + "',contactWay='" + contactWay + "',isWorking='" + isWorking +
                                "' WHERE stuNo='" + oldStuNo + "'";
                            if (SqlFunction.Execute(sqlLanguage) > 0)
                            {
                                MessageBox.Show("修改成功！");
                                GetNewValues(psString);
                            }
                            else
                                MessageBox.Show("妈呀！修改失败咯！！！！怎么肥事？");
                        }
                    }
                    else
                        MessageBox.Show("已经存在当前学号");
                }
                else
                    MessageBox.Show("所有内容均不可以为空！！");
            }
            else
                MessageBox.Show("对不起！您当前没有权限对此进行操作！");
            
        }
        // 删除人员信息
        private void Button3_Click(object sender, EventArgs e)
        {
            if (otherFunction.ChangeStuPower == "True")
            {
                if (MessageBox.Show("确认删除？", "是否删除 " + oldStuName + " ？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String sqlLanguage = "DELETE Student WHERE StuNo='" + oldStuNo + "'";
                    if (SqlFunction.Execute(sqlLanguage) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        GetNewValues(psString);
                    }
                    else
                        MessageBox.Show("妈呀！删除失败！");
                }
            }
            else
                MessageBox.Show("对不起！您当前没有权限对此进行操作！");

        }
        // 加载
        private void AdminManage_Load(object sender, EventArgs e)
        {           
            radioButton1.Select();
            radioButton4.Select();           
            String sqlLangauge = "SELECT departName FROM Department";
            otherFunction.GetComboBoxValues(sqlLangauge, comboBox1,"departName");
            comboBox4.Items.Add("所有部门");
            comboBox3.Items.Add("所有职务");
            otherFunction.GetComboBoxValues(sqlLangauge, comboBox4, "departName");           
            DataSet dataSet = SqlFunction.GetDs("SELECT departName FROM Department");
            DataView dataView = dataSet.Tables[0].DefaultView;
            departArry=new String[dataView.Count];
            for (int i = 0; i < dataView.Count; i++)
            {
                departArry[i] = dataView[i]["departName"].ToString();
            }
            for (int i = 0; i < posttArry.Length; i++)
            {
                comboBox2.Items.Add(posttArry[i]) ;
                comboBox3.Items.Add(posttArry[i]);
            }
            GetNewValues(psString);
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            checkBox1.Checked = true;
            checkBox2.Checked = true;

        }
        // 刷新table
        private void GetNewValues(String[] psString)
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Student Where stuNo like '%"+psString[0]+"%' AND stuName like '%"+psString[1]+ "%' AND  departNo like '" + psString[2] + "'  AND post like '" + psString[3]+"' AND isWorking like '"+ psString[4] + "'");
            DataView dataView = dataSet.Tables[0].DefaultView;           
            for (int i = 0; i < dataView.Count; i++)
            {
                DataSet dataSet1 = SqlFunction.GetDs("SELECT departName FROM Department WHERE departNo='"+ dataView[i]["departNo"]+"'");
                DataView dataView1 = dataSet1.Tables[0].DefaultView;
                dataView[i]["departNo"] = dataView1[0][0];
            }
            dataGridView1.DataSource = dataView;
            button2.Enabled = false;
            button3.Enabled = false;
            //学号，姓名，部门编号，职务，班级，性别，生日，加入日期，联系方式，离职标记
            dataGridView1.Columns[0].HeaderCell.Value = "学号";
            dataGridView1.Columns[1].HeaderCell.Value = "姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "所在部门";
            dataGridView1.Columns[3].HeaderCell.Value = "职务";
            dataGridView1.Columns[4].HeaderCell.Value = "班级";
            dataGridView1.Columns[5].HeaderCell.Value = "性别";
            dataGridView1.Columns[6].HeaderCell.Value = "生日";
            dataGridView1.Columns[7].HeaderCell.Value = "加入日期";
            dataGridView1.Columns[8].HeaderCell.Value = "联系方式";
            dataGridView1.Columns[9].HeaderCell.Value = "在职情况";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dateTimePicker1.Value = Convert.ToDateTime("1996/1/1");
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
