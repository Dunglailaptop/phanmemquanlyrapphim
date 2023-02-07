using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;
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
    public partial class frthongke : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        bool ngay=true;
        bool thang=false;
        bool nam=false;
        bool ngay1=true;
        bool thang1=false;
        bool nam1=false;
        int maphim;

        public int Maphim1 { get => maphim; set => maphim = value; }

        public frthongke()
        {
            InitializeComponent();
            loadchart(dateTimePicker1.Value,dateTimePicker2.Value);
            sumphieuthu();
            baocaophim(dateTimePicker4.Value);
            loadchartphimby(dateTimePicker4.Value);
            baocaofood(dateTimePicker3.Value);
            loadchartfoodby(dateTimePicker3.Value);
            dateTimePicker7.ShowUpDown = true;
            loadchartnhanvienbymonth(dateTimePicker7.Value);
            baocaonhanvienbymonth(dateTimePicker7.Value);
            loadchartkhachhangbymonth(date8.Value);
            baocaokhachhangbymonth(date8.Value);
            //loadchart2(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        void loadchart(DateTime date1,DateTime date2)
        {
            try
            {
                
                chartControl1.Series.Clear();
                Series _SE = new Series("Tổng chi", ViewType.Line);
                Series _SE2 = new Series("Tổng thu", ViewType.Line);
                //_SE.Points.Clear();
                List<Class> pv = phieuchiDAO.Instance.phieuchi(date1, date2);
                List<Class> pv1 = phieuthuDAO.Instance.phieuthu(date1, date2);
                foreach (Class p in pv)
                {
                     _SE.Points.Add(new SeriesPoint(p.Thoigian_name,p.sotien));
                    foreach (Class p2 in pv1)
                    {
                        _SE2.Points.Add(new SeriesPoint(p2.Thoigian_name, p2.sotien));
                    }
                   
                }
                chartControl1.Series.Add(_SE);
                chartControl1.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                _SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }
            
        }
        void loadchartbyyear(DateTime date1, DateTime date2)
        {
            try
            {

                chartControl1.Series.Clear();
                Series _SE = new Series("Tổng chi", ViewType.Bar);
                Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phieuchiDAO.Instance.phieuchibyyear(date1, date2);
                List<Class> pv1 = phieuthuDAO.Instance.phieuthubyyear(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Năm "+p.Thoigian_name, p.sotien));
                    //break;

                }
                foreach (Class p2 in pv1)
                {
                    _SE2.Points.Add(new SeriesPoint("Năm "+p2.Thoigian_name, p2.sotien));
                }
                chartControl1.Series.Add(_SE);
                chartControl1.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                _SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartbymonth(DateTime date1, DateTime date2)
        {
            try
            {

                chartControl1.Series.Clear();
                Series _SE = new Series("Tổng chi", ViewType.Bar);
                Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phieuchiDAO.Instance.phieuchibymonth(date1, date2);
                List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("thang"+ p.Thoigian_name, p.sotien));
                    foreach (Class p2 in pv1)
                    {
                        _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    }

                }
                chartControl1.Series.Add(_SE);
                chartControl1.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                _SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchart2(DateTime date1, DateTime date2)
        {
            try
            {
                chartControl1.Series.Clear();
                Series _SE = new Series("Tổng thu", ViewType.Line);
                List<Class> pv = phieuthuDAO.Instance.phieuthu(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.Thoigian_name, p.sotien));
                }
                chartControl1.Series.Add(_SE);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void sumphieuthu()
        {
           
            try
            {
                chartControl2.Series.Clear();
                phieuthu pt = phieuthuDAO.Instance.sumphieuthu();
                phieuthu pt2 = phieuchiDAO.Instance.sumphieuchi();
                Series _SE = new Series(string.Format("{0:0,0 vnd}",pt.sotien), ViewType.Bar);
                Series _SE2 = new Series(string.Format("{0:0,0 vnd}", pt2.sotien), ViewType.Bar);
              
                _SE.Points.Add(new SeriesPoint("tong thu",pt.sotien));
                _SE2.Points.Add(new SeriesPoint("tong chi", pt2.sotien));
                chartControl2.Series.Add(_SE);
                chartControl2.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                _SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }
        }
        //baocaofood
        void baocaofood(DateTime d1)
        {
            try
            {
                gridControl3.DataSource = SanPhamDAO.Instance.baocaothucan(d1);
                gridView3.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void baocaofoodbymonth(DateTime d1)
        {
            try
            {
                gridControl3.DataSource = SanPhamDAO.Instance.baocaothucanbymonth(d1);
                gridView3.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void baocaochitietfoodbydate(DateTime d1,DateTime d2,int masp)
        {
            try
            {
                gridControl4.DataSource = SanPhamDAO.Instance.baocaochitietthucanbydate(d1,d2,masp);
                gridView4.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void baocaochitietfoodbymonth(DateTime d1, DateTime d2, int masp)
        {
            try
            {
                gridControl4.DataSource = SanPhamDAO.Instance.baocaochitietthucanbymonth(d1, d2, masp);
                gridView4.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void baocaochitietfoodbyyear(DateTime d1, DateTime d2, int masp)
        {
            try
            {
                gridControl4.DataSource = SanPhamDAO.Instance.baocaochitietthucanbyyear(d1, d2, masp);
                gridView4.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void loadchartfoodby(DateTime date1)
        {
            try
            {

                chartControl7.Series.Clear();
                Series _SE = new Series("Tên food", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = SanPhamDAO.Instance.baocaothucan(date1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.tenfood.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl7.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartfoodbymonth(DateTime date1)
        {
            try
            {

                chartControl7.Series.Clear();
                Series _SE = new Series("Tên food", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = SanPhamDAO.Instance.baocaothucanbymonth(date1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.tenfood.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl7.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartchitietfoodbydate(DateTime date1,DateTime date2,int masp)
        {
            try
            {

                chartControl8.Series.Clear();
                Series _SE = new Series("Ngày", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = SanPhamDAO.Instance.baocaochitietthucanbydate(date1,date2,masp);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Ngày"+p.ngaychieushow.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl8.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartchitietfoodbymonth(DateTime date1, DateTime date2, int masp)
        {
            try
            {

                chartControl8.Series.Clear();
                Series _SE = new Series("Tháng", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = SanPhamDAO.Instance.baocaochitietthucanbymonth(date1, date2, masp);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Tháng" + p.ngaychieushow.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl8.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartchitietfoodbyyear(DateTime date1, DateTime date2, int masp)
        {
            try
            {

                chartControl8.Series.Clear();
                Series _SE = new Series("Năm", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = SanPhamDAO.Instance.baocaochitietthucanbyyear(date1, date2, masp);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Năm" + p.ngaychieushow.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl8.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        //baocaophim
        void baocaophim(DateTime d1)
        {
            try
            {
                gridControl1.DataSource = phimDAO.Instance.doanhhthuphim(d1);
                gridView1.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void baocaophimbymonth(DateTime d1)
        {
            try
            {
                gridControl1.DataSource = phimDAO.Instance.doanhhthuphimbymonth(d1);
                gridView1.OptionsBehavior.Editable = false;
            }
            catch
            {

            }

        }
        void loadchartphimby(DateTime date1)
        {
            try
            {

                chartControl3.Series.Clear();
                Series _SE = new Series("Tên phim", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phimDAO.Instance.doanhhthuphim(date1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.tenphim.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl3.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartphimbymonth(DateTime date1)
        {
            try
            {

                chartControl3.Series.Clear();
                Series _SE = new Series("Tên phim", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phimDAO.Instance.doanhhthuphimbymonth(date1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.tenphim.ToString(), p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl3.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        //baocaochitietphim
        void loadchartphimchitiet(DateTime d1, DateTime d2, int map)
        {
            try
            {

                chartControl4.Series.Clear();
                Series _SE = new Series("Ngày chiếu", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phimDAO.Instance.BAOCAOPHIM(d1,d2,map);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint(p.ngaychieushow, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl4.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartphimchitietbymonth(DateTime d1, DateTime d2, int map)
        {
            try
            {

                chartControl4.Series.Clear();
                Series _SE = new Series("Tháng", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phimDAO.Instance.BAOCAOPHIMbymonth(d1, d2, map);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Tháng "+p.ngaychieushow, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl4.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void loadchartphimchitietbyyear(DateTime d1, DateTime d2, int map)
        {
            try
            {

                chartControl4.Series.Clear();
                Series _SE = new Series("Năm", ViewType.Bar);
                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                List<Class> pv = phimDAO.Instance.BAOCAOPHIMbyyear(d1, d2, map);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE.Points.Add(new SeriesPoint("Năm "+p.ngaychieushow, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl4.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void baocaophimbyyear(DateTime d1, DateTime d2, int map)
        {
            try
            {
                gridControl2.DataSource = phimDAO.Instance.BAOCAOPHIMbyyear(d1, d2, map);
            }
            catch
            {

            }
           
        }
        void baocaophimbymonth(DateTime d1, DateTime d2, int map)
        {
            try
            {
                gridControl2.DataSource = phimDAO.Instance.BAOCAOPHIMbymonth(d1, d2, map);
            }
            catch
            {

            }
           
        }
        void baocaophimbyngay(DateTime d1, DateTime d2, int map)
        {
            try
            {
                gridControl2.DataSource = phimDAO.Instance.BAOCAOPHIM(d1,d2,map);
            }
            catch
            {

            }

        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if(ngay==true)
            {
                loadchart(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if(thang==true)
            {
                loadchartbymonth(dateTimePicker1.Value, dateTimePicker2.Value);
            }else if(nam==true)
            {
                loadchartbyyear(dateTimePicker1.Value, dateTimePicker2.Value);
            }
          
            //loadchart2(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (ngay == true)
            {
                loadchart(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (thang == true)
            {
                loadchartbymonth(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (nam == true)
            {
                loadchartbyyear(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            //loadchart2(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            //chartControl1.Controls.Clear();
            //chartControl1.Series.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem=="Ngày")
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                dateTimePicker2.CustomFormat = "dd-MM-yyyy";
                dateTimePicker1.ShowUpDown = false;
                dateTimePicker2.ShowUpDown = false;
                ngay = true;
                thang = false;
                nam= false;
            }else if(comboBox1.SelectedItem=="Tháng")
            {
                dateTimePicker1.CustomFormat = "MM";
                dateTimePicker2.CustomFormat = "MM";
                dateTimePicker1.ShowUpDown = true;
                dateTimePicker2.ShowUpDown = true;
                ngay = false;
                thang = true;
                nam = false;
            }else if(comboBox1.SelectedItem == "Năm")
            {
                dateTimePicker1.CustomFormat = "yyyy";
                dateTimePicker2.CustomFormat = "yyyy";
                dateTimePicker1.ShowUpDown = true;
                dateTimePicker2.ShowUpDown = true;
                ngay = false;
                thang = false;
                nam = true;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (comboBox1.SelectedItem == "Ngày")
            //{
            //    dateTimePicker4.CustomFormat = "dd-MM-yyyy";
            //    dateTimePicker3.CustomFormat = "dd-MM-yyyy";
            //    dateTimePicker4.ShowUpDown = false;
            //    dateTimePicker3.ShowUpDown = false;
            //    ngay = true;
            //    thang = false;
            //    nam = false;
            //    baocaophim(dateTimePicker4.Value, dateTimePicker3.Value, 0);
            //    loadchartphimby(dateTimePicker4.Value, dateTimePicker3.Value, 0);
            //}
            if (comboBox2.SelectedItem == "Tháng")
            {
                dateTimePicker4.CustomFormat = "MM";
                dateTimePicker4.ShowUpDown = true;
                baocaophimbymonth(dateTimePicker4.Value);
                loadchartphimbymonth(dateTimePicker4.Value);
                ngay = false;
                thang = true;
                nam = false;
            }
            else if (comboBox2.SelectedItem == "Năm")
            {
                dateTimePicker4.CustomFormat = "yyyy";
                dateTimePicker4.ShowUpDown = true;
                baocaophim(dateTimePicker4.Value);
                loadchartphimby(dateTimePicker4.Value);
                ngay = false;
                thang = false;
                nam = true;
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            baocaophim(dateTimePicker4.Value);
            loadchartphimby(dateTimePicker4.Value);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            baocaophim(dateTimePicker4.Value);
            loadchartphimby(dateTimePicker4.Value);
        }

        private void chartControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            lbtenphim.Text = " ";
            lbtenphim.Tag = " ";
            ngay1 = true;
            nam1 = false;
            thang1 = false;
            if(gridView1.GetFocusedRowCellValue("maphim")!=null)
            {
                groupControl3.Enabled = true;
                int maphim = (int)gridView1.GetFocusedRowCellValue("maphim");
                phim ph=db.phims.Where(x=>x.Maphim==maphim).FirstOrDefault();
                maphim = ph.Maphim;
                loadchartphimchitiet(date1.Value, date2.Value, maphim);
                baocaophimbyngay(date1.Value, date2.Value, maphim);
                lbtenphim.Text = ph.Tenphim;
                lbtenphim.Tag = ph.Maphim;
            }
            else
            {
                MessageBox.Show("rỗng");
            }
        }

        private void lbtenphim_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Ngày")
            {
                date1.CustomFormat = "dd-MM-yyyy";
                date2.CustomFormat = "dd-MM-yyyy";
                date1.ShowUpDown = false;
                date2.ShowUpDown = false;
                baocaophimbyngay(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                loadchartphimchitiet(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                ngay1 = true;
                thang1 = false;
                nam1 = false;
            }
            else if (comboBox3.SelectedItem == "Tháng")
            {
                date1.CustomFormat = "MM";
                date2.CustomFormat = "MM";
                date1.ShowUpDown = true;
                date2.ShowUpDown = true;
                baocaophimbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                loadchartphimchitietbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                ngay1 = false;
                thang1 = true;
                nam1 = false;
            }
            else if (comboBox3.SelectedItem == "Năm")
            {
                date1.CustomFormat = "yyyy";
                date2.CustomFormat = "yyyy";
                date1.ShowUpDown = true;
                date2.ShowUpDown = true;
                baocaophimbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                loadchartphimchitietbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                ngay1 = false;
                thang1 = false;
                nam1 = true;
            }
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            if (ngay1 == true)
            {
                loadchartphimchitiet(date1.Value, date2.Value,int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbyngay(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
            else if(thang1==true)
            {
                loadchartphimchitietbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
            else if(nam1==true)
            {
                loadchartphimchitietbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
            
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            if (ngay1 == true)
            {
                loadchartphimchitiet(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbyngay(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
            else if (thang1 == true)
            {
                loadchartphimchitietbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbymonth(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
            else if (nam1 == true)
            {
                loadchartphimchitietbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
                baocaophimbyyear(date1.Value, date2.Value, int.Parse(lbtenphim.Tag.ToString()));
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == "Tháng")
            {
                dateTimePicker3.CustomFormat = "MM";
                dateTimePicker3.ShowUpDown = true;
                baocaofoodbymonth(dateTimePicker3.Value);
                loadchartfoodbymonth(dateTimePicker3.Value);
                ngay = false;
                thang = true;
                nam = false;
            }
            else if (comboBox4.SelectedItem == "Năm")
            {
                dateTimePicker3.CustomFormat = "yyyy";
                dateTimePicker3.ShowUpDown = true;
                baocaofood(dateTimePicker3.Value);
                loadchartfoodby(dateTimePicker3.Value);
             
                ngay = false;
                thang = false;
                nam = true;
            }
        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {
            if(nam==true)
            {
                baocaofood(dateTimePicker3.Value);
                loadchartfoodby(dateTimePicker3.Value);
            }else if(thang==true)
            {
                baocaofoodbymonth(dateTimePicker3.Value);
                loadchartfoodbymonth(dateTimePicker3.Value);
            }
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {
            lbtensanpham.Text = " ";
            lbtensanpham.Tag = " ";
            ngay1 = true;
            nam1 = false;
            thang1 = false;
            dateTimePicker5.CustomFormat = "dd-MM-yyyy";
            dateTimePicker6.CustomFormat = "dd-MM-yyyy";
            dateTimePicker5.ShowUpDown = false;
            dateTimePicker6.ShowUpDown = false;
            groupControl7.Enabled = true;
            if (gridView3.GetFocusedRowCellValue("maphim")!=null)
            {
                int masp =(int)gridView3.GetFocusedRowCellValue("maphim");
                sanpham sp = db.sanphams.Where(x => x.Masp == masp).FirstOrDefault();
                lbtensanpham.Text = sp.Tensanpham;
                lbtensanpham.Tag = sp.Masp;
                baocaochitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }
            else
            {
                MessageBox.Show("rỗng");
            }
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox5.SelectedItem == "Ngày")
            {
                dateTimePicker5.CustomFormat = "dd-MM-yyyy";
                dateTimePicker6.CustomFormat = "dd-MM-yyyy";
                dateTimePicker5.ShowUpDown = false;
                dateTimePicker6.ShowUpDown = false;
                baocaochitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                ngay1 = true;
                thang1 = false;
                nam1 = false;
            }
            else if (comboBox5.SelectedItem == "Tháng")
            {
                dateTimePicker5.CustomFormat = "MM";
                dateTimePicker6.CustomFormat = "MM";
                dateTimePicker5.ShowUpDown = true;
                dateTimePicker6.ShowUpDown = true;
                baocaochitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                ngay1 = false;
                thang1 = true;
                nam1 = false;
            }
            else if (comboBox5.SelectedItem == "Năm")
            {
                dateTimePicker5.CustomFormat = "yyyy";
                dateTimePicker6.CustomFormat = "yyyy";
                dateTimePicker5.ShowUpDown = true;
                dateTimePicker6.ShowUpDown = true;
                baocaochitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                ngay1 = false;
                thang1 = false;
                nam1 = true;
            }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            if(ngay1==true)
            {
                baocaochitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }else if(thang1==true)
            {
                baocaochitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }else if(nam1==true)
            {
                baocaochitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }
          
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            if (ngay1 == true)
            {
                baocaochitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbydate(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }
            else if (thang1 == true)
            {
                baocaochitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbymonth(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }
            else if (nam1 == true)
            {
                baocaochitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
                loadchartchitietfoodbyyear(dateTimePicker5.Value, dateTimePicker6.Value, int.Parse(lbtensanpham.Tag.ToString()));
            }
        }
        //baocaonhanvien
        void baocaonhanvienbymonth(DateTime date)
        {
            gridControl5.DataSource = nhanvienDAO.Instance.baocaonhanvienbymonth(date);
        }
        void loadchartnhanvienbymonth(DateTime d1)
        {
            try
            {

                chartControl5.Series.Clear();

                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                Series _SE=new Series();
               List <Class> pv =nhanvienDAO.Instance.baocaonhanvienbymonth(d1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE = new Series(p.manv, ViewType.Pie);
                    _SE.Points.Add(new SeriesPoint(p.manv,p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl5.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void baocaonhanvienbyyear(DateTime date)
        {
            gridControl5.DataSource = nhanvienDAO.Instance.baocaonhanvienbyyear(date);
        }
        void loadchartnhanvienbyyear(DateTime d1)
        {
            try
            {

                chartControl5.Series.Clear();

                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                Series _SE = new Series();
                List<Class> pv = nhanvienDAO.Instance.baocaonhanvienbyyear(d1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE = new Series(p.manv, ViewType.Pie);
                    _SE.Points.Add(new SeriesPoint(p.manv, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl5.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox6.SelectedItem == "Tháng")
            {
                dateTimePicker7.CustomFormat = "MM";
               
                dateTimePicker7.ShowUpDown = true;

                loadchartnhanvienbymonth(dateTimePicker7.Value);
                baocaonhanvienbymonth(dateTimePicker7.Value);
                ngay1 = false;
                thang1 = true;
                nam1 = false;
            }
            else if (comboBox6.SelectedItem == "Năm")
            {
                dateTimePicker7.CustomFormat = "yyyy";

                dateTimePicker7.ShowUpDown = true;
                loadchartnhanvienbyyear(dateTimePicker7.Value);
                baocaonhanvienbyyear(dateTimePicker7.Value);
                ngay1 = false;
                thang1 = false;
                nam1 = true;
            }
        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {
            if(thang1==true)
            {
                loadchartnhanvienbymonth(dateTimePicker7.Value);
                baocaonhanvienbymonth(dateTimePicker7.Value);
            }else if(nam1==true)
            {
                loadchartnhanvienbyyear(dateTimePicker7.Value);
                baocaonhanvienbyyear(dateTimePicker7.Value);
            }
          
        }
        //baocaokhachhang
        void baocaokhachhangbymonth(DateTime date)
        {
            gridControl6.DataSource = khachhangDAO.Instance.baocaokhachhangbymonth(date);
        }
        void loadchartkhachhangbymonth(DateTime d1)
        {
            try
            {

                chartControl6.Series.Clear();

                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                Series _SE = new Series();
                List<Class> pv = khachhangDAO.Instance.baocaokhachhangbymonth(d1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE = new Series(p.manv, ViewType.Pie);
                    _SE.Points.Add(new SeriesPoint(p.hoten, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl6.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        void baocaokhachhangbyyear(DateTime date)
        {
            gridControl6.DataSource = khachhangDAO.Instance.baocaokhachhangbyyear(date);
        }
        void loadchartkhachhangbyyear(DateTime d1)
        {
            try
            {

                chartControl6.Series.Clear();

                //Series _SE2 = new Series("Tổng thu", ViewType.Bar);
                //_SE.Points.Clear();
                Series _SE = new Series();
                List<Class> pv = khachhangDAO.Instance.baocaokhachhangbyyear(d1);
                //List<Class> pv1 = phieuthuDAO.Instance.phieuthubymonth(date1, date2);
                foreach (Class p in pv)
                {
                    _SE = new Series(p.manv, ViewType.Pie);
                    _SE.Points.Add(new SeriesPoint(p.hoten, p.giatien));
                    //foreach (Class p2 in pv1)
                    //{
                    //    _SE2.Points.Add(new SeriesPoint("tháng" + p2.Thoigian_name, p2.sotien));
                    //}

                }
                chartControl6.Series.Add(_SE);
                //chartControl3.Series.Add(_SE2);
                _SE.Label.TextPattern = "{A}: {VP: p0}";
                //_SE2.Label.TextPattern = "{A}: {VP: p0}";
            }
            catch (Exception ex)
            {

            }

        }
        bool ngay2,thang2=true,nam2;

        private void date8_ValueChanged(object sender, EventArgs e)
        {
            if (thang2==true)
            {
                loadchartkhachhangbymonth(date8.Value);
                baocaokhachhangbymonth(date8.Value);
            }
            else if(nam2==true)
            {
                loadchartkhachhangbyyear(date8.Value);
                baocaokhachhangbyyear(date8.Value);
            }
          
        }

        private void cbkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbkhachhang.SelectedItem == "Tháng")
            {
                date8.CustomFormat = "MM";

                date8.ShowUpDown = true;

                loadchartkhachhangbymonth(date8.Value);
                baocaokhachhangbymonth(date8.Value);
                ngay2 = false;
                thang2 = true;
                nam2 = false;
            }
            else if (cbkhachhang.SelectedItem == "Năm")
            {
                date8.CustomFormat = "yyyy";

                date8.ShowUpDown = true;
                loadchartkhachhangbyyear(date8.Value);
                baocaokhachhangbyyear(date8.Value);
                ngay2 = false;
                thang2 = false;
                nam2 = true;
            }
        }
    }
}