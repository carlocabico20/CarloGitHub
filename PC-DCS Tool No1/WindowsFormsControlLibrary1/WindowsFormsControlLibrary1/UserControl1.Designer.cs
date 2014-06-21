namespace WindowsFormsControlLibrary1
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
            this.TagTxt = new System.Windows.Forms.TextBox();
            this.RegisterTxt = new System.Windows.Forms.TextBox();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.OnButton = new System.Windows.Forms.Button();
            this.OffButton = new System.Windows.Forms.Button();
            this.NoTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TagTxt
            // 
            this.TagTxt.Location = new System.Drawing.Point(40, 5);
            this.TagTxt.Name = "TagTxt";
            this.TagTxt.ReadOnly = true;
            this.TagTxt.Size = new System.Drawing.Size(100, 20);
            this.TagTxt.TabIndex = 0;
            // 
            // RegisterTxt
            // 
            this.RegisterTxt.Location = new System.Drawing.Point(147, 5);
            this.RegisterTxt.Name = "RegisterTxt";
            this.RegisterTxt.ReadOnly = true;
            this.RegisterTxt.Size = new System.Drawing.Size(100, 20);
            this.RegisterTxt.TabIndex = 1;
            // 
            // StatusTxt
            // 
            this.StatusTxt.Location = new System.Drawing.Point(254, 5);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.ReadOnly = true;
            this.StatusTxt.Size = new System.Drawing.Size(53, 20);
            this.StatusTxt.TabIndex = 2;
            // 
            // OnButton
            // 
            this.OnButton.Location = new System.Drawing.Point(313, 3);
            this.OnButton.Name = "OnButton";
            this.OnButton.Size = new System.Drawing.Size(36, 23);
            this.OnButton.TabIndex = 3;
            this.OnButton.Text = "ON";
            this.OnButton.UseVisualStyleBackColor = true;
            this.OnButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // OffButton
            // 
            this.OffButton.Location = new System.Drawing.Point(355, 3);
            this.OffButton.Name = "OffButton";
            this.OffButton.Size = new System.Drawing.Size(36, 23);
            this.OffButton.TabIndex = 4;
            this.OffButton.Text = "OFF";
            this.OffButton.UseVisualStyleBackColor = true;
            this.OffButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // NoTxt
            // 
            this.NoTxt.Location = new System.Drawing.Point(3, 5);
            this.NoTxt.Name = "NoTxt";
            this.NoTxt.ReadOnly = true;
            this.NoTxt.Size = new System.Drawing.Size(31, 20);
            this.NoTxt.TabIndex = 5;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NoTxt);
            this.Controls.Add(this.OffButton);
            this.Controls.Add(this.OnButton);
            this.Controls.Add(this.StatusTxt);
            this.Controls.Add(this.RegisterTxt);
            this.Controls.Add(this.TagTxt);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(399, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TagTxt;
        private System.Windows.Forms.TextBox RegisterTxt;
        private System.Windows.Forms.TextBox StatusTxt;
        private System.Windows.Forms.Button OnButton;
        private System.Windows.Forms.Button OffButton;
        private System.Windows.Forms.TextBox NoTxt;
    }
}
