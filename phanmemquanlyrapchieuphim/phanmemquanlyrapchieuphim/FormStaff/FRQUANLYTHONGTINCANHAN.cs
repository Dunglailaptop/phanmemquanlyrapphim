using DevExpress.XtraEditors;
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

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class FRQUANLYTHONGTINCANHAN : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string imgLocation = " ";
        private byte[] hinhanh;

        public byte[] Hinhanh { get => hinhanh; set => hinhanh = value; }

        public FRQUANLYTHONGTINCANHAN(string manv)
        {
            InitializeComponent();
            try
            {
                loadthongtin(manv);
            }catch
            {

            }
        }
        public Image convertbytetoimage(Byte[] data)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex);
                return null;

            }

        }
        void loadthongtin(string manv)
        {
            nhanvien nv = nhanvienDAO.Instance.loaddetailnhanvien(manv);
            Manhanvien.Text = nv.Manhanvien;
            hoten.Text = nv.hoten;
            email.Text = nv.Email;
            sdt.Text = nv.sdt;
            phanquyen pq = db.phanquyens.Where(x => x.Machucvu == nv.Machucvu).Single();
            chucvu.Text =pq.Tenchucvu;
            chucvu.Tag = pq.Machucvu;
            ngaysinh.Value = (DateTime)nv.Ngaysinh;
            pictureBox1.Image = convertbytetoimage(nv.hinhanh.ToArray());
            hinhanh = (byte[])nv.hinhanh.ToArray();
        }
        private void FRQUANLYTHONGTINCANHAN_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                if (imgLocation != null)
                {

                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    Hinhanh = br.ReadBytes((int)stream.Length);
                }
            }
        }
        void updatenhanvien(string manhanvien, string hoten, string sdt, string email, DateTime ngaysinh, int chuvu, byte[] hinhanh)
        {
            db.usp_updatenhanvien(hoten, sdt, ngaysinh, chuvu, hinhanh, email, manhanvien);
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                updatenhanvien(Manhanvien.Text, hoten.Text, sdt.Text, email.Text, ngaysinh.Value, int.Parse(chucvu.Tag.ToString()), hinhanh);
                MessageBox.Show("cập nhật thành công");
            }
            catch
            {
                MessageBox.Show("cập nhật thất bại");
            }
            
        }
    }
}