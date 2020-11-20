namespace GenerateScripts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbStoredProc = new System.Windows.Forms.RadioButton();
            this.txtScriptsName = new System.Windows.Forms.TextBox();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.rdbTable = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblConnString = new System.Windows.Forms.Label();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTable);
            this.groupBox1.Controls.Add(this.rdbStoredProc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DbObjects";
            // 
            // rdbStoredProc
            // 
            this.rdbStoredProc.AutoSize = true;
            this.rdbStoredProc.Location = new System.Drawing.Point(19, 19);
            this.rdbStoredProc.Name = "rdbStoredProc";
            this.rdbStoredProc.Size = new System.Drawing.Size(113, 17);
            this.rdbStoredProc.TabIndex = 0;
            this.rdbStoredProc.TabStop = true;
            this.rdbStoredProc.Text = "Stored Procedures";
            this.rdbStoredProc.UseVisualStyleBackColor = true;
            // 
            // txtScriptsName
            // 
            this.txtScriptsName.Location = new System.Drawing.Point(12, 129);
            this.txtScriptsName.Multiline = true;
            this.txtScriptsName.Name = "txtScriptsName";
            this.txtScriptsName.Size = new System.Drawing.Size(422, 206);
            this.txtScriptsName.TabIndex = 1;
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.Location = new System.Drawing.Point(61, 341);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateScript.TabIndex = 2;
            this.btnGenerateScript.Text = "GenerateScripts";
            this.btnGenerateScript.UseVisualStyleBackColor = true;
            this.btnGenerateScript.Click += new System.EventHandler(this.btnGenerateScript_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(187, 341);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rdbTable
            // 
            this.rdbTable.AutoSize = true;
            this.rdbTable.Location = new System.Drawing.Point(158, 19);
            this.rdbTable.Name = "rdbTable";
            this.rdbTable.Size = new System.Drawing.Size(52, 17);
            this.rdbTable.TabIndex = 1;
            this.rdbTable.TabStop = true;
            this.rdbTable.Text = "Table";
            this.rdbTable.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblConnString
            // 
            this.lblConnString.AutoSize = true;
            this.lblConnString.Location = new System.Drawing.Point(13, 69);
            this.lblConnString.Name = "lblConnString";
            this.lblConnString.Size = new System.Drawing.Size(91, 13);
            this.lblConnString.TabIndex = 5;
            this.lblConnString.Text = "Connection String";
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(110, 66);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(324, 20);
            this.txtConnString.TabIndex = 6;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(16, 110);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 13);
            this.lblPath.TabIndex = 7;
            this.lblPath.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(110, 103);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(176, 20);
            this.txtPath.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 376);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.lblConnString);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerateScript);
            this.Controls.Add(this.txtScriptsName);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbStoredProc;
        private System.Windows.Forms.TextBox txtScriptsName;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdbTable;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblConnString;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
    }
}

