namespace templateApp
{
    partial class FrmShowProject
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabMain = new System.Windows.Forms.TabControl();
            this.PgProject = new System.Windows.Forms.TabPage();
            this.GdProjectList = new System.Windows.Forms.DataGridView();
            this.lblListCount = new System.Windows.Forms.Label();
            this.ChkShowCount = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdoShowMode3 = new System.Windows.Forms.RadioButton();
            this.RdoShowMode2 = new System.Windows.Forms.RadioButton();
            this.RdoShowMode1 = new System.Windows.Forms.RadioButton();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnTabClose = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TabMain.SuspendLayout();
            this.PgProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GdProjectList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.PgProject);
            this.TabMain.Location = new System.Drawing.Point(10, 36);
            this.TabMain.Name = "TabMain";
            this.TabMain.Padding = new System.Drawing.Point(10, 3);
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1136, 870);
            this.TabMain.TabIndex = 4;
            // 
            // PgProject
            // 
            this.PgProject.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PgProject.Controls.Add(this.GdProjectList);
            this.PgProject.Controls.Add(this.lblListCount);
            this.PgProject.Controls.Add(this.ChkShowCount);
            this.PgProject.Controls.Add(this.groupBox2);
            this.PgProject.Controls.Add(this.groupBox1);
            this.PgProject.Location = new System.Drawing.Point(4, 22);
            this.PgProject.Name = "PgProject";
            this.PgProject.Padding = new System.Windows.Forms.Padding(3);
            this.PgProject.Size = new System.Drawing.Size(1128, 844);
            this.PgProject.TabIndex = 1;
            this.PgProject.Text = "リスト一覧";
            // 
            // GdProjectList
            // 
            this.GdProjectList.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GdProjectList.Location = new System.Drawing.Point(155, 5);
            this.GdProjectList.Margin = new System.Windows.Forms.Padding(2);
            this.GdProjectList.Name = "GdProjectList";
            this.GdProjectList.Size = new System.Drawing.Size(966, 831);
            this.GdProjectList.TabIndex = 13;
            this.GdProjectList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GdProjectList_MouseDoubleClick);
            // 
            // lblListCount
            // 
            this.lblListCount.AutoSize = true;
            this.lblListCount.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblListCount.Location = new System.Drawing.Point(6, 235);
            this.lblListCount.Name = "lblListCount";
            this.lblListCount.Size = new System.Drawing.Size(0, 13);
            this.lblListCount.TabIndex = 21;
            // 
            // ChkShowCount
            // 
            this.ChkShowCount.AutoSize = true;
            this.ChkShowCount.Location = new System.Drawing.Point(13, 123);
            this.ChkShowCount.Margin = new System.Windows.Forms.Padding(2);
            this.ChkShowCount.Name = "ChkShowCount";
            this.ChkShowCount.Size = new System.Drawing.Size(104, 17);
            this.ChkShowCount.TabIndex = 7;
            this.ChkShowCount.Text = "最新200件表示";
            this.ChkShowCount.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdoShowMode3);
            this.groupBox2.Controls.Add(this.RdoShowMode2);
            this.groupBox2.Controls.Add(this.RdoShowMode1);
            this.groupBox2.Controls.Add(this.BtnSetting);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(8, 19);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(137, 81);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表示パターン";
            // 
            // RdoShowMode3
            // 
            this.RdoShowMode3.AutoSize = true;
            this.RdoShowMode3.Location = new System.Drawing.Point(73, 17);
            this.RdoShowMode3.Margin = new System.Windows.Forms.Padding(2);
            this.RdoShowMode3.Name = "RdoShowMode3";
            this.RdoShowMode3.Size = new System.Drawing.Size(32, 17);
            this.RdoShowMode3.TabIndex = 2;
            this.RdoShowMode3.TabStop = true;
            this.RdoShowMode3.Text = "C";
            this.RdoShowMode3.UseVisualStyleBackColor = true;
            this.RdoShowMode3.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // RdoShowMode2
            // 
            this.RdoShowMode2.AutoSize = true;
            this.RdoShowMode2.Location = new System.Drawing.Point(40, 17);
            this.RdoShowMode2.Margin = new System.Windows.Forms.Padding(2);
            this.RdoShowMode2.Name = "RdoShowMode2";
            this.RdoShowMode2.Size = new System.Drawing.Size(32, 17);
            this.RdoShowMode2.TabIndex = 1;
            this.RdoShowMode2.TabStop = true;
            this.RdoShowMode2.Text = "B";
            this.RdoShowMode2.UseVisualStyleBackColor = true;
            this.RdoShowMode2.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // RdoShowMode1
            // 
            this.RdoShowMode1.AutoSize = true;
            this.RdoShowMode1.Location = new System.Drawing.Point(8, 17);
            this.RdoShowMode1.Margin = new System.Windows.Forms.Padding(2);
            this.RdoShowMode1.Name = "RdoShowMode1";
            this.RdoShowMode1.Size = new System.Drawing.Size(32, 17);
            this.RdoShowMode1.TabIndex = 0;
            this.RdoShowMode1.TabStop = true;
            this.RdoShowMode1.Text = "A";
            this.RdoShowMode1.UseVisualStyleBackColor = true;
            this.RdoShowMode1.CheckedChanged += new System.EventHandler(this.RdoShowMode_CheckedChanged);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Enabled = false;
            this.BtnSetting.Location = new System.Drawing.Point(43, 42);
            this.BtnSetting.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(76, 25);
            this.BtnSetting.TabIndex = 10;
            this.BtnSetting.Text = "設定";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BtnClear);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.searchLabel);
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 162);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(137, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索";
            // 
            // BtnClear
            // 
            this.BtnClear.Enabled = false;
            this.BtnClear.Location = new System.Drawing.Point(47, 275);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(76, 25);
            this.BtnClear.TabIndex = 12;
            this.BtnClear.Text = "クリア";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox2.Location = new System.Drawing.Point(47, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "項目2";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox1.Location = new System.Drawing.Point(47, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 20);
            this.textBox1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "項目3";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(8, 23);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(89, 13);
            this.searchLabel.TabIndex = 26;
            this.searchLabel.Text = "検索項目の追加";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Enabled = false;
            this.BtnSearch.Location = new System.Drawing.Point(47, 245);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(76, 25);
            this.BtnSearch.TabIndex = 11;
            this.BtnSearch.Text = "検索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "項目1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox3.Location = new System.Drawing.Point(47, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(77, 20);
            this.textBox3.TabIndex = 3;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(1071, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 25);
            this.BtnClose.TabIndex = 15;
            this.BtnClose.Text = "終了";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnTabClose
            // 
            this.BtnTabClose.Location = new System.Drawing.Point(696, 3);
            this.BtnTabClose.Name = "BtnTabClose";
            this.BtnTabClose.Size = new System.Drawing.Size(112, 25);
            this.BtnTabClose.TabIndex = 14;
            this.BtnTabClose.Text = "現在のタブを閉じる";
            this.BtnTabClose.UseVisualStyleBackColor = true;
            this.BtnTabClose.Visible = false;
            this.BtnTabClose.Click += new System.EventHandler(this.BtnTabClose_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Enabled = false;
            this.BtnLogout.Location = new System.Drawing.Point(990, 3);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(75, 25);
            this.BtnLogout.TabIndex = 16;
            this.BtnLogout.Text = "ログアウト";
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Enabled = false;
            this.BtnNew.Location = new System.Drawing.Point(909, 3);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 25);
            this.BtnNew.TabIndex = 17;
            this.BtnNew.Text = "新規作成";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Location = new System.Drawing.Point(559, 3);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 25);
            this.BtnUpdate.TabIndex = 18;
            this.BtnUpdate.Text = "更新";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "高度";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmShowProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1154, 914);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.BtnTabClose);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TabMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmShowProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmShowProject_FormClosing);
            this.Load += new System.EventHandler(this.FrmShowProject_Load);
            this.TabMain.ResumeLayout(false);
            this.PgProject.ResumeLayout(false);
            this.PgProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GdProjectList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage PgProject;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnTabClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdoShowMode3;
        private System.Windows.Forms.RadioButton RdoShowMode2;
        private System.Windows.Forms.RadioButton RdoShowMode1;
        private System.Windows.Forms.CheckBox ChkShowCount;
        private System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.Label lblListCount;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.DataGridView GdProjectList;
        //internal C1.Win.C1FlexGrid.C1FlexGrid GdProjectList;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button button1;
    }
}

