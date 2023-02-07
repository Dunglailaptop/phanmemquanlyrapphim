using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static phanmemquanlyrapchieuphim.FormStaff.frDATDOAN;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class Us_HDFOOD : DevExpress.XtraEditors.XtraUserControl
    {
        
        public Us_HDFOOD(frDATDOAN fr)
        {
            InitializeComponent();
            //panel2.BackColor = Color.FromArgb(0, Color.Black);
        }
        //public Us_HDFOOD(frDATDOAN fr)
        //{
        //    InitializeComponent();

        //}
        public Us_HDFOOD()
        {
            InitializeComponent();
            //panel2.BackColor = Color.FromArgb(0, Color.Black);
        }
        private int masp;
        private Image hinhanh;
        private string tendoanl;
        private decimal gia;
        private decimal tong;
        private decimal tong2;
        private int soluong2;
        private int soluong=0;
        private int soluongdau;
        public decimal Gia {
            get {return gia; }
            set { gia = value; lbgia.Text = Convert.ToString(value);labelControl1.Text = String.Format("{0:0,0 vnd}",value); } 
        }
      
        public string Tendoanl
        {
            get { return tendoanl; }
            set { tendoanl = value;LBTEN.Text = value; } 
        }
        public Image Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value;pictureBox1.Image = value; } 
        }

        public decimal Tong { get => tong; set => tong = value; }
        public decimal Tong2 { get => tong2; set => tong2 = value; }
       
        public int Soluong2 { get => soluong2; set => soluong2 = value; }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value;lbsoluong.Text =Convert.ToString(value); } 
        }

        public int Soluongdau { get => soluongdau; set => soluongdau = value; }
        public int Masp { get => masp; set => masp = value; }

        //public int Soluong1 { get => soluong; set => soluong = value; }

        public delegate void updatedelegate(object sender, UpdateEventArgs args);
        public event updatedelegate updateventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            updateventHandler.Invoke(this, args);
        }
        private void Us_HDFOOD_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frDATDOAN d = new frDATDOAN();
            d.Giagiam = gia;
             tong2 = tong - gia;
            //d.Tongnew = tong2;
            //d.gidagiam();
            //d.Show();
            //MessageBox.Show(tong2.ToString());
            //d.remove(tong2);
            this.Controls.Clear();
            this.Dispose();
        }

        private void lbgia_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        //public int getsoluong()
        //{
        //    return soluong;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            /*  DES handler =*/
            int dem = 0;
            // Call the delegate.
            //handler("Hello World");
            if (soluong2==Soluong)
            {
                MessageBox.Show("Đã hết sản phẩm trong kho");
            }
            else
            {
                Soluong++;
                lbsoluong.Text = Soluong.ToString();
                dem++;

                //frDATDOAN frDATDOAN = new frDATDOAN();
                //XaiChung xaichung = new XaiChung();
                //xaichung.C = soluong;
                //frDATDOAN.Soluongg = soluong;
                //frDATDOAN.Show();
            }
            //frDATDOAN.soluong();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Soluong==1)
            {
                MessageBox.Show("Tối đa là 1 sản phẩm");
            }
            else if(Soluong>1)
            {
                Soluong--;
                lbsoluong.Text = Soluong.ToString();
            }
         
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
