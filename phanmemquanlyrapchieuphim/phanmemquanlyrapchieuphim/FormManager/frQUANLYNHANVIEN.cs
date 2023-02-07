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
using webtnonline.Models;
using ComboBox = System.Windows.Forms.ComboBox;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYNHANVIEN : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string imgLocation = "";
        private byte[] hinhanh;
        bool them=false;
        bool sua = false;
        bool xoa = false;
        int id;
        public byte[] Hinhanh { get => hinhanh; set => hinhanh = value; }

        public frQUANLYNHANVIEN()
        {
            InitializeComponent();
            loaddsnhanvien();
            loadphanquyen();
            check(true);

        }
        void check(bool kt)
        {
            btnthem.Enabled = !kt;
            btnsua.Enabled = !kt;
            btnxoa.Enabled = !kt;
            btnluu.Enabled = !kt;
            btnhuy.Enabled = !kt;
        }
        void loaddsnhanvien()
        {
            gridControl1.DataSource = nhanvienDAO.Instance.loaddsnhanvien();
            gridView1.OptionsBehavior.Editable = false;
        }
        void loadphanquyen()
        {
            comboBox1.DataSource = db.phanquyens.ToList();
            comboBox1.DisplayMember = "Tenchucvu";
        }
        void insertnhanvien(string manhanvien,string hoten,string sdt,string email,DateTime ngaysinh,int chuvu, byte[] hinhanh)
        {
            db.usp_insertnhanvien(hoten, sdt, ngaysinh, chuvu, hinhanh, email,manhanvien);
        }
        void updatenhanvien(string manhanvien, string hoten, string sdt, string email, DateTime ngaysinh, int chuvu, byte[] hinhanh)
        {
            db.usp_updatenhanvien(hoten, sdt, ngaysinh, chuvu, hinhanh, email, manhanvien);
        }
        void deletenhanvien(string manhanvien)
        {

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoa = false;
            them = true;
            sua = false;
            check(true);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            groupControl1.Enabled = false;
            txtmanv.Text = " ";
            txthoten.Text = " ";
            txtsdt.Text = " ";
            txtemail.Text = " ";
            txtusername.Text = " ";
            txtmk.Text = " ";
            pictureBox1.Image = null;
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

        private void gridControl1_Click(object sender, EventArgs e)
        {
            groupControl1.Enabled = true;
            splitContainer1.Panel1.Enabled = true;
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            if(gridView1.GetFocusedRowCellValue("Manhanvien")!=null)
            {
                string manv = gridView1.GetFocusedRowCellValue("Manhanvien").ToString();
                nhanvien nv = nhanvienDAO.Instance.loaddetailnhanvien(manv);
                pictureBox1.Image = convertbytetoimage((byte[])nv.hinhanh.ToArray());
                txthoten.Text = nv.hoten;
                txtemail.Text = nv.Email;
                txtmanv.Text = nv.Manhanvien;
                txtsdt.Text = nv.sdt;
                dateTimePicker1.Value = (DateTime)nv.Ngaysinh;
                phanquyen pq = nhanvienDAO.Instance.loadpq(int.Parse(nv.Machucvu.ToString()));
                if(pq!=null)
                {
                    comboBox1.Text = pq.Tenchucvu;
                }
               
                try
                {
                    account ac = db.accounts.Where(x => x.Manhanvien == manv).SingleOrDefault();
                    if(ac!=null)
                    {
                        txtusername.Text = ac.Username;
                        txtmk.Text = ac.Password;
                    }
                  
                }catch
                {

                }
              

            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoa = true;
            them = false;
            sua = false;
            check(true);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoa = false;
            them = false;
            sua = true;
            check(true);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            if(them==true)
            {
                try
                {
                    Random r = new Random();
                    string HD = "NV";
                    hoadon hd = new hoadon();

                    string manv = crypt.Encrypt(HD.Trim() + r.Next().ToString(), true);
                    insertnhanvien(manv,txthoten.Text, txtsdt.Text, txtemail.Text, dateTimePicker1.Value, id, Hinhanh);
                    MessageBox.Show("thêm thành công");
                    loaddsnhanvien();
                }
                catch
                {
                    MessageBox.Show("thêm thất bại");
                }
            }else if(sua==true)
            {
                try
                {
                    
                    updatenhanvien(txtmanv.Text, txthoten.Text, txtsdt.Text, txtemail.Text, dateTimePicker1.Value, id, Hinhanh);
                    MessageBox.Show("Sửa thành công");
                    loaddsnhanvien();
                }
                catch
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else if(xoa==true)
            {
                try
                {

                    if(nhanvienDAO.Instance.deletenhanvien(txtmanv.Text))
                    {
                        MessageBox.Show("Xóa thành công");
                        loaddsnhanvien();
                    }
                   
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phanquyen selected = cb.SelectedItem as phanquyen;
            id = selected.Machucvu;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(AccountDAO.Instance.insertaccout(txtusername.Text,txtmk.Text,txtmanv.Text))
                {
                    MessageBox.Show("Tạo thành công");
                    loaddsnhanvien();
                }
            }catch
            {
                MessageBox.Show("Tạo thất bại");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountDAO.Instance.updateaccout(txtusername.Text, txtmk.Text))
                {
                    MessageBox.Show("Sửa thành công");
                    loaddsnhanvien();
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountDAO.Instance.deleteaccout(txtusername.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddsnhanvien();
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}