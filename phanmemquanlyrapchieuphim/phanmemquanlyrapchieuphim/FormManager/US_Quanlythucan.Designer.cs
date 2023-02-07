namespace phanmemquanlyrapchieuphim.FormManager
{
    partial class US_Quanlythucan
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
            this.lbdanhmuc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbtien = new System.Windows.Forms.Label();
            this.lbsl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbten = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbdanhmuc
            // 
            this.lbdanhmuc.AutoSize = true;
            this.lbdanhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdanhmuc.Location = new System.Drawing.Point(234, 302);
            this.lbdanhmuc.Name = "lbdanhmuc";
            this.lbdanhmuc.Size = new System.Drawing.Size(41, 29);
            this.lbdanhmuc.TabIndex = 7;
            this.lbdanhmuc.Text = "30";
            this.lbdanhmuc.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lbtien);
            this.panel2.Location = new System.Drawing.Point(165, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 58);
            this.panel2.TabIndex = 6;
            // 
            // lbtien
            // 
            this.lbtien.AutoSize = true;
            this.lbtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtien.Location = new System.Drawing.Point(18, 12);
            this.lbtien.Name = "lbtien";
            this.lbtien.Size = new System.Drawing.Size(143, 29);
            this.lbtien.TabIndex = 0;
            this.lbtien.Text = "30.000VND";
            // 
            // lbsl
            // 
            this.lbsl.AutoSize = true;
            this.lbsl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsl.Location = new System.Drawing.Point(61, 360);
            this.lbsl.Name = "lbsl";
            this.lbsl.Size = new System.Drawing.Size(41, 29);
            this.lbsl.TabIndex = 5;
            this.lbsl.Text = "30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "SL:";
            // 
            // lbten
            // 
            this.lbten.AutoSize = true;
            this.lbten.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbten.Location = new System.Drawing.Point(14, 292);
            this.lbten.Name = "lbten";
            this.lbten.Size = new System.Drawing.Size(202, 39);
            this.lbten.TabIndex = 3;
            this.lbten.Text = "Bắp rang bơ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::phanmemquanlyrapchieuphim.Properties.Resources.icons8_split_money_32;
            this.pictureBox2.Location = new System.Drawing.Point(157, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 29);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 271);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // US_Quanlythucan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbdanhmuc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbsl);
            this.Controls.Add(this.lbten);
            this.Name = "US_Quanlythucan";
            this.Size = new System.Drawing.Size(362, 407);
            this.Load += new System.EventHandler(this.US_Quanlythucan_Load);
            this.MouseLeave += new System.EventHandler(this.US_Quanlythucan_MouseLeave);
            this.MouseHover += new System.EventHandler(this.US_Quanlythucan_MouseHover);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbtien;
        private System.Windows.Forms.Label lbsl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbten;
        private System.Windows.Forms.Label lbdanhmuc;
    }
}
