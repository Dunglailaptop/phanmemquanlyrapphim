using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frDATDOAN : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        FlowLayoutPanel fl;
        Us_HDFOOD uss = new Us_HDFOOD();
        private decimal tong;
        private decimal giagiam;
        private decimal tongnew;
        private int soluongg;
        public decimal Giagiam { get => giagiam; set => giagiam = value; }
        public decimal Tong { get => tong; set => tong = value; }
        public int Soluongg { get => soluongg; set => soluongg = value; }
        //DataClasses1DataContext db = new DataClasses1DataContext();
        //private static frDATDOAN instance;
        //public static frDATDOAN Instance
        //{
        //    get { if (instance == null) instance = new frDATDOAN(); return frDATDOAN.instance; }
        //    private set { frDATDOAN.instance = value; }
        //}

        //private frDATDOAN()
        //{ }
        //public decimal Tongnew
        //{
        //    get { return tongnew; }
        //    set { tongnew = value;tongtien.Text =Convert.ToString(value);  } 
        //}

        public frDATDOAN()
        {
            InitializeComponent();
            loaddanhmuc();
          
        }
        public class XaiChung
        {

            private  int c;

            public int C { get => c; set => c = value; }
        }
        public void seachsanpham(int madm)
        {
            fl.Controls.Clear();
            List<sanpham> sp = new List<sanpham>();
            sp = SanPhamDAO.Instance.sreach(madm);
            US_Quanlythucan ta;
           
            foreach (sanpham s in sp)
            {
               //fl = new FlowLayoutPanel();
                ta = new US_Quanlythucan();
                ta.Tendanhmuc = s.Tensanpham;
                
                //soluongg += soluongg;
                MessageBox.Show(soluongg.ToString());
                ta.Soluong = (int)s.soluong;
                ta.Gia = (decimal)s.Gia;
                ta.Madanhmuc = (int)s.Madanhmuc;
                ta.Masp = s.Masp;
                ta.Hinhanh = (Byte[])s.hinhanh.ToArray();

                //Fl fl = new FlowLayoutPanel();

                // fl = new FlowLayoutPanel();
                fl.Controls.Add(ta);
                //TabPage;
                //ta.Click += new System.EventHandler(this.btn_click);
            }
        }
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        void loaddanhmuc()
        {
            //cbdanhmuc.SelectedIndex = 1;
            //cbdanhmuc.;
            TabPage tab;
         List<danhmucsp> dn = SanPhamDAO.Instance.showlistdanhmuc();
         
            foreach (danhmucsp dp in dn)
            {

                tab = new TabPage();
                tab.Text =dp.tendanhmuc;
                tab.Tag = dp.Madm;
                float size = 20;
                size = tab.Font.Size;
                tab.BorderStyle=BorderStyle.FixedSingle;
                tabControl1.TabPages.Add(tab);
                fl = new FlowLayoutPanel();
                fl.BackColor = Color.White;
                fl.Dock = DockStyle.Fill;
                fl.AutoScroll = true;
                fl.AutoSize = true;
                //fl.Controls.Clear();
                List<sanpham> sp = new List<sanpham>();
                sp = SanPhamDAO.Instance.sreach(Convert.ToInt32(tab.Tag));
                Us_DSFOOD ta;

                foreach (sanpham s in sp)
                {
                    //fl = new FlowLayoutPanel();
                    ta = new Us_DSFOOD();
                    ta.Tendanhmuc = s.Tensanpham;
                    ta.Soluong = (int)s.soluong;
                  if(ta.Tendanhmuc==tensp)
                    {
                        ta.Soluong = (int)(s.soluong - mess);
                    }
                    
                    ta.Gia = (decimal)s.Gia;
                    ta.Madanhmuc = (int)s.Madanhmuc;
                    ta.Masp = s.Masp;
                    ta.Hinhanh = (Byte[])s.hinhanh.ToArray();
                    //ta.AutoSize = true;
                    //ta.Size = new Size(362, 407);
                    //Fl fl = new FlowLayoutPanel();

                    // fl = new FlowLayoutPanel();
                    fl.Controls.Add(ta);
                    //TabPage;
                    ta.Click += new System.EventHandler(this.btn_click);
                }
                //flowLayoutPanel1.Controls.Clear();
                tab.Controls.Add(fl);
                //MessageBox.Show(tab.Tag.ToString());
                //tab.Controls.Add(fl);
               


                //tab.Click += tabPage1_Click;
            }
            //cbdanhmuc.Items.Add("Tất cả");

        }

        private void btn_click(object sender, EventArgs e)
        {
            Us_DSFOOD FOOD = (Us_DSFOOD)sender;
            Us_HDFOOD F = new Us_HDFOOD();
            F.Hinhanh = convertbytetoimage(FOOD.Hinhanh);
            F.Tendoanl = FOOD.Tendanhmuc;
            F.Masp = FOOD.Masp;
            F.Gia = FOOD.Gia;
            //F.Soluong += 1;
            flowLayoutPanel1.Controls.Add(F);
            string test="yes";
            int dem = 0;
            int dem2 = 0;
            decimal gia=0;
            int ctr;
            decimal giamoi = 0;
            foreach (Us_HDFOOD cv in flowLayoutPanel1.Controls)
            {
                if(FOOD.Tendanhmuc==cv.Tendoanl)
                {
                    dem++;
                    if(dem==1)
                    {
                        test = "chua";
                        gia = Convert.ToDecimal(FOOD.Gia);
                        //MessageBox.Show(gia.ToString());
                    }else if(dem==2)
                    {
                        test = "da";
                    }
                    //if (cv.Soluong == 1) { 

                        cv.Soluong++;
                    //}
                  
                         //MessageBox.Show(F.Soluong.ToString()+cv.Soluong+cv.Tendoanl);
                     giamoi  = Convert.ToDecimal(gia)*Convert.ToDecimal(cv.Soluong);
                        
                    
                   
                }
            }
            if (test == "da")
            {
                //uss = F;
                
                flowLayoutPanel1.Controls.Remove(F);


            }
            else if (test == "chua")
            {
                //foreach (Us_HDFOOD s in flowLayoutPanel1.Controls)
                //{
                //MessageBox.Show(F.Tendoanl + F.Soluong.ToString());
                //    soluongg += s.Soluong;
                //    gia = gia * soluongg;
                //}
        
            }
            tong += giamoi;
            lbtien.Text = tong.ToString();
            txthienthitien.Text = String.Format("{0:0,0 vnd}", tong);
            //lbtien.Text = String.Format("{0,0,0,vnd}",long.Parse(tong.ToString()));
            F.Click += new System.EventHandler(this.btn_click2);
           
        }
        static int mess=0;
        static string tensp=null;
        public static void DelegateMethod(int solg,string ten)
        {
             mess=solg;
            tensp = ten;
        }
        private void btn_click2(object sender, EventArgs e)
        {
            Us_HDFOOD nn = (Us_HDFOOD)sender;
            //MessageBox.Show(nn.Soluong.ToString());
            tong= tong - nn.Gia*nn.Soluong;
            lbtien.Text = String.Format("{0:0,0 vnd}",tong);
            txthienthitien.Text = String.Format("{0:0,0 vnd}", tong);
            flowLayoutPanel1.Controls.Remove(nn);
        
        }

        private void F2_updateEventHandler(object sender, Us_HDFOOD.UpdateEventArgs args)
        {
            MessageBox.Show(giagiam.ToString());
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public int soluong()
        {
            
            //frHOADONFOOD fr = new frHOADONFOOD();
            foreach (Us_HDFOOD s in flowLayoutPanel1.Controls)
            {
                
                MessageBox.Show(s.Tendoanl + s.Soluong.ToString());
               
               
               
                    soluongg += s.Soluong;
            }
            //fr.Show();
            //soluongg += soluongg;
            MessageBox.Show(soluongg.ToString());
            return soluongg;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string list = null;
                string masp = null;
                foreach (Us_HDFOOD s in flowLayoutPanel1.Controls)
                {

                    //MessageBox.Show(s.Tendoanl + s.Soluong.ToString());
                    list += s.Tendoanl + ":" + s.Soluong + ":" + s.Gia + ":" + s.Masp + ",";
                    masp += s.Masp + ":";

                    soluongg += s.Soluong;
                }
                if(list != null)
                {
                    frHOADONFOOD fr = new frHOADONFOOD(list);
                    fr.Solg = Decimal.Parse(lbtien.Text);
                    //fr.Masp = masp;
                    fr.ShowDialog();
                    //MessageBox.Show(masp.ToString());
                    //MessageBox.Show(soluongg.ToString());
                }else
                {
                    MessageBox.Show("lỗi rỗng");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi");
            }
           
        }

        private void tongtien_Click(object sender, EventArgs e)
        {

        }

        private void tongtien_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //MessageBox.Show(giagiam.ToString());
            //foreach (Us_HDFOOD f in flowLayoutPanel1.Controls)
            //{
            //    MessageBox.Show(f.Tendoanl);
            //    tong += f.Gia;

            //}
            //lbtien.Text = Convert.ToString(tong - giagiam);
        }

        private void lbtien_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
