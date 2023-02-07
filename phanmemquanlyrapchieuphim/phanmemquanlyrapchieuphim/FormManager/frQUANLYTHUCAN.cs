using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.DAO;
using System.IO;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYTHUCAN : DevExpress.XtraEditors.XtraForm
    {
        public frQUANLYTHUCAN()
        {
            InitializeComponent();
            loadlistsanpham();
            loaddanhmuc();
           
        }
        int idmadanhmuc = 0;
        //void loadusercontrol()
        //{
        //    US_Quanlythucan us;
        //    int x = 200,y =200;
        //    for(int i = 0; i < 20; i++)
        //    {
        //        us=new US_Quanlythucan();
        //        us.Location = new Point(x, y);
        //        flowLayoutPanel1.Controls.Add(us);
            
        //    }
        //}
        private void F2_updateEventHandler(object sender,frXEMCHITIETTHUCAN.UpdateEventArgs args)
        {
            loadlistsanpham();
        }
        //public Image convertbytetoimage(byte[] data)
        //{
        //    using (MemoryStream ms = new MemoryStream(data))
        //    {
        //        return Image.FromStream(ms);
        //    }
        //}
        public void loadlistsanpham()
        {
            flowLayoutPanel1.Controls.Clear();
            List<sanpham> sp = new List<sanpham>();
            sp = SanPhamDAO.Instance.showlistsanpham();
            US_Quanlythucan ta;
            foreach(sanpham s in sp)
            {
                ta = new US_Quanlythucan();
                ta.Tendanhmuc = s.Tensanpham;
                ta.Soluong = (int)s.soluong;
                ta.Gia = (decimal)s.Gia;
                ta.Madanhmuc = (int)s.Madanhmuc;
                ta.Masp = s.Masp;
                ta.Hinhanh = (Byte[])s.hinhanh.ToArray();
                flowLayoutPanel1.Controls.Add(ta);
                ta.Click += new System.EventHandler(this.btn_click);
            }
        }
        public void seachsanpham(int madm)
        {
            flowLayoutPanel1.Controls.Clear();
            List<sanpham> sp = new List<sanpham>();
            sp = SanPhamDAO.Instance.sreach(madm);
            US_Quanlythucan ta;
            foreach (sanpham s in sp)
            {
                ta = new US_Quanlythucan();
                ta.Tendanhmuc = s.Tensanpham;
                ta.Soluong = (int)s.soluong;
                ta.Gia = (decimal)s.Gia;
                ta.Madanhmuc = (int)s.Madanhmuc;
                ta.Masp = s.Masp;
                ta.Hinhanh = (Byte[])s.hinhanh.ToArray();
                flowLayoutPanel1.Controls.Add(ta);
                ta.Click += new System.EventHandler(this.btn_click);
            }
        }
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            //loadlistsanpham();
            US_Quanlythucan TA = (US_Quanlythucan)sender;
            
            frXEMCHITIETTHUCAN fr = new frXEMCHITIETTHUCAN(this);

            fr.Masp = TA.Masp;
            fr.Madm = TA.Madanhmuc;
            fr.Tensanpham = TA.Tendanhmuc;
            fr.Hinhanh = TA.Hinhanh;
            fr.Soluong = TA.Soluong;
            fr.Gia = TA.Gia;
            fr.updateventHandler += F2_updateEventHandler;
            fr.ShowDialog();
            
        }
        void loaddanhmuc()
        {
            //cbdanhmuc.SelectedIndex = 1;
            //cbdanhmuc.;
            cbdanhmuc.DataSource = SanPhamDAO.Instance.showlistdanhmuc();
            cbdanhmuc.DisplayMember = "tendanhmuc";
            //cbdanhmuc.Items.Add("Tất cả");
            
        }
        private void panel2_MouseHover(object sender, EventArgs e)
        {
           
            
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frQUANLYTHUCAN_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             new frTHEMSANPHAM().ShowDialog();
            loadlistsanpham();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //loadlistsanpham();
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = sender as ComboBox;
            
            if (cb.SelectedItem == null)
                return;

            danhmucsp selected = cb.SelectedItem as danhmucsp;
            idmadanhmuc = selected.Madm;
            if (idmadanhmuc == 8)
            {
                loadlistsanpham();
            }
            else if (idmadanhmuc != 8)
            {
                seachsanpham(idmadanhmuc);
            }
        }

        private void cbdanhmuc_MouseClick(object sender, MouseEventArgs e)
        {
                     
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
