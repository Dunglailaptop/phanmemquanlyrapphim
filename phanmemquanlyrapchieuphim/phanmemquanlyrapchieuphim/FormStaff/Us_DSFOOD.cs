using phanmemquanlyrapchieuphim.DTO;
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
    public partial class Us_DSFOOD : DevExpress.XtraEditors.XtraUserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Us_DSFOOD()
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
        public byte[] Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; pictureBox1.Image = convertbytetoimage(value); }
        }
        public string Tendanhmuc
        {
            get { return tendanhmuc; }
            set { tendanhmuc = value; lbten.Text = value; }
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; lbsl.Text = Convert.ToString(value); }
        }
        public decimal Gia
        {
            get { return gia; }
            set { gia = value; lbtien.Text = Convert.ToString(value /*+ "VND"*/);label1.Text = String.Format("{0:0,0 vnd}", value); }
        }

        public int Madanhmuc
        {
            get { return madanhmuc; }
            set { madanhmuc = value; lbdanhmuc.Text = Convert.ToString(value); }
        }

        public int Masp { get => masp; set => masp = value; }
        private void Us_DSFOOD_Load(object sender, EventArgs e)
        {

        }

        private void Us_DSFOOD_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            lbten.Enabled = false;
            label2.Enabled = false;
            lbsl.Enabled = false;
            lbtien.Enabled = false;
        }

        private void Us_DSFOOD_Leave(object sender, EventArgs e)
        {
            
        }

        private void Us_DSFOOD_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lbten.Enabled = true;
            label2.Enabled =true;
            lbsl.Enabled = true;
            lbtien.Enabled = true;
        }

        private void Us_DSFOOD_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void lbtien_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
