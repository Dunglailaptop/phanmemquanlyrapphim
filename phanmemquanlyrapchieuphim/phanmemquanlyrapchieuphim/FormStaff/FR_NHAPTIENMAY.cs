using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class FR_NHAPTIENMAY : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FR_NHAPTIENMAY()
        {
            InitializeComponent();
            loaddsthuchi();
            //loaddsphieuchi();
            //loadchart();
            //try
            //{
            //    tongphieuchi(DateTime.Now, DateTime.Now);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("loi"+ex);
            //}
           
            //string i = 1000000;
            //IntToString(i);
            //MessageBox.Show(IntToString(i));
        }
        //void tongphieuchi(DateTime time,DateTime time2)
        //{
        //    phieuchi ph = phieuchiDAO.Instance.tongphieuchi(time,time2);
        //    txttongtien.Text = String.Format("{0:0,0 vnd}",ph.sotien*1000);
        //}
        void loaddsthuchi()
        {
            
           gridControl1.DataSource= quanlythuchiDAO.Instance.loaddsthuchi();
        }
        //void loaddsphieuchi()
        //{
        //    gridControl2.DataSource = phieuchiDAO.Instance.loaddsphieuchi();
        //}
        //void loadchart()
        //{
        //    Series _SE = new Series("Báo cáo tổng tiền chi",ViewType.Pie);
        //    List<Class> pv = phieuchiDAO.Instance.phieuchi(DateTime.Now, DateTime.Now);
        //    foreach(Class p in pv) {
        //        _SE.Points.Add(new SeriesPoint(p.Thoigian_name,p.sotien));
        //    }
        //    chartControl1.Series.Add(_SE);
        //    _SE.Label.TextPattern = "{A}: {VP: p0}";
        //}
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text.Length>0)
            {
                textEdit1.Text = textEdit1.Text.Remove(textEdit1.Text.Length - 1, 1);
            }
            //if (textEdit1.Text == String.Empty) textEdit1.Text = "0";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "1";
        }
        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "2";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "3";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            textEdit1.Text = string.Format("{0:0,0}", textEdit1.Text);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "4";
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "5";
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "6";
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "7";
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "8";
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "9";
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "0";
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + "000";
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textEdit1.Text + ".";
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            textEdit1.Text=" ";
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
          
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm Yes/No", "Thông báo", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    decimal tien = decimal.Parse(textEdit1.Text);
                    if (quanlythuchiDAO.Instance.nhaptien(tien, DateTime.Now, DateTime.Now))
                    {
                        loaddsthuchi();
                        MessageBox.Show("Thêm thành công");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi không thêm được");
                }
            }
          
           
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //tongphieuchi(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txttongtien_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //tongphieuchi(dateTimePicker1.Value,dateTimePicker2.Value);
        }

        private void chartControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "1";
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "2";
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "3";
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "4";
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "5";
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "6";
        }

        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "7";
        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "8";
        }

        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "9";
        }

        private void simpleButton11_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "0";
        }

        private void simpleButton12_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + "000";
        }

        private void simpleButton13_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = textEdit2.Text + ",";
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            if (textEdit2.Text.Length > 0)
            {
                textEdit2.Text = textEdit2.Text.Remove(textEdit2.Text.Length - 1, 1);
            }
        }

        private void simpleButton15_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm Yes/No", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    decimal tien = decimal.Parse(textEdit2.Text);
                    if (quanlythuchiDAO.Instance.nhaptien(tien, DateTime.Now, DateTime.Now))
                    {
                        loaddsthuchi();
                        MessageBox.Show("Thêm thành công");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi không thêm được");
                }
            }
        }

        private void simpleButton14_Click_1(object sender, EventArgs e)
        {
            textEdit2.Text = " ";
        }
    }
}