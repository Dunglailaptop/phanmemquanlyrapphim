namespace phanmemquanlyrapchieuphim.FormManager
{
    partial class themsuat
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
            this.gridControleft = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Ngaychieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thoigian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlright = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cbtenphim = new System.Windows.Forms.ComboBox();
            this.Ngaychieuu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControleft
            // 
            this.gridControleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControleft.Location = new System.Drawing.Point(0, 0);
            this.gridControleft.MainView = this.gridView1;
            this.gridControleft.Name = "gridControleft";
            this.gridControleft.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.check});
            this.gridControleft.Size = new System.Drawing.Size(529, 803);
            this.gridControleft.TabIndex = 0;
            this.gridControleft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.Ngaychieu,
            this.thoigian});
            this.gridView1.GridControl = this.gridControleft;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "checkbox";
            this.gridColumn1.ColumnEdit = this.check;
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // check
            // 
            this.check.AutoHeight = false;
            this.check.Name = "check";
            // 
            // Ngaychieu
            // 
            this.Ngaychieu.Caption = "Ngaychieu";
            this.Ngaychieu.FieldName = "Ngaybatdau";
            this.Ngaychieu.MinWidth = 25;
            this.Ngaychieu.Name = "Ngaychieu";
            this.Ngaychieu.Visible = true;
            this.Ngaychieu.VisibleIndex = 1;
            this.Ngaychieu.Width = 94;
            // 
            // thoigian
            // 
            this.thoigian.Caption = "thoigian";
            this.thoigian.FieldName = "thoigianchieu";
            this.thoigian.MinWidth = 25;
            this.thoigian.Name = "thoigian";
            this.thoigian.Visible = true;
            this.thoigian.VisibleIndex = 2;
            this.thoigian.Width = 94;
            // 
            // gridControlright
            // 
            this.gridControlright.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridControlright.Location = new System.Drawing.Point(741, 0);
            this.gridControlright.MainView = this.gridView2;
            this.gridControlright.Name = "gridControlright";
            this.gridControlright.Size = new System.Drawing.Size(540, 803);
            this.gridControlright.TabIndex = 1;
            this.gridControlright.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ngaychieuu});
            this.gridView2.GridControl = this.gridControlright;
            this.gridView2.Name = "gridView2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(555, 201);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(180, 109);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(555, 365);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(180, 130);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(535, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(535, 74);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // cbtenphim
            // 
            this.cbtenphim.FormattingEnabled = true;
            this.cbtenphim.Location = new System.Drawing.Point(535, 138);
            this.cbtenphim.Name = "cbtenphim";
            this.cbtenphim.Size = new System.Drawing.Size(200, 27);
            this.cbtenphim.TabIndex = 6;
            this.cbtenphim.SelectedIndexChanged += new System.EventHandler(this.cbtenphim_SelectedIndexChanged);
            // 
            // Ngaychieuu
            // 
            this.Ngaychieuu.Caption = "Ngaychieu";
            this.Ngaychieuu.FieldName = "Ngaychieu";
            this.Ngaychieuu.MinWidth = 25;
            this.Ngaychieuu.Name = "Ngaychieuu";
            this.Ngaychieuu.Visible = true;
            this.Ngaychieuu.VisibleIndex = 0;
            this.Ngaychieuu.Width = 94;
            // 
            // themsuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 803);
            this.Controls.Add(this.cbtenphim);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControlright);
            this.Controls.Add(this.gridControleft);
            this.Name = "themsuat";
            this.Text = "themsuat";
            this.Load += new System.EventHandler(this.themsuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControleft;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControlright;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cbtenphim;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit check;
        private DevExpress.XtraGrid.Columns.GridColumn Ngaychieu;
        private DevExpress.XtraGrid.Columns.GridColumn thoigian;
        private DevExpress.XtraGrid.Columns.GridColumn Ngaychieuu;
    }
}