using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DNYY
{
    //头部要引用System.Data和System.SqlClient

    public class SqlFunction
    {
        
        private static string connstr = "server=.;uid=sa;pwd=123456;database=ComputerHosipital";

        public static int Execute(string NonQuerySql, bool DebugFlag)    //执行一个非查询的数据库操作
        {
            string sql = NonQuerySql.ToLower();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connstr);
            System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = NonQuerySql;
            conn.Open();
            int n = 0;
            if ((sql.IndexOf("update ") >= 0 || sql.IndexOf("delete ") >= 0) && sql.IndexOf(" where ") < 0)//无条件的删除和修改不允许
                throw new Exception(NonQuerySql + "\nupdate或delete时没有where条件");
            try
            {
                if (DebugFlag) { conn.Close(); throw new Exception(NonQuerySql); }
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception(NonQuerySql + "\n\n" + e.ToString()); ;
            }
            conn.Close();
            return n;
        }

        public static int Execute(string NonQuerySql)    //执行一个非查询的数据库操作
        {
            return Execute(NonQuerySql, false);
        }


        public static System.Data.DataSet GetDs(string QuerySql)    //执行一个查询的数据库操作，返回数据集
        {
            string sql1 = QuerySql.Trim().ToLower();
            if (sql1.StartsWith("insert ") || sql1.StartsWith("update ") || sql1.StartsWith("delete "))
                throw new Exception(QuerySql + "\n本方法仅用于查询");
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connstr);
            System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = QuerySql;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataSet ds = new System.Data.DataSet();
            conn.Open();

            try
            {
                da.Fill(ds);
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception(QuerySql + "\n\n" + e.ToString()); ;
            }
            conn.Close();
            if (ds == null) return null;
            return ds;
        }


        public static object GetData(string QuerySql)    //执行一个查询的数据库操作，返回一个值
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = QuerySql;
            conn.Open();
            object result = null;
            try
            {
                result = (object)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception(QuerySql + "\n\n" + e.ToString()); ;
            }
            conn.Close();

            return result;
        }

    }

    public class InputBox
    {
        //调用：string s=InputBox.Show("请输入姓名","默认的姓名");
        static System.Windows.Forms.Form f;
        public static string Show(string strPrompt, string strDefault, string strTitle)
        {
            return show1(strPrompt, strDefault, strTitle);
        }

        public static string Show(string strPrompt, string strDefault)
        {
            return show1(strPrompt, strDefault, "输入");
        }

        public static string Show(string strPrompt)
        {
            return show1(strPrompt, "", "输入");
        }

        public static string Show()
        {
            return show1("", "", "输入");
        }

        private static string show1(string strPrompt, string strDefault, string strTitle)
        {
            f = new System.Windows.Forms.Form();
            System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox text1 = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button buttonOK = new System.Windows.Forms.Button();
            System.Windows.Forms.Button buttonCancel = new System.Windows.Forms.Button();

            label1.Text = strPrompt;
            label1.Left = 10;
            label1.Top = 30;
            label1.Size = new System.Drawing.Size(410, 12);


            text1.Text = strDefault;
            text1.Left = 10;
            text1.Top = 50;
            text1.Size = new System.Drawing.Size(410, 12);

            buttonOK.Text = "确定";
            buttonOK.Top = 80;
            buttonOK.Left = 250;

            buttonCancel.Text = "取消";
            buttonCancel.Top = 80;
            buttonCancel.Left = 340;

            f.Controls.Add(label1);
            f.Controls.Add(text1);
            f.Controls.Add(buttonOK);
            f.Controls.Add(buttonCancel);
            f.AcceptButton = buttonOK;
            f.CancelButton = buttonCancel;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            f.ShowIcon = false;
            f.ShowInTaskbar = false;
            f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            buttonOK.Click += new EventHandler(buttonOK_Click);
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
            f.Text = strTitle;
            f.Size = new System.Drawing.Size(430, 140);
            System.Windows.Forms.DialogResult dr = f.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                return text1.Text;
            }
            else
            {
                return "";
            }
        }

        static void buttonCancel_Click(object sender, EventArgs e)
        {
            f.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            f.Visible = false;
        }

        static void buttonOK_Click(object sender, EventArgs e)
        {
            f.DialogResult = System.Windows.Forms.DialogResult.OK;
            f.Visible = false;
        }
    }

}
