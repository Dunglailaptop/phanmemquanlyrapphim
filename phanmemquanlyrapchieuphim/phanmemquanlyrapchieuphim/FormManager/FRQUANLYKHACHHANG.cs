using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
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
using webtnonline.Models;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class FRQUANLYKHACHHANG : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        bool them = false;
        bool sua = false;
        bool xoa = false;
        
        public FRQUANLYKHACHHANG()
        {
            InitializeComponent();
            check(true);
            loadkhachhang();
        }
        void check(bool kt)
        {
            btnthem.Enabled = !kt;
            btnxoa.Enabled = !kt;
            btnsua.Enabled = !kt;
            btnluu.Enabled = !kt;
            btnhuy.Enabled = !kt;
        }
        void loadkhachhang()
        {
            try
            {
                gridControl1.DataSource = khachhangDAO.Instance.loadkhachhang();
                gridView1.OptionsBehavior.Editable = false;
            }
            catch
            {

            }
         
        }
        
        private void gridControl1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Enabled = true;
            check(false);
            btnhuy.Enabled=false;
            btnluu.Enabled = false;
            if(gridView1.GetFocusedRowCellValue("Makh")!=null)
            {
                string makh = gridView1.GetFocusedRowCellValue("Makh").ToString();
                khachhang kh = db.khachhangs.Where(x => x.Makh == makh).FirstOrDefault();
                textEdit1.Text = kh.Makh;
                textEdit2.Text = kh.hoten;
                textEdit3.Text = kh.email;
                textEdit4.Text = kh.sdt;
                textEdit5.Text = kh.diem.ToString();
            }
            else
            {
                MessageBox.Show("rỗng");
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            them = true;
            sua = false;
            xoa = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit4.Text = " ";
            textEdit5.Text = " ";
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            them = false;
            sua = true;
            xoa = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            them = false;
            sua = false;
            xoa = true;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            if (them==true)
            {
                try
                {
                    Random r = new Random();
                    string HD = "KH";
                    hoadon hd = new hoadon();

                    string mahoadon = crypt.Encrypt(HD.Trim() + r.Next().ToString(), true);
                    if (khachhangDAO.Instance.insertkh(mahoadon,textEdit2.Text,textEdit3.Text,textEdit4.Text,10))
                    {
                        MessageBox.Show("thêm khách hàng thành công");
                        loadkhachhang();
                    }
                }catch
                {
                    MessageBox.Show("thêm khách hàng thất bại");
                }
            }else if(xoa==true)
            {
                try
                {
                    if (khachhangDAO.Instance.deletekh(textEdit1.Text))
                    {
                        MessageBox.Show("xóa khách hàng thành công");
                        loadkhachhang();
                    }
                }
                catch
                {
                    MessageBox.Show("xóa khách hàng thất bại");
                }

            }
            else if(sua==true)
            {
                try
                {
                    if (khachhangDAO.Instance.updatekh(textEdit1.Text, textEdit2.Text, textEdit3.Text, textEdit4.Text))
                    {
                        MessageBox.Show("sửa khách hàng thành công");
                        loadkhachhang();
                    }
                }
                catch
                {
                    MessageBox.Show("sửa khách hàng thất bại");
                }
            }
           
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
        }
    }
}