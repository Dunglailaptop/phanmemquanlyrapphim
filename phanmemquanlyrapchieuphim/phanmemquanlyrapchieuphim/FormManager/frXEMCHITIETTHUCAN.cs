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
    public partial class frXEMCHITIETTHUCAN : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frXEMCHITIETTHUCAN(frQUANLYTHUCAN fr)
        {
            InitializeComponent();
            loaddanhmuc();
            //tendanhmuc();
        }

        //public frXEMCHITIETTHUCAN(frQUANLYTHUCAN frQUANLYTHUCAN)
        //{
        //    FrQUANLYTHUCAN = frQUANLYTHUCAN;
        //}

        private string tensanpham;
        private byte[] hinhanh;
        private int soluong;
        private decimal gia;
        private string loaisp;
        private int madm;
        private int masp;
        string imgLocation = "";
        int iddanhmuc = 0;
        public string Tensanpham {
            get {return tensanpham; }
            set { tensanpham = value; txtten.Text = value; } 
        }
        public Byte[] Hinhanh {
            get { return hinhanh; }
            set { hinhanh = value; pictureBox1.Image =convertbytetoimage(value); } 
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value;txtsoluong.Text =Convert.ToString(value); } 
        }
        public decimal Gia
        {
            get { return gia; }
            set { gia = value;txtgia.Text =Convert.ToString(value); } 
        }
        public string Loaisp
        {
            get { return loaisp; }
            set { loaisp = value; cbdanhmuc.Text= value; }
        }

        public int Madm {
            get { return madm; }
            set { madm = value; cbdanhmuc.Text =SanPhamDAO.Instance.showdm(value).ToString(); } 
        }
        public delegate void updatedelegate(object sender, UpdateEventArgs args);
        public event updatedelegate updateventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string data { get; set; }
        }
        public int Masp { get => masp; set => masp = value; }
        //public frQUANLYTHUCAN FrQUANLYTHUCAN { get; }
        protected void insert()
        {
            UpdateEventArgs args=new UpdateEventArgs();
            updateventHandler.Invoke(this, args);
        }
        void loaddanhmuc()
        {
            cbdanhmuc.DataSource = SanPhamDAO.Instance.showlistdanhmuc();
            cbdanhmuc.DisplayMember = "tendanhmuc";
        }
        //public void tendanhmuc()
        //{
        //    danhmucsp dm = new danhmucsp();
        //    dm = SanPhamDAO.Instance.showdm(madm);
        //    loaisp = dm.tendanhmuc;

        //}

        private void frXEMCHITIETTHUCAN_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                if(imgLocation != null)
                {
                    
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    hinhanh = br.ReadBytes((int)stream.Length);
                }
            }
        }

        private void cbdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            danhmucsp selected = cb.SelectedItem as danhmucsp;
            iddanhmuc = selected.Madm;
        }
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image != null)
            //{
                
            //    SanPhamDAO.Instance.updatesanpham(txtten.Text, iddanhmuc, gia, Soluong, Hinhanh, Masp);
            //    MessageBox.Show("Sửa thành công!!!");
            //    this.Dispose();
            //    insert();
            //}
            // if(pictureBox1.Image!=null)
            //{
                SanPhamDAO.Instance.updatesanpham(txtten.Text, iddanhmuc, gia, Soluong, Hinhanh, Masp);
                MessageBox.Show("Sửa thành công!!!");
                this.Dispose();
                insert();


            //}
            //if (imgLocation == null && pictureBox1.Image != null)
            //{
            
                //SanPhamDAO.Instance.updatesanpham(txtten.Text, iddanhmuc, gia, Soluong, images, Masp);
                //MessageBox.Show("Sửa thành công");
                //this.Dispose();
                //insert();

            //}
            //this.Dispose();
            //insert();

            //this.Dispose();
            //insert();
            //new frQUANLYTHUCAN().loadlistsanpham();
        }
        //public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, imageIn.RawFormat);
        //        return ms.ToArray();
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            if(SanPhamDAO.Instance.delete(Masp))
            {
                MessageBox.Show("Xóa thành công");
                this.Dispose();
                insert();
            }
            else
            {
                MessageBox.Show("xóa thất bại");
            }

        }
    }
}
