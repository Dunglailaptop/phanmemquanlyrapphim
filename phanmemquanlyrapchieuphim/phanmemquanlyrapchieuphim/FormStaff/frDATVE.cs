using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frDATVE : DevExpress.XtraEditors.XtraForm
    {
        int maphimm = 0;
        int maphongg = 0;
        private string suatchieu;
        public frDATVE(string time,int maphong,int maphim,DateTime date)
        {
            InitializeComponent();
            maphimm = maphim;
            maphongg = maphong;
            laychitietsuatchieu(time, maphong, maphim,date);
            loadloaighe(maphong);
        }
        Label lbmaphim = new Label();
        Label lbtest;
        Label maghee;
        int ghedat = 0;
     
        int machieu = 0;

        public string Suatchieu
        {
            get { return suatchieu; }
            set { suatchieu = value;lbsuatchieu.Text = value; } 
        }

        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        void laychitietsuatchieu(string tg, int maphong, int maphim, DateTime date)
        {
            Class c = suatchieuDAO.Instance.laychitietsuatchieu(tg, maphong, maphim, date);


            lbtenphim.Text = c.tenphim;
            lbngaychieu.Text = Convert.ToString(c.ngaychieushow);
            lbphongchieu.Text = Convert.ToString(c.Maphong);
            lbgiave.Text = Convert.ToString(c.giave)+"VND";
            lbsuatchieu.Text = Convert.ToString(c.thoigianchieu);
            lbtongghe.Text = Convert.ToString(c.tongghe);
            lbmaphim.Visible = false;
            lbmaphim.Text = Convert.ToString(c.maphim);
            //maphim = c.maphim;
            machieu = c.machieu;
            pictureBox1.Image = convertbytetoimage(c.poster);
            //laydsghedadat(tg,c.date,c.maphim, c.Maphong);
            //string time = "20:30:0";
            //string datt = "2022-08-12";
            layallghe(tg, c.date, c.maphim, c.Maphong);

        }
        void loadloaighe(int maphong)
        {
            pnldsghe.Controls.Clear();
            us_loaighe us;
            List<loaighe> lg = new List<loaighe>();
            lg = loaigheDAO.Instance.loadloaighebyphong(maphong);
            foreach (loaighe g in lg)
            {
                us = new us_loaighe();
                us.Argb = g.mausac;
                us.Tenghe = g.tenloai;
                us.Giave = (int)g.giaghe;
                us.Id = g.id;
                //us.Maphong = maphong;
                //us.Gheofday = gheofday;
                //MessageBox.Show(us.Argb + " " + us.Tenghe);
                pnldsghe.Controls.Add(us);
                //us.Click += btn_clickloai;
            }

        }
        void layallghe(string tg, DateTime date, int maphim, int maphong)
        {
            List<Class> cs = suatchieuDAO.Instance.layallghe(maphong, tg, date, maphim);
            List<Class> CSs = suatchieuDAO.Instance.laydsghedadat(maphong, tg, date, maphim);
            int x = 5, y = 50, khoangcachx = 80, khoangcachy = 90, dem = 1;
            Button btnghe;
            //Label maghe;

            foreach (Class c2 in cs)
            {

                //for (int i = 0; i < dong; i++)
                //{
                //x = 20;
                //for (int j = 0; j < cot; j++)
                //{

                btnghe = new Button();
                btnghe.Location = new Point(x, y);
                btnghe.Size = new Size(70, 70);
                //foreach (Class c2 in CS)
                //{
                //string check = c2.row + c2.soghe.ToString();
                string text = "A" + dem;
                btnghe.Text = c2.row.ToString();
                //maghee = new Label();
                btnghe.Tag = c2.maghe;
                btnghe.FlatAppearance.BorderColor = Color.FromArgb(Convert.ToInt32(c2.mausac));
                btnghe.FlatStyle = FlatStyle.Flat;
                //maghee.Text = Convert.ToString(c2.maghe);
                //maghee.Visible = false;
                if(c2.trangthaighe==0)
                {
                    btnghe.BackColor = Color.Black;
                }
                //btnghe.BackColor = Color.White;
                //btnghe.FlatStyle = FlatStyle.Flat;
                //btnghe.FlatAppearance.BorderColor = Color.Green;
                //for(int i = 0; i < CSs.ToList(); i++)
                //{
             

                //}







                //lbtest.Visible = false;




                pnlghe.Controls.Add(btnghe);
                dem++;
                if(dem==3)
                {
                    x = 200;
                }
                if(dem==15)
                {
                    x = 1280;
                }
                if (dem == c2.gheofday+1)
                {
                    y += khoangcachy;
                    //khoangcachx = 100;
                    x = -74;
                    dem = 1;
                }
                //}
                //y += khoangcachy;
                x += khoangcachx;
                //}
                btnghe.Click += BtnGhe_Click;
                //}
            }
            foreach (Button ghe in pnlghe.Controls)
            {
                foreach (Class cc in CSs)
                {
                    if (ghe.Text==cc.row2)
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

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btnghe = (Button)sender;
            //Label MAGH =(Label)sender;
            List<loaighe> lg = new List<loaighe>();
            lg = loaigheDAO.Instance.loadloaighebyphong(maphongg);
            decimal gialoaighe=0;
            int dem = 0;
            decimal tong = 0;
            if (btnghe.BackColor == Color.Red)
            {
                MessageBox.Show("hang ghe da duoc mua");
                return;
            }
            if(btnghe.BackColor == Color.Black)
            {
                MessageBox.Show("ghế bị hỏng");
                return;
            }
            //string lbghee = lbghe.Text;
            string[] tach = lbghe.Text.Split(',');
            for (int i = 0; i < tach.Length; i++)
            {
                if (i == 7)
                {
                    //lbghe.Text = lbghee;
                    //MessageBox.Show("Bạn chỉ được đặt tối đa là 7 vé");
                    dem = 7;
                }
            }
          
                


            //btnghe.BackColor = (btnghe.BackColor == Color.White) ? Color.Blue : Color.White;
            if (btnghe.BackColor == Color.White)
            {
                if (dem < 7)
                {
                    btnghe.BackColor = Color.Blue;
                    lbghe.Text += btnghe.Text + ",";
                    LBMAGHE.Text += btnghe.Tag.ToString() + ",";
                    foreach (loaighe he in lg)
                    {
                        int mau = btnghe.FlatAppearance.BorderColor.ToArgb();
                        if(he.mausac==mau.ToString())
                        {
                            gialoaighe = (decimal)he.giaghe;
                            break;
                        }

                    }
                    //LBMAGHE.Text += MAGH.Text + ",";
                    foreach (Button ghe in pnlghe.Controls)
                    {
                        if (ghe.BackColor == Color.Blue)
                        {
                            string giav = null;
                            var giave = new string[] { "VND" };
                            foreach (var c in giave)
                            {
                                giav = lbgiave.Text.Replace(c, string.Empty);
                            }
                            tong += Convert.ToDecimal(giav)+gialoaighe;
                            txttonggia.Text = String.Format("{0:0,0 VND}",tong);
                        }

                    }


                }
                else if (dem == 7)
                {
                    MessageBox.Show("Bạn chỉ được đặt tối đa là 7 vé");
                }
            }
            else
            {
                foreach (loaighe he in lg)
                {
                    int mau = btnghe.FlatAppearance.BorderColor.ToArgb();
                    if (he.mausac == mau.ToString())
                    {
                        gialoaighe = (decimal)he.giaghe;
                        break;
                    }

                }
                btnghe.BackColor = Color.White;
                var charsToRemove = new string[] { btnghe.Text + "," };
                foreach (var c in charsToRemove)
                {
                    lbghe.Text = lbghe.Text.Replace(c, string.Empty);
                }
                var maghetach = new string[] { btnghe.Tag + "," };
                foreach (var c in maghetach)
                {
                    LBMAGHE.Text = LBMAGHE.Text.Replace(c, string.Empty);
                }
                dem--;
                foreach (Button ghe in pnlghe.Controls)
                {
                    if (ghe.BackColor == Color.Blue)
                    {
                        string giav = null;
                        var giave = new string[] { "VND" };
                        foreach (var c in giave)
                        {
                            giav = lbgiave.Text.Replace(c, string.Empty);
                        }
                        tong += Convert.ToDecimal(giav)+gialoaighe;
                        txttonggia.Text = string.Format("{0:0,0 VND}",tong);
                    }

                }
                //btnghe.BackColor=Color.White;
                //string input = "," + btnghe.Text;
                //lbghe.Text.Remove(input);

                //lbghe.Text.Replace(","+btnghe.Text," ");
            }
            
      
            
            
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
        private void frDATVE_Load(object sender, EventArgs e)
        {

        }

        private void pnlghe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if(txttonggia.Text == null)
            {
                MessageBox.Show("khong co ghe duoc chon");
            }
            frHOADON fr = new frHOADON();
            fr.Tenphim = lbtenphim.Text;
            fr.Date = lbngaychieu.Text;
            fr.Time =lbsuatchieu.Text;
            fr.Ghe=lbghe.Text;
            fr.Maghe = LBMAGHE.Text;
            fr.Machieu = machieu;
            fr.Maphim = maphimm;
            fr.Maphong = maphongg;
            var giave = new string[] { "VND" };
            string giav = null;
            foreach (var c in giave)
            {
                giav = lbgiave.Text.Replace(c, string.Empty);
            }
            fr.Giave = Convert.ToDecimal(giav);
            //fr.Giave = Convert.ToDecimal(giav);
            //int tong = 0;
            var TONG = new string[] { "VND" };
            string tongtien = null;
            foreach (var c in TONG)
            {
               tongtien = txttonggia.Text.Replace(c, string.Empty);
            }
            

            fr.Tong = Convert.ToDecimal(tongtien);

            //this.Close();
            fr.ShowDialog();
            
            
            
        }

        private void pnlghe_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void pnldsghe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlghe_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnldsghe_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(pnldsghe.Visible==true)
            {
                pnldsghe.Visible = false;
            }else if(pnldsghe.Visible==false)
            {
                pnldsghe.Visible = true;
            }
        }

        private void pnlghe_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                //panel3.Visible = true;
            }
            else if (panel1.Visible == false)
            {
                panel1.Visible = true;
                //panel3.Visible = false;
            }
        }
    }
}
