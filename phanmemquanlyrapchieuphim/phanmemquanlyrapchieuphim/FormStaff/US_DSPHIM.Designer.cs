namespace phanmemquanlyrapchieuphim.FormStaff
{
    partial class US_DSPHIM
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
            this.lbngaychieu = new System.Windows.Forms.Label();
            this.lbtenphim = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbngaychieu
            // 
            this.lbngaychieu.AutoSize = true;
            this.lbngaychieu.BackColor = System.Drawing.Color.Moccasin;
            this.lbngaychieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngaychieu.Location = new System.Drawing.Point(4, 474);
            this.lbngaychieu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbngaychieu.Name = "lbngaychieu";
            this.lbngaychieu.Size = new System.Drawing.Size(48, 29);
            this.lbngaychieu.TabIndex = 1;
            this.lbngaychieu.Text = "tim";
            // 
            // lbtenphim
            // 
            this.lbtenphim.AutoSize = true;
            this.lbtenphim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenphim.Location = new System.Drawing.Point(4, 445);
            this.lbtenphim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtenphim.Name = "lbtenphim";
            this.lbtenphim.Size = new System.Drawing.Size(87, 29);
            this.lbtenphim.TabIndex = 2;
            this.lbtenphim.Text = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 424);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // US_DSPHIM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbngaychieu);
            this.Controls.Add(this.lbtenphim);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "US_DSPHIM";
            this.Size = new System.Drawing.Size(430, 519);
            this.Load += new System.EventHandler(this.US_DSPHIM_Load);
            this.MouseLeave += new System.EventHandler(this.US_DSPHIM_MouseLeave);
            this.MouseHover += new System.EventHandler(this.US_DSPHIM_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbtenphim;
        private System.Windows.Forms.Label lbngaychieu;
    }
}
