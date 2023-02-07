using phanmemquanlyrapchieuphim.DAO;
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
    public partial class frTHEMSANPHAM : DevExpress.XtraEditors.XtraForm
    {
        public frTHEMSANPHAM()
        {
            InitializeComponent();
            loaddanhmuc();
        }
        string imgLocation = "";
        int idmadanhmuc = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }
        public delegate void updatedelegate(object sender, UpdateEventArgs args);
        public event updatedelegate updateventHandler;
        public class UpdateEventArgs : EventArgs
            {
            public string data { get; set; }
            }

        void loaddanhmuc()
        {
            cbdanhmuc.DataSource = SanPhamDAO.Instance.showlistdanhmuc();
            cbdanhmuc.DisplayMember = "tendanhmuc";
        }
        //public byte[] convertimagetobye()
        //{
        //    byte[] images = null;
        //    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(stream);
        //    images = br.ReadBytes((int)stream.Length);
        //    return images;
        //}
        //void insertsanpham(string tensanpham, int madanhmuc, decimal gia, int soluong, byte[] hinhanh)
        //{
            
        //    SanPhamDAO.Instance.insertsanpham(tensanpham, madanhmuc, gia, soluong, hinhanh);
        //}
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(stream);
            images = br.ReadBytes((int)stream.Length);

            SanPhamDAO.Instance.insertsanpham(txtten.Text, idmadanhmuc, Convert.ToDecimal(txtgia.Text), Convert.ToInt32(txtsoluong.Text), images);
            //if (==false)
            //{
                MessageBox.Show("Tạo thành công sản phẩm");
                this.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("Tạo sản phẩm thất bại");
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            danhmucsp selected = cb.SelectedItem as danhmucsp;
            idmadanhmuc = selected.Madm;
        }

        private void frTHEMSANPHAM_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            frQUANLYTHUCAN F = new frQUANLYTHUCAN();
            F.loadlistsanpham();
            //mn.MdiParent = this;
            //mn.Show();
            

        }
    }
}
