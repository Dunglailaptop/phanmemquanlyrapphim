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

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYKHUYENMAI : DevExpress.XtraEditors.XtraForm
    {
        bool themvc;
        bool xoavc;
        bool suavc;
        public frQUANLYKHUYENMAI()
        {
            InitializeComponent();
            giamgia();
            loadvoucher();
           
            check(true);
            btnthem.Enabled = true;
        }
        void giamgia()
        {
            for (int i = 0; i <= 100; i++)
            {
                cbgiamgia.Items.Add(i +" %"+ "\n");
            }
        }
        void check(bool kt)
        {
            btnthem.Enabled = !kt;
            btnxoa.Enabled = !kt;
            btnsua.Enabled = !kt;
            btnluu.Enabled = !kt;
            btnhuy.Enabled = !kt;
        }
        void loadvoucher()
        {
            gridControl1.DataSource = voucherDAO.Instance.loadvoucher();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            check(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            if(gridView1.GetFocusedRowCellValue("Makm").ToString()!=null)
            {
                string makm = gridView1.GetFocusedRowCellValue("Makm").ToString();
               voucher vc=voucherDAO.Instance.loadvoucherbyid(makm);
                txtnoidung.Text = vc.tenkm;
                cbgiamgia.Text = vc.giagiam;
                datedau.Value =Convert.ToDateTime(vc.ngaydau);
                datecuoi.Value = Convert.ToDateTime(vc.ngaycuoi);
                txtsoluong.Text = vc.soluong.ToString();
                mavoucher.Text = vc.Makm.ToString();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themvc = true;
            suavc = false;
            xoavc = false;
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themvc = false;
            suavc = false;
            xoavc = true;
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themvc = false;
            suavc = true;
            xoavc = false;
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(themvc==true)
            {
                try
                {
                    if (voucherDAO.Instance.insertvoucher(txtnoidung.Text,cbgiamgia.Text,datedau.Value,datecuoi.Value,int.Parse(txtsoluong.Text),0))
                    {
                        MessageBox.Show("thêm voucher thành công");
                        giamgia();
                        loadvoucher();
                    }
                }
                catch
                {
                    MessageBox.Show("thêm voucher thất bại");
                }
            }
            else if(xoavc==true)
            {
                try
                {
                    if (voucherDAO.Instance.deletevoucher(mavoucher.Text))
                    {
                        MessageBox.Show("Xóa voucher thành công");
                        giamgia();
                        loadvoucher();
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa voucher thất bại");
                }
            }
            else if(suavc==true)
            {
                try
                {
                    if (voucherDAO.Instance.updatevoucher(mavoucher.Text,txtnoidung.Text, cbgiamgia.Text, datedau.Value, datecuoi.Value, int.Parse(txtsoluong.Text)))
                    {
                        MessageBox.Show("sửa voucher thành công");
                        giamgia();
                        loadvoucher();
                    }
                }
                catch
                {
                    MessageBox.Show("sửa voucher thất bại");
                }
            }
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(false);
            //btnluu.Enabled = true;
            //btnhuy.Enabled = true;
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }
    }
}