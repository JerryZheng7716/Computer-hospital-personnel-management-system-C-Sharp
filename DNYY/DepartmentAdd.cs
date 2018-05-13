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
    public partial class DepartmentAdd : Form
    {
        public DepartmentAdd()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = SqlFunction.GetDs("SELECT * FROM Department");
            DataView dataView = dataSet.Tables[0].DefaultView;
            bool haveDpt = false;
            String departNo = "";
            for (int i = 0; i < dataView.Count; i++)
            {
                if (dataView[i]["departName"].ToString() == textBox1.Text)
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
                String sqlLanguage = "INSERT Department VALUES('"+departNo+"','" + textBox1.Text + "')";
                if (SqlFunction.Execute(sqlLanguage) > 0)
                {
                    MessageBox.Show("插入成功！");
                }
                else
                    MessageBox.Show("妈呀！插入失败咯！！！！怎么肥事？");
            }
        }
    }
}
