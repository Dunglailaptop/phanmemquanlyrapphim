namespace phanmemquanlyrapchieuphim.FormManager
{
    partial class us_loaighe
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
            this.lbtenghe = new DevExpress.XtraEditors.LabelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.lbgia = new System.Windows.Forms.Label();
            this.lbhangghe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbtenghe
            // 
            this.lbtenghe.Enabled = false;
            this.lbtenghe.Location = new System.Drawing.Point(91, 20);
            this.lbtenghe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbtenghe.Name = "lbtenghe";
            this.lbtenghe.Size = new System.Drawing.Size(120, 19);
            this.lbtenghe.TabIndex = 1;
            this.lbtenghe.Text = "Ghế gần màn hình";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(5, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 49);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbgia
            // 
            this.lbgia.AutoSize = true;
            this.lbgia.Location = new System.Drawing.Point(265, 20);
            this.lbgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbgia.Name = "lbgia";
            this.lbgia.Size = new System.Drawing.Size(0, 19);
            this.lbgia.TabIndex = 3;
            // 
            // lbhangghe
            // 
            this.lbhangghe.AutoSize = true;
            this.lbhangghe.Location = new System.Drawing.Point(328, 20);
            this.lbhangghe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbhangghe.Name = "lbhangghe";
            this.lbhangghe.Size = new System.Drawing.Size(0, 19);
            this.lbhangghe.TabIndex = 4;
            this.lbhangghe.Visible = false;
            // 
            // us_loaighe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lbhangghe);
            this.Controls.Add(this.lbgia);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbtenghe);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "us_loaighe";
            this.Size = new System.Drawing.Size(428, 61);
            this.Load += new System.EventHandler(this.us_loaighe_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.us_loaighe_MouseClick);
            this.MouseHover += new System.EventHandler(this.us_loaighe_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lbtenghe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbgia;
        private System.Windows.Forms.Label lbhangghe;
    }
}
