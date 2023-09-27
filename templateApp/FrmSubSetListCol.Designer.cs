namespace templateApp
{
    partial class FrmSubSetListCol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubSetListCol));
            this.GdColList = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnExec = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RdoShowMode3 = new System.Windows.Forms.RadioButton();
            this.RdoShowMode2 = new System.Windows.Forms.RadioButton();
            this.RdoShowMode1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GdColList)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GdColList
            // 
            this.GdColList.BackColor = System.Drawing.Color.Silver;
            //this.GdColList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            //this.GdColList.ColumnInfo = "10,1,0,0,0,105,Columns:0{AllowMerging:True;}\t1{Width:136;AllowMerging:True;}\t2{Wi" +"dth:88;}\t";
            this.GdColList.Location = new System.Drawing.Point(12, 11);
            this.GdColList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GdColList.Name = "GdColList";
            //this.GdColList.Rows.Count = 2;
            //this.GdColList.Rows.DefaultSize = 21;
            this.GdColList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //this.GdColList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.GdColList.Size = new System.Drawing.Size(354, 541);
            //this.GdColList.StyleInfo = resources.GetString("GdColList.StyleInfo");
            this.GdColList.TabIndex = 1;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(397, 523);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(131, 29);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.TabStop = false;
            this.BtnClose.Text = "閉じる";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnExec
            // 
            this.BtnExec.Location = new System.Drawing.Point(397, 23);
            this.BtnExec.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExec.Name = "BtnExec";
            this.BtnExec.Size = new System.Drawing.Size(131, 29);
            this.BtnExec.TabIndex = 5;
            this.BtnExec.TabStop = false;
            this.BtnExec.Text = "設定保存";
            this.BtnExec.UseVisualStyleBackColor = true;
            this.BtnExec.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RdoShowMode3);
            this.groupBox7.Controls.Add(this.RdoShowMode2);
            this.groupBox7.Controls.Add(this.RdoShowMode1);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Location = new System.Drawing.Point(397, 76);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(131, 147);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "表示パターン";
            // 
            // RdoShowMode3
            // 
            this.RdoShowMode3.AutoSize = true;
            this.RdoShowMode3.Location = new System.Drawing.Point(11, 109);
            this.RdoShowMode3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdoShowMode3.Name = "RdoShowMode3";
            this.RdoShowMode3.Size = new System.Drawing.Size(85, 19);
            this.RdoShowMode3.TabIndex = 2;
            this.RdoShowMode3.TabStop = true;
            this.RdoShowMode3.Text = "PatternC";
            this.RdoShowMode3.UseVisualStyleBackColor = true;
            this.RdoShowMode3.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // RdoShowMode2
            // 
            this.RdoShowMode2.AutoSize = true;
            this.RdoShowMode2.Location = new System.Drawing.Point(11, 63);
            this.RdoShowMode2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdoShowMode2.Name = "RdoShowMode2";
            this.RdoShowMode2.Size = new System.Drawing.Size(85, 19);
            this.RdoShowMode2.TabIndex = 1;
            this.RdoShowMode2.TabStop = true;
            this.RdoShowMode2.Text = "PatternB";
            this.RdoShowMode2.UseVisualStyleBackColor = true;
            this.RdoShowMode2.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // RdoShowMode1
            // 
            this.RdoShowMode1.AutoSize = true;
            this.RdoShowMode1.Location = new System.Drawing.Point(11, 20);
            this.RdoShowMode1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdoShowMode1.Name = "RdoShowMode1";
            this.RdoShowMode1.Size = new System.Drawing.Size(84, 19);
            this.RdoShowMode1.TabIndex = 0;
            this.RdoShowMode1.TabStop = true;
            this.RdoShowMode1.Text = "PatternA";
            this.RdoShowMode1.UseVisualStyleBackColor = true;
            this.RdoShowMode1.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "全選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(397, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 129);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表示/非表示";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "全解除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(397, 471);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 29);
            this.button3.TabIndex = 9;
            this.button3.Text = "初期設定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmSubSetListCol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(561, 580);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnExec);
            this.Controls.Add(this.GdColList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSubSetListCol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "表示項目設定";
            this.Load += new System.EventHandler(this.FrmSubSetListCol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GdColList)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView GdColList;
        //internal C1.Win.C1FlexGrid.C1FlexGrid GdColList;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnExec;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton RdoShowMode3;
        private System.Windows.Forms.RadioButton RdoShowMode2;
        private System.Windows.Forms.RadioButton RdoShowMode1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}