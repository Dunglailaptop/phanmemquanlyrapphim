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
    public partial class frQUANLYHOADONFOOD : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frQUANLYHOADONFOOD()
        {
            InitializeComponent();
            loaddshoadonfood(dateTimePicker1.Value);
        }
        void loaddshoadonfood(DateTime date)
        {
            gridControl1.DataSource = HoaDonDAO.Instance.dshoadonfood(date);
            gridView1.OptionsBehavior.Editable = false; 
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue("Mahoadon")!=null)
            {
                simpleButton1.Enabled = true;
                string mahd = gridView1.GetFocusedRowCellValue("Mahoadon").ToString();
                hoadonsanpham hdsp = db.hoadonsanphams.Where(x => x.Mahoadon == mahd).Single();
                textEdit1.Text = hdsp.Mahoadon;
                textEdit2.Text = gridView1.GetFocusedRowCellValue("Ngaytao").ToString();
                textEdit3.Text = hdsp.soluong.ToString();
                textEdit4.Text = String.Format("{0:0,0 vnd}", hdsp.giatien);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loaddshoadonfood(dateTimePicker1.Value);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                rp_HOADONFOOD report = new rp_HOADONFOOD();
                //ReportPrintTool printTool = new ReportPrintTool(report);
                //printTool.ShowPreview();
                /*  report.PrintDialog()*/
                DataClasses1DataContext db = new DataClasses1DataContext();
                report.DataSource = HoaDonDAO.Instance.inhoadonfood(textEdit1.Text);
                report.CreateDocument();
                report.ShowPreview();
            }
            catch
            {

            }
        
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}