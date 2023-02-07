namespace phanmemquanlyrapchieuphim.FormStaff
{
    partial class us_tongtien
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbtong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền:";
            // 
            // lbtong
            // 
            this.lbtong.AutoSize = true;
            this.lbtong.Location = new System.Drawing.Point(89, 17);
            this.lbtong.Name = "lbtong";
            this.lbtong.Size = new System.Drawing.Size(66, 16);
            this.lbtong.TabIndex = 1;
            this.lbtong.Text = "Tổng tiền:";
            // 
            // us_tongtien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbtong);
            this.Controls.Add(this.label1);
            this.Name = "us_tongtien";
            this.Size = new System.Drawing.Size(510, 60);
            this.Load += new System.EventHandler(this.us_tongtien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtong;
    }
}
