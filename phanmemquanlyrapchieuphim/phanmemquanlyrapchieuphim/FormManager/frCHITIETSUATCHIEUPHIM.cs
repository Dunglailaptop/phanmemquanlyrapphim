using DevExpress.XtraEditors;
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
    public partial class frCHITIETSUATCHIEUPHIM : DevExpress.XtraEditors.XtraForm
    {
        public frCHITIETSUATCHIEUPHIM(string tg, int maphong, DateTime date, int maphim)
        {
            InitializeComponent();
            laychitietsuatchieu(tg, maphong, maphim, date);
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;

        }
        Label lbmaphim = new Label();
        Label lbtest;
        int ghedat = 0;
        bool xoa = false;
        bool sua = false;
        void check(bool kt)
        {
            btnxoa.Enabled = !kt;
            btnsua.Enabled = !kt;
            btnluu.Enabled = !kt;
            btnhuy.Enabled = !kt;
        }
        //void xoasuatchieu(int machieu)
        //{

        //}
        void laychitietsuatchieu(string tg, int maphong, int maphim, DateTime date)
        {
            //TimeSpan cast = TimeSpan.Parse(tg);
            Class c = suatchieuDAO.Instance.laychitietsuatchieu(tg, maphong, maphim, date);


            lbtenphim.Text = c.tenphim;
            lbtenphim.Tag = c.machieu;
            lbngaychieu.Text = Convert.ToString(c.date);
            lbphongchieu.Text = Convert.ToString(c.Maphong);
            lbgiave.Text = Convert.ToString(c.giave);
            lbsuatchieu.Text = Convert.ToString(c.thoigianchieu);
            textEdit1.Text = c.giave.ToString();
            dateTimePicker1.Text = c.thoigianchieu;
            lbtongghe.Text = Convert.ToString(c.tongghe);
            lbmaphim.Visible = false;
            lbmaphim.Text = Convert.ToString(c.maphim);
            int gheofday = c.gheofday;
            lbgheofday.Text = gheofday.ToString();
            //laydsghedadat(tg,c.date,c.maphim, c.Maphong);
            //string time = "20:30:0";
            //string datt = "2022-08-12";
            layallghe(tg, c.date, c.maphim, c.Maphong,gheofday);
            loadloaighe(maphong,gheofday);

        }
        void layallghe(string tg, DateTime date, int maphim, int maphong,int gheofday)
        {
            List<Class> cs = suatchieuDAO.Instance.layallghe(maphong, tg, date, maphim);
            List<Class> CSs = suatchieuDAO.Instance.laydsghedadat(maphong, tg, date, maphim);
            int x = 5, y = 50, khoangcachx = 80, khoangcachy = 55, dem = 0;
            Button btnghe;


            foreach (Class c2 in cs)
            {

                //for (int i = 0; i < dong; i++)
                //{
                //x = 20;
                //for (int j = 0; j < cot; j++)
                //{

                btnghe = new Button();
                btnghe.Location = new Point(x, y);
                btnghe.Size = new Size(50, 40);
                //foreach (Class c2 in CS)
                //{
                //string check = c2.row + c2.soghe.ToString();
                string text = "A" + dem;
                btnghe.Text = c2.row.ToString();

                btnghe.BackColor = Color.White;
                btnghe.FlatAppearance.BorderColor = Color.FromArgb(Convert.ToInt32(c2.mausac));
                btnghe.FlatStyle = FlatStyle.Flat;





                //lbtest.Visible = false;



                //btnghe.Click += BtnGhe_Click;
                pnlghe.Controls.Add(btnghe);
                dem++;
                if (dem == gheofday)
                {
                    y += khoangcachy;
                    //khoangcachx = 100;
                    x = -74;
                    dem = 0;
                }
                //}
                //y += khoangcachy;
                x += khoangcachx;
                //}

                //}
            }
            foreach (Button ghe in pnlghe.Controls)
            {
                foreach (Class cc in CSs)
                {
                    if (ghe.Text == cc.row2)
                    {
                        ghe.BackColor = Color.Red;
                        ghedat++;
                    }
                    //else
                    //{
                    //    ghe.BackColor = Color.White;
                    //}
                }
            }
            lbdaghe.Text = Convert.ToString(ghedat);
            int tongghe = Convert.ToInt32(lbtongghe.Text);
            int ghedadat = Convert.ToInt32(ghedat);
            int tongla = tongghe - ghedadat;
            lbtrong.Text = Convert.ToString(tongla);
        }
        void laydsghedadat(string tg, DateTime date, int maphim, int maphong)
        {


            List<Class> CS = suatchieuDAO.Instance.laydsghedadat(maphong, tg, date, maphim);
            foreach (Class c2 in CS)
            {
                lbtest = new Label();
                string Text = Convert.ToString(c2.row);
                string checkghe = Text + c2.soghe.ToString();
                lbtest.Text = checkghe;
                //lbtest.Visible = false;
            }

        }
        void showghe(int dong, int cot)
        {

            int x, y = 10, khoangcachx = 65, khoangcachy = 50, dem = 1;
            Button btnghe;
            for (int i = 0; i < dong; i++)
            {
                x = 10;
                for (int j = 0; j < cot; j++)
                {

                    btnghe = new Button();
                    btnghe.Location = new Point(x, y);
                    btnghe.Size = new Size(50, 40);
                    //foreach (Class c2 in CS)
                    //{
                    //string check = c2.row + c2.soghe.ToString();
                    string text = "A" + dem;
                    btnghe.Text = text.ToString();
                    if (btnghe.Text == lbtest.Text)
                    {
                        btnghe.BackColor = Color.Red;
                    }
                    btnghe.BackColor = Color.White;
                    //btnghe.Click += BtnGhe_Click;
                    pnlghe.Controls.Add(btnghe);
                    dem++;
                    if (dem > 16)
                    {
                        dem = 1;
                    }
                    //}
                    x += khoangcachx;
                }
                y += khoangcachy;
            }


        }
        void loadloaighe(int maphong, int gheofday)
        {
            flowLayoutPanel1.Controls.Clear();
            us_loaighe us;
            List<loaighe> lg = new List<loaighe>();
            lg = loaigheDAO.Instance.loadloaighe2(maphong);
            foreach (loaighe g in lg)
            {
                us = new us_loaighe();
                us.Argb = g.mausac;
                us.Tenghe = g.tenloai;
                us.Giave = (int)g.giaghe;
                us.Id = g.id;
                us.Maphong = maphong;
                us.Gheofday = gheofday;
                //MessageBox.Show(us.Argb + " " + us.Tenghe);
                flowLayoutPanel1.Controls.Add(us);
                //us.Click += btn_clickloai;
            }

        }
        private void frCHITIETSUATCHIEUPHIM_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbngaychieu_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            if(xoa==true)
            {
                try
                {
                    if(suatchieuDAO.Instance.xoasuatchieu(int.Parse(lbtenphim.Tag.ToString())))
                        {
                        MessageBox.Show("xóa thành công suất chiếu");
                        this.Dispose();
                    }
                }catch
                {
                    MessageBox.Show("xóa thất bại suất chiếu");
                }
            }else if(sua==true)
            {
                try
                {
                    if (suatchieuDAO.Instance.suasuatchieu(int.Parse(lbtenphim.Tag.ToString()),decimal.Parse(textEdit1.Text),dateTimePicker1.Value,lbngaychieu.Value,int.Parse(lbmaphim.Text)))
                    {
                        MessageBox.Show("sửa thành công suất chiếu");
                        this.Dispose();
                    }
                }
                catch
                {
                    MessageBox.Show("sửa thất bại suất chiếu");
                }
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoa = true;
            sua = false;
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoa = false;
            sua = true;
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}