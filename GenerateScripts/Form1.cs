using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using bluesd7.DAL;

namespace GenerateScripts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConnString.Text = "Data source=.;Initial Catalog=DatabaseName;User ID=sa;Password=YouPassword;";
            //Data source=192.168.0.253;Initial Catalog=CSocialDB;User ID=sa;Password=123456;
            //Data source=.;Initial Catalog=Test;User ID=sa;Password=Journey!7;
            //  txtPath.Text = "D:\\GitHub\\scripts\\";
            txtTableCount.Text = "10";
        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        private void LoadTable()
        {
            SqlDB db = new SqlDB(txtConnString.Text);
            DataTable dt = new DataTable();
            try
            {
                lbxTableList.Items.Clear();

                dt = db.ExecuteDataTableByText("sp_help");
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("连接数据库失败", "验证");
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Object_type"].ToString() == "user table")
                    {
                        lbxTableList.Items.Add(dr["Name"].ToString());
                    }
                }
            }
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (lbxTableList.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("请选择一个表", "验证");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int tableCount = Convert.ToInt32(txtTableCount.Text);
                string tableName = lbxTableList.SelectedItem.ToString();

                SqlDB db = new SqlDB(txtConnString.Text);

                DataTable dbNameDT = db.ExecuteDataTableByText("Select Name From Master..SysDataBases Where DbId=(Select Dbid From Master..SysProcesses Where Spid = @@spid)");
                string dbName = dbNameDT.Rows[0][0].ToString(); //数据库名称


                DataTable dt = db.ExecuteDataTableByText("exec sp_ScriptTable '" + tableName + "'");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < tableCount; i++)
                    {
                        string fileGroup = dbName + "_" + tableName + "_" + i.ToString();
                        sb.AppendLine("ALTER DATABASE [" + dbName + "] ADD FILEGROUP [" + fileGroup + "]");
                        sb.AppendLine("ALTER DATABASE [" + dbName + "] ADD FILE(name='" + fileGroup + "',filename='D:\\ServerData\\" + fileGroup + ".ndf',size=8MB,FILEGROWTH=64)TO FILEGROUP [" + fileGroup + "]");
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (IsIndexRow(dr["FieldValue"].ToString()))
                            {
                                sb.AppendLine(dr["FieldValue"].ToString().Replace(tableName, tableName + "_" + i.ToString()) + "WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [" + fileGroup + "]");
                            }
                            else
                            {
                                sb.AppendLine(dr["FieldValue"].ToString().Replace(tableName, tableName + "_" + i.ToString()));
                            }
                        }
                        db.ExecuteNonQueryByText(sb.ToString());
                        sb.Clear();
                    }
                }
                
                LoadTable();
            }
        }

        private void BtnDeleteTable_Click(object sender, EventArgs e)
        {
            if (lbxTableList.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("请选择一个表", "验证");
            }
            else
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("确定要删除" + lbxTableList.SelectedItem.ToString() + "表的所有分表吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StringBuilder sb = new StringBuilder();
                    int tableCount = Convert.ToInt32(txtTableCount.Text);
                    string tableName = lbxTableList.SelectedItem.ToString();

                    SqlDB db = new SqlDB(txtConnString.Text);

                    DataTable dbNameDT = db.ExecuteDataTableByText("Select Name From Master..SysDataBases Where DbId=(Select Dbid From Master..SysProcesses Where Spid = @@spid)");
                    string dbName = dbNameDT.Rows[0][0].ToString(); //数据库名称
                    for (int i = 0; i < tableCount; i++)
                    {
                        string fileGroup = dbName + "_" + tableName + "_" + i.ToString();
                        sb.AppendLine("DROP TABLE " + tableName + "_" + i.ToString());
                        sb.AppendLine("ALTER DATABASE [" + dbName + "] REMOVE FILE " + fileGroup);
                        sb.AppendLine("ALTER DATABASE [" + dbName + "] REMOVE FILEGROUP " + fileGroup);
                        db.ExecuteNonQueryByText(sb.ToString());
                        sb.Clear();
                    }                    
                    LoadTable();
                }
                else { return; }
            }
        }

        /// <summary>
        /// 判断是否是创建索引行
        /// </summary>
        /// <param name="row"></param>
        private bool IsIndexRow(string row)
        {
            if (row.ToUpper().Contains("CREATE CLUSTERED") || row.ToUpper().Contains("CREATE NONCLUSTERED"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
