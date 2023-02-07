using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;
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
using ComboBox = System.Windows.Forms.ComboBox;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYFOOD : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string imgLocation = "";
        bool themsp;
        bool xoasp;
        bool suasp;
        int idmadm=0;
        public frQUANLYFOOD()
        {
            InitializeComponent();
            loaddanhmuc();
            check(true);
        }
        private Byte[] Hinhanh1;

        public byte[] Hinhanh11 {
            get {return Hinhanh1; } 
            set => Hinhanh1 = value;
        }

        //public byte[] Hinhanh1 { get => Hinhanh; set => Hinhanh = value; }

        void loaddanhmuc()
        {
            gridControl1.DataSource = SanPhamDAO.Instance.showlistdanhmuc();
            gridView1.OptionsBehavior.Editable = false;
        }
        void loadcbdanhmuc()
        {
            cbphanloai.DataSource = SanPhamDAO.Instance.showlistdanhmuc();
            cbphanloai.DisplayMember = "tendanhmuc";
        }
        void seach(int madm)
        {
            gridControl2.DataSource = SanPhamDAO.Instance.listspbydanhmuc(madm);
            gridView2.OptionsBehavior.Editable = false;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ktdanhmuc(true);
          if(pnltaodmmoi.Visible == false)
            {
                pnltaodmmoi.Visible = true;
            }else if(pnltaodmmoi.Visible==true)
            {
                pnltaodmmoi.Visible = false;
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            loadcbdanhmuc();
            check(false);
            btnhuysp.Enabled = false;
            btnluusp.Enabled = false;
            panelControl1.Visible = true;
            if(gridView2.GetFocusedRowCellValue("machieu")!=null)
            {
                int masp = (int)gridView2.GetFocusedRowCellValue("machieu");
                try
                {
                    Class CL = new Class(); 
                        CL= SanPhamDAO.Instance.showmotsanpham(masp);
                    txtmasp.Text = CL.machieu.ToString();
                    txtensanpham.Text = CL.tenfood;
                    txtgiasanpham.Text = String.Format("{0:0,0 VND}", CL.giave);
                    txtsoluong.Text = CL.soluongfood.ToString();
                    cbphanloai.Text = CL.tenloai;
                    pictureBox1.Image = convertbytetoimage(CL.picture);
                    Hinhanh1 = CL.picture;


                }
                catch
                {
                    MessageBox.Show("không có dữ liệu");
                }
            }
         
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            ktdanhmuc(false);
            pnltaodmmoi.Visible = true;
            //btnthemdm.Enabled = false;
            if (gridView1.GetFocusedRowCellValue("Madm") != null)
            {
                int madm = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Madm"));
                seach(madm);
                if(gridView1.GetFocusedRowCellValue("tendanhmuc")!=null)
                {
                    txttendm.Text = gridView1.GetFocusedRowCellValue("tendanhmuc").ToString();
                }
               
            }
            else
            {
                MessageBox.Show("dữ liệu rỗng");
            }
        }
        void ktdanhmuc(bool kt)
        {
            btnxoadm.Enabled =!kt;
            btnsuadm.Enabled =!kt;

        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ktdanhmuc(true);
            txttendm.Text = " ";
            if(txttendm.Text!=" ")
            {
                try
                {
                    if (danhmucspDAO.Instance.insertdanhmuc(txttendm.Text))
                    {
                        MessageBox.Show("Thêm thành công danh mục sản phẩm mới");
                        loaddanhmuc();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi không thêm được");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thêm được");
                }
            }else
            {
                MessageBox.Show("vui lòng nhập thông tin danh mục");
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
        private void btnsuadm_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Madm") != null)
            {
                int madm = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Madm"));
                seach(madm);
                if (gridView1.GetFocusedRowCellValue("tendanhmuc") != null)
                {
                    //txttendm.Text = gridView1.GetFocusedRowCellValue("tendanhmuc").ToString();
                    if (danhmucspDAO.Instance.updatedanhmuc(txttendm.Text, madm))
                    {
                        MessageBox.Show("Sửa danh mục thành công");
                        loaddanhmuc();
                    }
                }

            }
            else
            {
                MessageBox.Show("dữ liệu rỗng");
            }
        }

        private void btnxoadm_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Madm") != null)
            {
                int madm = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Madm"));
                seach(madm);
                if (gridView1.GetFocusedRowCellValue("tendanhmuc") != null)
                {
                    txttendm.Text = gridView1.GetFocusedRowCellValue("tendanhmuc").ToString();
                    if (danhmucspDAO.Instance.deletedanhmuc(madm))
                    {
                        MessageBox.Show("Xóa danh mục thành công");
                        loaddanhmuc();
                    }
                }

            }
            else
            {
                MessageBox.Show("dữ liệu rỗng");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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
                    Hinhanh1 = br.ReadBytes((int)stream.Length);
                }
            }
        }
        void check(bool kt)
        {
            btnthemsp.Enabled = !kt;
            btnsuasp.Enabled = !kt;
            btnxoasp.Enabled = !kt;
            btnhuysp.Enabled = !kt;
            btnluusp.Enabled = !kt;
        }
        private void btnthemsp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            txtensanpham.Text = " ";
            txtgiasanpham.Text = " ";
            txtsoluong.Text = " ";
            pictureBox1.Image = null;
            btnhuysp.Enabled = true;
            btnluusp.Enabled = true;
            themsp = true;
            suasp = false;
            xoasp = false;
        }

        private void btnxoasp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            btnhuysp.Enabled = true;
            btnluusp.Enabled = true;
            xoasp = true;
            themsp = false;
            suasp=false;
        }

        private void btnsuasp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            btnhuysp.Enabled = true;
            btnluusp.Enabled = true;
            suasp = true;
            themsp=false;
            xoasp=false;
        }

        private void btnhuysp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuysp.Enabled = false;
            btnluusp.Enabled = false;

        }

        private void btnluusp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuysp.Enabled = false;
            btnluusp.Enabled = false;
            if(themsp==true)
            {
                try
                {
                    if (SanPhamDAO.Instance.insertsanpham(txtensanpham.Text, idmadm, decimal.Parse(txtgiasanpham.Text), int.Parse(txtsoluong.Text), Hinhanh1))
                    {
                        
                        seach(idmadm);
                    }
                    //else
                    //{
                    //    MessageBox.Show("loi");
                    //}
                    MessageBox.Show("thêm sản phẩm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi");
                }
                
            }else if(xoasp==true)
            {
                try
                {
                    if (SanPhamDAO.Instance.delete(int.Parse(txtmasp.Text)))
                    {

                        seach(idmadm);
                    }
                    //else
                    //{
                    //    MessageBox.Show("loi");
                    //}
                    MessageBox.Show("Xóa sản phẩm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi");
                }
            }
            else if(suasp==true)
            {
                try
                {
                    string[] tach = txtgiasanpham.Text.Split(' ');
                    decimal giatien = decimal.Parse(tach[0]);
                int solg = int.Parse(txtsoluong.Text);
                int masp = int.Parse(txtmasp.Text);
                    if (SanPhamDAO.Instance.updatesanpham(txtensanpham.Text.ToString(), idmadm,giatien ,solg ,Hinhanh1,masp))
                    {

                        seach(idmadm);
                    }
                    //else
                    //{
                    //    MessageBox.Show("loi");
                    //}
                    MessageBox.Show("Sửa sản phẩm thành công");
                    seach(idmadm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi");
                }
            }
        }

        private void cbphanloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            danhmucsp selected = cb.SelectedItem as danhmucsp;
            idmadm = selected.Madm;
        }
    }
}