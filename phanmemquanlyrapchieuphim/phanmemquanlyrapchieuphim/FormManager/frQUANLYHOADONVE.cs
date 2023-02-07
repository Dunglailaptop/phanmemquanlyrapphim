using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.Report;
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
    public partial class frQUANLYHOADONVE : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frQUANLYHOADONVE()
        {
            InitializeComponent();
            try
            {
                dshoadon(dateTimePicker1.Value);
            }catch
            {

            }
        }
        void dshoadon(DateTime date)
        {
            gridControl1.DataSource = HoaDonDAO.Instance.dshoadonvexem(date);
            gridView1.OptionsBehavior.Editable=false;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue("Mahoadon")!=null)
            {
                simpleButton1.Enabled = true;
                string mahd = gridView1.GetFocusedRowCellValue("Mahoadon").ToString();
                hoadon HD = db.hoadons.Where(x => x.Mahoadon == mahd).First();
                textEdit1.Text = HD.Mahoadon;
                textEdit2.Text = gridView1.GetFocusedRowCellValue("Ngaynhap_name").ToString();
                textEdit2.Tag = gridView1.GetFocusedRowCellValue("ngaychieushow").ToString();
                textEdit3.Text = HD.soluongve.ToString();
                textEdit4.Text =String.Format("{0:0,0 vnd}", HD.tongtien);
                textEdit5.Text = gridView1.GetFocusedRowCellValue("tenphim").ToString();
                textEdit5.Tag = HD.maphim;
                if (gridView1.GetFocusedRowCellValue("Maphong").ToString() != null)
                {
                    int map = (int)gridView1.GetFocusedRowCellValue("Maphong");
                    textEdit6.Text = map.ToString();
                    textEdit6.Tag = gridView1.GetFocusedRowCellValue("thoigianchieu").ToString();
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                RP_HOADON report = new RP_HOADON();
            //ReportPrintTool printTool = new ReportPrintTool(report);
            //printTool.ShowPreview();
            /*  report.PrintDialog()*/
            string time = textEdit6.Tag.ToString();
            string date = textEdit2.Tag.ToString();
            int maphim = int.Parse(textEdit5.Tag.ToString());
            int maphong = int.Parse(textEdit6.Text);
                DataClasses1DataContext db = new DataClasses1DataContext();
                report.DataSource = db.USP_INHOADON(textEdit1.Text, time, date, maphim,maphong);
                report.CreateDocument();
                report.ShowPreview();
            }
            catch
            {
                MessageBox.Show("không có dữ liệu");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dshoadon(dateTimePicker1.Value);
        }
    }
}