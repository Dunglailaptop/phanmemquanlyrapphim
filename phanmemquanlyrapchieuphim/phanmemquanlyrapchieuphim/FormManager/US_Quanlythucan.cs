using phanmemquanlyrapchieuphim.DTO;
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

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class US_Quanlythucan : DevExpress.XtraEditors.XtraUserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public US_Quanlythucan()
        {
            InitializeComponent();
        }
        private Byte[] hinhanh;
        private string tendanhmuc;
        private int soluong;
        private decimal gia;
        private int madanhmuc;
        private int masp;
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        public byte[] Hinhanh {
            get { return hinhanh; }
            set { hinhanh = value; pictureBox1.Image = convertbytetoimage(value); } 
        }
        public string Tendanhmuc
        {
            get { return tendanhmuc; }
            set { tendanhmuc = value;lbten.Text = value; } 
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value;lbsl.Text =Convert.ToString(value); } 
        }
        public decimal Gia
        {
            get { return gia; }
            set { gia = value;lbtien.Text = Convert.ToString(value +"VND"); } 
        }

        public int Madanhmuc {
            get { return madanhmuc; }
            set { madanhmuc = value; lbdanhmuc.Text = Convert.ToString(value); } 
        }

        public int Masp { get => masp; set => masp = value; }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.Gray;
        }

        private void US_Quanlythucan_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.Gray;
        }

        private void US_Quanlythucan_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.White;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.White;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            //frXEMCHITIETTHUCAN ta = new frXEMCHITIETTHUCAN();
            //ta.Tensanpham = tendanhmuc;
            //ta.Hinhanh = convertbytetoimage(hinhanh);
            //ta.Madm = madanhmuc;
            //ta.Soluong = soluong;
            //ta.Gia = gia;
            //ta.Masp = masp;
            //ta.ShowDialog();
            //frQUANLYTHUCAN fr = new frQUANLYTHUCAN();
            //fr.loadlistsanpham();
        }

        private void US_Quanlythucan_Load(object sender, EventArgs e)
        {

        }
    }
}
