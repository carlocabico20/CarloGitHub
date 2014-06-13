namespace ButtonUserControl
{
    partial class UserControl1
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
            this.BtnTxt = new System.Windows.Forms.TextBox();
            this.SwAddrTxt = new System.Windows.Forms.TextBox();
            this.DoAddrTxt = new System.Windows.Forms.TextBox();
            this.AnsAddrTxt = new System.Windows.Forms.TextBox();
            this.SwStatBtn = new System.Windows.Forms.Button();
            this.DoStatBtn = new System.Windows.Forms.Button();
            this.AnsStatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTxt
            // 
            this.BtnTxt.Enabled = false;
            this.BtnTxt.Location = new System.Drawing.Point(6, 8);
            this.BtnTxt.Name = "BtnTxt";
            this.BtnTxt.Size = new System.Drawing.Size(82, 20);
            this.BtnTxt.TabIndex = 0;
            // 
            // SwAddrTxt
            // 
            this.SwAddrTxt.Enabled = false;
            this.SwAddrTxt.Location = new System.Drawing.Point(94, 8);
            this.SwAddrTxt.Name = "SwAddrTxt";
            this.SwAddrTxt.Size = new System.Drawing.Size(100, 20);
            this.SwAddrTxt.TabIndex = 1;
            // 
            // DoAddrTxt
            // 
            this.DoAddrTxt.Enabled = false;
            this.DoAddrTxt.Location = new System.Drawing.Point(281, 8);
            this.DoAddrTxt.Name = "DoAddrTxt";
            this.DoAddrTxt.Size = new System.Drawing.Size(100, 20);
            this.DoAddrTxt.TabIndex = 3;
            // 
            // AnsAddrTxt
            // 
            this.AnsAddrTxt.Enabled = false;
            this.AnsAddrTxt.Location = new System.Drawing.Point(468, 8);
            this.AnsAddrTxt.Name = "AnsAddrTxt";
            this.AnsAddrTxt.Size = new System.Drawing.Size(100, 20);
            this.AnsAddrTxt.TabIndex = 5;
            // 
            // SwStatBtn
            // 
            this.SwStatBtn.Location = new System.Drawing.Point(200, 7);
            this.SwStatBtn.Name = "SwStatBtn";
            this.SwStatBtn.Size = new System.Drawing.Size(75, 23);
            this.SwStatBtn.TabIndex = 6;
            this.SwStatBtn.Text = "On/Off";
            this.SwStatBtn.UseVisualStyleBackColor = true;
            this.SwStatBtn.Click += new System.EventHandler(this.SwStatBtn_Click);
            // 
            // DoStatBtn
            // 
            this.DoStatBtn.Location = new System.Drawing.Point(387, 7);
            this.DoStatBtn.Name = "DoStatBtn";
            this.DoStatBtn.Size = new System.Drawing.Size(75, 23);
            this.DoStatBtn.TabIndex = 7;
            this.DoStatBtn.Text = "On/Off";
            this.DoStatBtn.UseVisualStyleBackColor = true;
            this.DoStatBtn.Click += new System.EventHandler(this.DoStatBtn_Click);
            // 
            // AnsStatBtn
            // 
            this.AnsStatBtn.Location = new System.Drawing.Point(574, 7);
            this.AnsStatBtn.Name = "AnsStatBtn";
            this.AnsStatBtn.Size = new System.Drawing.Size(75, 23);
            this.AnsStatBtn.TabIndex = 8;
            this.AnsStatBtn.Text = "On/Off";
            this.AnsStatBtn.UseVisualStyleBackColor = true;
            this.AnsStatBtn.Click += new System.EventHandler(this.AnsStatBtn_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.AnsStatBtn);
            this.Controls.Add(this.DoStatBtn);
            this.Controls.Add(this.SwStatBtn);
            this.Controls.Add(this.AnsAddrTxt);
            this.Controls.Add(this.DoAddrTxt);
            this.Controls.Add(this.SwAddrTxt);
            this.Controls.Add(this.BtnTxt);
            this.Enabled = false;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(654, 36);           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BtnTxt;
        private System.Windows.Forms.TextBox SwAddrTxt;
        private System.Windows.Forms.TextBox DoAddrTxt;
        private System.Windows.Forms.TextBox AnsAddrTxt;
        private System.Windows.Forms.Button SwStatBtn;
        private System.Windows.Forms.Button DoStatBtn;
        private System.Windows.Forms.Button AnsStatBtn;
    }
}
