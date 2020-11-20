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

        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            if (txtConnString.Text.Trim() == "" || txtScriptsName.Text.Trim() == "")
            {
                MessageBox.Show("Either SQL Connection String is blank or Script Name Textbox");
            }
            else
            {
                string ScriptName = txtScriptsName.Text.Trim();
                char[] a = { '\n' };
                string[] Finalstr = ScriptName.Split(a);
                if (rdbStoredProc.Checked)
                {
                    string Extn = "";
                    foreach (string s in Finalstr)
                    {
                        string ScriptString = s.TrimEnd('\r');
                        Extn = Path.GetExtension(ScriptString);
                        if (Extn.ToUpper() == ".SQL")
                        {
                            GenerateStoredProc(ScriptString.Replace(".sql",""));
                        }
                        else
                        {
                            MessageBox.Show("Invalid File Extension. Enter Script Name With .sql Extension", "Alert");
                        }
                    }
                    MessageBox.Show(@"Scripts Generated Successfully");
                }
                else
                {
                    foreach(string s in Finalstr)
                    {
                        GenerateTableScripts(s);
                    }
                }
                MessageBox.Show(@"Scripts Generated Successfully");
            }
        }

        private void GenerateStoredProc(string ProcName)
        { 
            if (System.IO.Directory.Exists(txtPath.Text.Trim()) == false)
            {
                 System.IO.Directory.CreateDirectory(txtPath.Text.Trim());
            }
            SqlConnection con = new SqlConnection(txtConnString.Text.Trim());

            SqlCommand cmd = new SqlCommand("SP_HELPTEXT " + ProcName, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();

            SqlDataReader dr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string path = txtPath.Text.Trim() + ProcName + ".sql";

            FileStream fs = new FileStream(txtPath.Text.Trim() + ProcName + ".sql", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            
            while (dr.Read())
            {
                sw.WriteLine(dr[0].ToString());
            }
            sw.Close();
            fs.Close();     
        }

        private void GenerateTableScripts(string TableName)
        {
            if (System.IO.Directory.Exists(txtPath.Text.Trim()) == false)
            {
                System.IO.Directory.CreateDirectory(txtPath.Text.Trim());
            }
            SqlConnection con = new SqlConnection(txtConnString.Text.Trim());

            SqlCommand cmd = new SqlCommand("EXEC sp_ScriptTable " + TableName, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            string path = txtPath.Text.Trim() + TableName + ".sql";

            FileStream fs = new FileStream(txtPath.Text.Trim() + TableName + ".sql", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            while (dr.Read())
            {
                sw.WriteLine(dr[0].ToString());
            }
            sw.Close();
            fs.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtScriptsName.Text = "";
            txtConnString.Text = "";
            txtPath.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
