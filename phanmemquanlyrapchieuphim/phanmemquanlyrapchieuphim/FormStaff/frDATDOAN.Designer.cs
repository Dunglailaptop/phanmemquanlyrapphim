namespace phanmemquanlyrapchieuphim.FormStaff
{
    partial class frDATDOAN
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbtien = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.us_HDFOOD3 = new phanmemquanlyrapchieuphim.FormStaff.Us_HDFOOD();
            this.us_HDFOOD2 = new phanmemquanlyrapchieuphim.FormStaff.Us_HDFOOD();
            this.txthienthitien = new DevExpress.XtraEditors.TextEdit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txthienthitien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 962);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1173, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 84);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thanh toán";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txthienthitien);
            this.panel3.Controls.Add(this.lbtien);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1173, 783);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 179);
            this.panel3.TabIndex = 3;
            // 
            // lbtien
            // 
            this.lbtien.AutoSize = true;
            this.lbtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtien.Location = new System.Drawing.Point(270, 23);
            this.lbtien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtien.Name = "lbtien";
            this.lbtien.Size = new System.Drawing.Size(43, 29);
            this.lbtien.TabIndex = 3;
            this.lbtien.Text = "0đ";
            this.lbtien.Visible = false;
            this.lbtien.Click += new System.EventHandler(this.lbtien_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(13, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 87);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng tiền:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1656, 84);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(12, 699);
            this.panel4.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1173, 84);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(483, 699);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // us_HDFOOD3
            // 
            this.us_HDFOOD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.us_HDFOOD3.Enabled = false;
            this.us_HDFOOD3.Gia = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.us_HDFOOD3.Hinhanh = null;
            this.us_HDFOOD3.Location = new System.Drawing.Point(7, 382);
            this.us_HDFOOD3.Margin = new System.Windows.Forms.Padding(7);
            this.us_HDFOOD3.Masp = 0;
            this.us_HDFOOD3.Name = "us_HDFOOD3";
            this.us_HDFOOD3.Size = new System.Drawing.Size(502, 147);
            this.us_HDFOOD3.Soluong = 1;
            this.us_HDFOOD3.Soluong2 = 0;
            this.us_HDFOOD3.Soluongdau = 0;
            this.us_HDFOOD3.TabIndex = 1;
            this.us_HDFOOD3.Tendoanl = null;
            this.us_HDFOOD3.Tong = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.us_HDFOOD3.Tong2 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // us_HDFOOD2
            // 
            this.us_HDFOOD2.AutoSize = true;
            this.us_HDFOOD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.us_HDFOOD2.Enabled = false;
            this.us_HDFOOD2.Gia = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.us_HDFOOD2.Hinhanh = null;
            this.us_HDFOOD2.Location = new System.Drawing.Point(7, 7);
            this.us_HDFOOD2.Margin = new System.Windows.Forms.Padding(7);
            this.us_HDFOOD2.Masp = 0;
            this.us_HDFOOD2.Name = "us_HDFOOD2";
            this.us_HDFOOD2.Size = new System.Drawing.Size(1194, 361);
            this.us_HDFOOD2.Soluong = 1;
            this.us_HDFOOD2.Soluong2 = 0;
            this.us_HDFOOD2.Soluongdau = 0;
            this.us_HDFOOD2.TabIndex = 0;
            this.us_HDFOOD2.Tendoanl = null;
            this.us_HDFOOD2.Tong = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.us_HDFOOD2.Tong2 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txthienthitien
            // 
            this.txthienthitien.Location = new System.Drawing.Point(188, 26);
            this.txthienthitien.Name = "txthienthitien";
            this.txthienthitien.Size = new System.Drawing.Size(196, 26);
            this.txthienthitien.TabIndex = 4;
            // 
            // frDATDOAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 962);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frDATDOAN";
            this.Text = "Đặt đồ ăn";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txthienthitien.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbtien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Us_HDFOOD us_HDFOOD3;
        private Us_HDFOOD us_HDFOOD2;
        private DevExpress.XtraEditors.TextEdit txthienthitien;
    }
}