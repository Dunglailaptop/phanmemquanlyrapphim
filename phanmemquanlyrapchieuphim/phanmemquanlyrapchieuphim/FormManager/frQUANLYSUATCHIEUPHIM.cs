using DevExpress.XtraBars;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYSUATCHIEUPHIM : DevExpress.XtraEditors.XtraForm
    {
        public frQUANLYSUATCHIEUPHIM()
        {
            InitializeComponent();
            loadphong();

            laytatcasuatchieu(dateTimePicker1.Value,dateTimePicker2.Value);
          
            //int id = int.Parse(dsphim.GetFocusedRowCellValue("maphim").ToString());
            //int maphong = int.Parse(dsphim.GetFocusedRowCellValue("Maphong").ToString());
            //string d = "12/23/2022";
            //loadphongbyid(1, Convert.ToDateTime(d));
        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("koko");
        }

        void loadphong()
        {
            comboBox1.DataSource = phongDAO.Instance.loadphong();
            comboBox1.DisplayMember = "tenphong";
            //DSPHONG.OptionsBehavior.Editable = false;
        }
        void loadsuatchieu(DateTime id, int maphim, int maphong,DateTime date2)
        {
            List<suatchieu> cl = new List<suatchieu>();
            gridControl3.DataSource = suatchieuDAO.Instance.LAYSUATCHIEU(id, maphim, maphong,date2);
            dssuatchieu.OptionsBehavior.Editable = false;
            //Button btn;
            //Label lb;
            //foreach (suatchieu su in cl)
            //{
            //    lb = new Label();
            //    lb.Text = "Ngày chiếu: ";
            //    btn = new Button();
            //    btn.Size = new Size(80, 50);
            //    btn.BackColor = Color.Bisque;
            //    btn.Text = su.thoigianchieu.ToString();
            //    btn.Click += BtnGhe_Click;
            //    flowLayoutPanel1.Controls.Add(btn);
            //}
        }
        void laytatcasuatchieu(DateTime DATE,DateTime date2)
        {
            gridControl2.DataSource = suatchieuDAO.Instance.getallsuatchieu(DATE,date2);
            dsphim.OptionsBehavior.Editable = false;
            buttonnew.Click += Buttonnew_Click;

            //US_SUATCHIEU SV;
            //foreach (Class c in cl)
            //{
            //    SV = new US_SUATCHIEU();
            //    SV.Tenphim = c.tenphim;
            //    SV.Thoiluong = c.thoiluong;
            //    SV.Loaiphim = c.loaiphim;
            //    SV.Poster = convertbytetoimage(c.poster);
            //    SV.Maphim = c.maphim;
            //    SV.Maphong = c.Maphong;
            //    SV.Time = DATE;
            //    flowLayoutPanel1.Controls.Add(SV);

            //}
        }
        void loadphongbyid(int id, DateTime date,DateTime date2)
        {
            gridControl2.DataSource = phongDAO.Instance.loadphongid(id, date,date2);
            dsphim.OptionsBehavior.Editable = false;
            //US_SUATCHIEU SV;
            //foreach (Class c in cl)
            //{
            //    SV = new US_SUATCHIEU();
            //    SV.Tenphim = c.tenphim;
            //    SV.Thoiluong = c.thoiluong;
            //    SV.Loaiphim = c.loaiphim;
            //    SV.Poster = convertbytetoimage(c.poster);
            //    SV.Maphim = c.maphim;
            //    SV.Maphong = id;
            //    SV.Time = date;
            //    flowLayoutPanel1.Controls.Add(SV);

            //}

        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void frQUANLYSUATCHIEUPHIM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phanmemquanlyrapchieuphimDataSet.phim' table. You can move, or remove it, as needed.
            this.phimTableAdapter.Fill(this.phanmemquanlyrapchieuphimDataSet.phim);
           
            //btnshow.Click += Btnshow_Click;

        }

        private void Buttonnew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dsjds0");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
            //loadphongbyid(id, dateTimePicker1.Value);
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            //gridControl2.Enabled = false;
            //int id = int.Parse(DSPHONG.GetFocusedRowCellValue("Maphong").ToString());
            //MessageBox.Show(id.ToString());
            //lbidphong.Text = id.ToString();
            //loadphongbyid(id, dateTimePicker1.Value,dateTimePicker2.Value);
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
           
        }

        private void gridControl2_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("0k");
            if (dsphim.GetFocusedRowCellValue("maphim") != null && dsphim.GetFocusedRowCellValue("Maphong") != null)
            {
                int id = int.Parse(dsphim.GetFocusedRowCellValue("maphim").ToString());
                int maphong = int.Parse(dsphim.GetFocusedRowCellValue("Maphong").ToString());
                DataClasses1DataContext db = new DataClasses1DataContext();
                phim ph = db.phims.Where(x => x.Maphim == id).SingleOrDefault();
                lbngaychieu.Text = dateTimePicker1.Text;
                lbngaychieu2.Text = dateTimePicker2.Text;
                lbtenphim.Text = ph.Tenphim;
                lbphong.Text = maphong.ToString();
                lbidmaphim.Text = Convert.ToString(ph.Maphim);
                loadsuatchieu(dateTimePicker1.Value, id, maphong, dateTimePicker2.Value);
                //int maphong = Convert.ToInt32(lbidphong.Text);
                //maphong=dsphim.VertScrollTipFieldName[maphong];
                //dsphim.Columns["Maphong"].ColumnHandle=maphong;

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            laytatcasuatchieu(dateTimePicker1.Value,dateTimePicker2.Value);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lbidphong.Text = "Toàn bộ";
            laytatcasuatchieu(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FRTHEMSUATCHIEUPHIM fr = new FRTHEMSUATCHIEUPHIM();
            fr.ShowDialog();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phong selected = cb.SelectedItem as phong;
            lbidphong.Text = Convert.ToString(selected.Maphong);
            loadphongbyid(int.Parse(lbidphong.Text), dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {
            if (dssuatchieu.GetFocusedRowCellValue("thoigianchieu") != null)
            {
                string time = dssuatchieu.GetFocusedRowCellValue("thoigianchieu").ToString();
                DateTime ngaychieu = Convert.ToDateTime(dssuatchieu.GetFocusedRowCellValue("ngaychieu").ToString());
                int maphim = int.Parse(lbidmaphim.Text);
                int maphong = int.Parse(lbphong.Text);
                try
                {
                    frCHITIETSUATCHIEUPHIM ch = new frCHITIETSUATCHIEUPHIM(time, maphong, ngaychieu, maphim);
                    ch.Show();
                }
                catch
                {

                }
              
            }
          
        }

        private void dsphim_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void btnshow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonnew_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show("okkk");
           
           
            
          
        }
    }
}