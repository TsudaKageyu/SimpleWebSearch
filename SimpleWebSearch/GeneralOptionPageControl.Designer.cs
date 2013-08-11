namespace TsudaKageyu.SimpleWebSearch
{
    partial class GeneralOptionPageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDefaultBrowser = new System.Windows.Forms.RadioButton();
            this.rbBuiltInBrowser = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tipEncoding = new System.Windows.Forms.ToolTip(this.components);
            this.btnRestoreDefault = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbDefaultBrowser);
            this.groupBox1.Controls.Add(this.rbBuiltInBrowser);
            this.groupBox1.Location = new System.Drawing.Point(0, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 45);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open results in...";
            // 
            // rbDefaultBrowser
            // 
            this.rbDefaultBrowser.AutoSize = true;
            this.rbDefaultBrowser.Checked = true;
            this.rbDefaultBrowser.Location = new System.Drawing.Point(22, 18);
            this.rbDefaultBrowser.Name = "rbDefaultBrowser";
            this.rbDefaultBrowser.Size = new System.Drawing.Size(144, 16);
            this.rbDefaultBrowser.TabIndex = 3;
            this.rbDefaultBrowser.TabStop = true;
            this.rbDefaultBrowser.Text = "System default browser";
            this.rbDefaultBrowser.UseVisualStyleBackColor = true;
            // 
            // rbBuiltInBrowser
            // 
            this.rbBuiltInBrowser.AutoSize = true;
            this.rbBuiltInBrowser.Location = new System.Drawing.Point(172, 18);
            this.rbBuiltInBrowser.Name = "rbBuiltInBrowser";
            this.rbBuiltInBrowser.Size = new System.Drawing.Size(192, 16);
            this.rbBuiltInBrowser.TabIndex = 4;
            this.rbBuiltInBrowser.Text = "Built-in browser of Visual Studio";
            this.rbBuiltInBrowser.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbEncoding);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtURL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 114);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Engine";
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(108, 85);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(126, 20);
            this.cmbEncoding.TabIndex = 2;
            this.cmbEncoding.SelectedIndexChanged += new System.EventHandler(this.cmbEncoding_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Query Encoding";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "%QUERY% will be replaced with an actual query word.";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(108, 43);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(296, 19);
            this.txtURL.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Query URL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Menu Caption";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(108, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(296, 19);
            this.txtName.TabIndex = 0;
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestoreDefault.Location = new System.Drawing.Point(0, 227);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.btnRestoreDefault.Size = new System.Drawing.Size(133, 23);
            this.btnRestoreDefault.TabIndex = 5;
            this.btnRestoreDefault.Text = "Restore Default";
            this.btnRestoreDefault.UseVisualStyleBackColor = true;
            this.btnRestoreDefault.Click += new System.EventHandler(this.btnRestoreDefault_Click);
            // 
            // GeneralOptionPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRestoreDefault);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "GeneralOptionPageControl";
            this.Size = new System.Drawing.Size(410, 250);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDefaultBrowser;
        private System.Windows.Forms.RadioButton rbBuiltInBrowser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolTip tipEncoding;
        private System.Windows.Forms.Button btnRestoreDefault;
    }
}
