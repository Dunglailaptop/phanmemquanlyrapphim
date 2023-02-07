using DevExpress.XtraEditors;
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
    public partial class frCHITIETDANHMUC : DevExpress.XtraEditors.XtraForm
    {
        public frCHITIETDANHMUC()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            /*dlg.ShowDialog();*/ //Hiển thị hộp thoại

            //if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            //{
            //    int mm = dlg.Color.ToArgb(); //Khai báo biến str
            //    txtmausac.Text = Convert.ToString(mm);

            //    /* str = dlg.Color.Name;*/ //Trả lại tên của màu đã lựa chọn
            //    txtmausac.BackColor = Color.FromArgb(mm);
            //    /* MessageBox.Show(str.ToString()); *///Hiển thị lên MessageBox
            //}
        }

        private void frGHE_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //int maghe =Convert.ToInt32(txtghe.Tag);
            //    //MessageBox.Show(txtghe.Tag.ToString());
            //    string[] tachma = txtghe.Tag.ToString().Split(',');
            //    for (int i = 1; i < tachma.Length; i++)
            //    {
            //        //MessageBox.Show(tachma[i].ToString());
            //        gheDAO.Instance.updateghe(Convert.ToInt32(tachma[i]), idmaloaighe);
            //    }
            //    string[] tachmp = groupControl1.Text.ToString().Split(':');
            //    int map = Convert.ToInt32(tachmp[1]);
            //    int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
            //    //TAOGHE(map, gheof);
            //    //loadloaighe(map, gheof);
            //    //loadloaighe2(map, gheof);
            //    //txtghe.Text = " ";
            //    //txtghe.Tag = " ";
            //    MessageBox.Show("cập nhật ghế riêng thành công");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi cập nhật ghế: " + ex);
            //    MessageBox.Show("tạo thất bại");
            //}
        }
    }
}