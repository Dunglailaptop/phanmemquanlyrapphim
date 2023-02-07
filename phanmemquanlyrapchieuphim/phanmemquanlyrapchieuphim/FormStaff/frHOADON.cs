using phanmemquanlyrapchieuphim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webtnonline.Models;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frHOADON : DevExpress.XtraEditors.XtraForm
    {
        public frHOADON()
        {
            InitializeComponent();
            lbmaghe.Visible = false;
        }
        private string tenphim;
        private string ghe;
        private decimal giave;
        private string date;
        private string time;
        private decimal tong;
        private int maphim;
        private int machieu;
        private string maghe;
        private int maphong;
        Label lbmaghe=new Label();

        public string Tenphim 
        {
            get { return tenphim; }
            set { tenphim = value; lbtenphim.Text = value; }
        }
        public string Ghe
        {
            get { return ghe; }
            set { ghe = value;lbghe.Text = value; } 
        }
        public decimal Giave
        {
            get { return giave; }
            set { giave = value;lbgiave.Text = String.Format("{0:0,0 VND}",value); } 
        }
        public string Date {
            get { return date; }
            set { date = value; lbngay.Text = value; } 
        }
        public string Time
        {
            get { return time; }
            set { time = value;lbsuatchieu.Text = Convert.ToString(value); } 
        }

        public decimal Tong
        {
            get { return tong; }
            set { tong = value; lbtong.Text =String.Format("{0:0,0 VND}",value); }
        }

        public int Maphim { get => maphim; set => maphim = value; }
        public int Machieu { get => machieu; set => machieu = value; }
        public string Maghe {
            get { return maghe; }
            set { maghe = value; lbmaghe.Text = value; } 
        }

        public int Maphong
        {
            get { return maphong; }
            set { maphong = value;lbphong.Text = Convert.ToString(value); } 
        }

        //void thanhtoan(string mahoadon,DateTime Ngaytao, decimal giaveduocgiam, int soluongve, int maphim, decimal tongtien, decimal giave)
        //{
        //    HoaDonDAO.Instance.THANHTOAN(mahoadon,Ngaytao,giaveduocgiam,soluongve,maphim,tongtien,giave);
        //}
        //void insertghe(int machieu,int maghe)
        //{
        //    HoaDonDAO.Instance.INSERTGHEDAMUA(machieu, maghe);
        //}
        void insertvexem(string mahoadon,int machieu,int maghe)
        {
            HoaDonDAO.Instance.INSERTVEXEM(mahoadon, machieu, maghe);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {

            this.Close();
            frDATVE FR = new frDATVE(Time.ToString(),maphong,maphim,Convert.ToDateTime(date));
            FR.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] soluong = lbghe.Text.Split(',');
            //int dem = 0;
            //for (int i = 0; i < soluong.Length; i++)
            //{
            //    if (soluong[i]!="")
            //    {
            //        dem++;
            //    }
              

            //}
            //Random r = new Random();
            //string HD = "HD";
            //string mahoadon = crypt.Encrypt(HD.Trim() + r.Next().ToString(), true);
            //DateTime dateTime = DateTime.Now;
            //thanhtoan(mahoadon,dateTime , 0, dem, Maphim, tong, Giave);
            //string[] soluongmaghe = lbmaghe.Text.Split(',');
           
            //for (int i = 0; i < soluongmaghe.Length; i++)
            //{
            //    if (soluongmaghe[i] != "")
            //    {
            //        insertvexem(mahoadon, Machieu, int.Parse(soluongmaghe[i]));
            //        insertghe(Machieu, int.Parse(soluongmaghe[i]));
            //    }

            //}
            //MessageBox.Show("thanh toan thanh cong !!!!!!!");
            frTHANHTOAN tt=new frTHANHTOAN();
            tt.Vexem = true;
            tt.Maphim = maphim;
            tt.Tong = tong;
            tt.Giave = giave;
            tt.Machieu = machieu;
            tt.Lbghe = lbghe.Text;
            tt.Lbmaghe=lbmaghe.Text;
            tt.Date = date;
            tt.Time = time;
            tt.Maphong = maphong;
           //MessageBox.Show(tt.Lbmaghe.ToString());
            tt.ShowDialog();
        }

        private void lbgiave_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbtong_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
