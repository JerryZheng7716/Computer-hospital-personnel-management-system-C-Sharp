using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DNYY
{
    class OtherFunction
    {
        static String loginName, changeStuPower,isSuperAdmin;
        public string LoginName { get => loginName; set => loginName = value; }
        public string ChangeStuPower { get => changeStuPower; set => changeStuPower = value; }
        public string IsSuperAdmin { get => isSuperAdmin; set => isSuperAdmin = value; }

        public string[] GetSelectValue(DataGridView dataGridView1)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int a = dataGridView1.CurrentRow.Index;
                String[] str = new String[dataGridView1.ColumnCount];
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    str[i] = dataGridView1.Rows[a].Cells[i].Value.ToString();
                }
                return str;
            }
            String[] str1=new String[100];
            return str1;
        }
        public string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }

        public void GetComboBoxValues(String sqlLanguage,ComboBox comboBox,String valuesName)
        {

            DataSet dataSet = SqlFunction.GetDs(sqlLanguage);
            DataView dataView = dataSet.Tables[0].DefaultView;
            for (int i = 0; i < dataView.Count; i++)
            {
                comboBox.Items.Add(dataView[i][valuesName].ToString()); 
            }
        }
    }

}
