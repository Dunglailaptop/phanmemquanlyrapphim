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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webtnonline.Models;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frTHANHTOAN : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frTHANHTOAN()
        {
            InitializeComponent();

            //MessageBox.Show(lbmaghe.TO)
            //tt = textBox8.Text;
            //textBox8.Text = string.Format("{0:0,0 VNĐ}");
        }
        bool voucher = false;
        bool thanhvien = false;
        bool ptthanhtoan=false;
        bool ktnhap=false;
        private string lbghe;
        private string lbmaghe;
        private int maphim;
        private decimal tong;
        private decimal giave;
        private int machieu;
        private string mahoadon;
        private string date;
        private string time;
        private int maphong;
        private bool doan;
        private bool vexem;
        private decimal tongtien;
        private int soluongtong;
        private string masp;
        private int maspp;
        private int soluong;
        private decimal giatien;
        private string list;

        public string Lbghe { get => lbghe; set => lbghe = value; }
        public string Lbmaghe { get => lbmaghe; set => lbmaghe = value; }
        public int Maphim { get => maphim; set => maphim = value; }
        public decimal Tong
        {
            get { return tong; }
            set { tong = value; tong3.Text= String.Format("{0:0,0 vnd}", value); tong1.Text = String.Format("{0:0,0 vnd}",value);tong2.Text = String.Format("{0:0,0 vnd}",value);txttongtien.Text = String.Format("{0:0,0 vnd}", value); } 
        }
        public decimal Giave { get => giave; set => giave = value; }
        public int Machieu { get => machieu; set => machieu = value; }
        public string Mahoadon { get => mahoadon; set => mahoadon = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public int Maphong { get => maphong; set => maphong = value; }
        public bool Doan { get => doan; set => doan = value; }
        public bool Vexem { get => vexem; set => vexem = value; }
        public decimal Tongtien { get => tongtien; set => tongtien = value; }
        public int Soluongtong { get => soluongtong; set => soluongtong = value; }
        public string Masp { get => masp; set => masp = value; }
        public int Maspp { get => maspp; set => maspp = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Giatien { get => giatien; set => giatien = value; }
        public string List { get => list; set => list = value; }

        private void textBox8_Click(object sender, EventArgs e)
        {
            //textBox8.Text = " ";
        }
        void thanhtoan(DateTime Ngaytao, decimal giaveduocgiam, int soluongve, int maphim, decimal tongtien, decimal giave)
        {
            HoaDonDAO.Instance.THANHTOAN(Ngaytao, giaveduocgiam, soluongve, maphim, tongtien, giave);
        }
        void insertghe(int machieu, int maghe,string mahoadon)
        {
            HoaDonDAO.Instance.INSERTGHEDAMUA(machieu, maghe,mahoadon);
        }
        void insertvexem(string mahoadon, int machieu, int maghe)
        {
            HoaDonDAO.Instance.INSERTVEXEM(mahoadon, machieu, maghe);
        }
        public string thanhtoan()
        {
            string mahoad = null;
            string[] soluong = lbghe.Split(',');
            int dem = 0;
            for (int i = 0; i < soluong.Length; i++)
            {
                if (soluong[i] != "")
                {
                    dem++;
                }


            }
            Random r = new Random();
            string HD = "HD";
            hoadon hd = new hoadon();
            
             //mahoadon = crypt.Encrypt(HD.Trim() + r.Next().ToString(), true);
            DateTime dateTime = DateTime.Now;
            //thanhtoan(dateTime, 0, dem, Maphim, tong, Giave);
           hd= HoaDonDAO.Instance.THANHTOAN(dateTime, 0, dem, Maphim, tong, Giave);
            //MessageBox.Show(hd.Mahoadon);
            string[] soluongmaghe = lbmaghe.Split(',');

            for (int i = 0; i < soluongmaghe.Length; i++)
            {
                if (soluongmaghe[i] != "")
                {
                    insertvexem(hd.Mahoadon, Machieu, int.Parse(soluongmaghe[i]));
                    insertghe(Machieu, int.Parse(soluongmaghe[i]),hd.Mahoadon);
                }

            }
            decimal tientra = Convert.ToDecimal(txttienkhach.Text) - Convert.ToDecimal(tong);
            //if(textBox8.Text!=null)
            //{
                phieuchiDAO.Instance.taophieuchi(DateTime.Now, DateTime.Now, tientra);
            phieuthuDAO.Instance.taophieuthu(DateTime.Now, DateTime.Now, Convert.ToDecimal(txttienkhach.Text));
            //}
            MessageBox.Show("thanh toan thanh cong !!!!!!!");
            mahoad = hd.Mahoadon;
            return mahoad;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

         
            //if (tienkhach >= int.Parse(tong2.Text.ToString()))
            //{

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "8";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + "000";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txttienkhach.Clear();
          
            //REPORT.ShowPreview();
        }

        private void button20_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //int tientra; /*=int.Parse(textBox7.Text);*/
            //int tienkhach=int.Parse(textBox8.Text);
            //tientra = int.Parse(tong2.Text.ToString()) - tienkhach;
            //textBox7.Text = tientra.ToString();
            //if(tienkhach>= int.Parse(tong2.Text.ToString()))
            //{

            //}
            if(ptthanhtoan==true)
            {
                if(ktnhap==true)
                {
                    if (vexem == true)
                    {
                       
                        string mahd = null;
                        mahd = thanhtoan();
                        if (panelControl2.Visible == false && thanhvien==true)
                        {
                            if (khachhangDAO.Instance.tichdiemkh(textBox6.Tag.ToString()))
                            {
                                if (khachhangDAO.Instance.phieuthanhvienvexem(textBox6.Tag.ToString(),mahd))
                                {
                                    MessageBox.Show("tích điểm thành công");
                                }

                            }
                        }
                        if(voucher==true)
                        {
                            if(voucherDAO.Instance.hoadonvoucher(txtptram.Tag.ToString(),mahd))
                                {
                                MessageBox.Show("Hóa đơn có voucher");
                            }
                        }
                        RP_HOADON report = new RP_HOADON();
                        //ReportPrintTool printTool = new ReportPrintTool(report);
                        //printTool.ShowPreview();
                        /*  report.PrintDialog()*/
                        DataClasses1DataContext db = new DataClasses1DataContext();
                        report.DataSource = db.USP_INHOADON(mahd, time, date, maphim, maphong);
                        report.CreateDocument();
                        report.ShowPreview();
                    }
                    else if (doan == true)
                    {
                        
                        hoadonsanpham hd = new hoadonsanpham();
                        hd = HoaDonDAO.Instance.INSERTFOOD(tong, soluong, DateTime.Now);
                        if (panelControl2.Visible == false && thanhvien==true)
                        {
                            if (khachhangDAO.Instance.tichdiemkh(textBox6.Tag.ToString()))
                            {
                                if (khachhangDAO.Instance.phieuthanhvienfood(textBox6.Tag.ToString(),hd.Mahoadon))
                                {
                                    MessageBox.Show("tích điểm thành công");
                                }

                            }
                        }
                        if (voucher==true)
                        {
                            if (voucherDAO.Instance.hoadonvoucher(txtptram.Tag.ToString(), hd.Mahoadon))
                            {
                                MessageBox.Show("Hóa đơn có voucher");
                            }
                        }
                        //MessageBox.Show(hd.Mahoadon);
                        if (hd.Mahoadon != null)
                        {



                            string ten = null;
                            string[] tach = list.Split(',');
                            //p= fr;
                            for (int i = 0; i < tach.Length - 1; i++)
                            {
                                if (tach[i] != null)
                                {
                                    string[] tach2 = tach[i].Split(':');
                                    for (int j = 0; j < tach2.Length - 1; j++)
                                    {
                                        //ten = tach2[0].ToString();
                                        if (tach2[j] != null)
                                        {
                                            HoaDonDAO.Instance.insertchitiethoadonfood(int.Parse(tach2[3]), int.Parse(tach2[1]), decimal.Parse(tach2[2]), hd.Mahoadon);
                                            //}
                                            break;
                                        }

                                    }
                                }
                            }
                            decimal tientra = Convert.ToDecimal(txttienkhach.Text) - Convert.ToDecimal(tong);
                            phieuthuDAO.Instance.taophieuthu(DateTime.Now, DateTime.Now, Convert.ToDecimal(txttienkhach.Text));
                            phieuchiDAO.Instance.taophieuchi(DateTime.Now, DateTime.Now, tientra);
                        }

                        MessageBox.Show("them succecced");
                        rp_HOADONFOOD report = new rp_HOADONFOOD();
                        //ReportPrintTool printTool = new ReportPrintTool(report);
                        //printTool.ShowPreview();
                        /*  report.PrintDialog()*/
                        DataClasses1DataContext db = new DataClasses1DataContext();
                        report.DataSource = HoaDonDAO.Instance.inhoadonfood(hd.Mahoadon);
                        report.CreateDocument();
                        report.ShowPreview();
                    }
                }else
                {
                    MessageBox.Show("Bạn chưa nhập tiền khách đưa");
                }
              
            }else
            {
                MessageBox.Show("Bạn chưa chọn phương thức thanh toán");
            }
         
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frTHANHTOAN_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ptthanhtoan = true;
            simpleButton1.BackColor = Color.Yellow;
            panel13.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = txttienkhach.Text + ".";
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            txttienkhach.Clear();

        }

        private void lbtongtien_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tong1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button18_Click_2(object sender, EventArgs e)
        {
            if (txttienkhach.Text.Length > 0)
            {
                txttienkhach.Text = txttienkhach.Text.Remove(txttienkhach.Text.Length - 1, 1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txttienkhach.Text = " ";
        }
        void epkieu()
        {
            decimal tienkhach =decimal.Parse(txttienkhach.Text);
            txttienkhach.Text=String.Format("{0:0,0 vnd}",tienkhach);

        }
        private void txttienkhach_TextChanged(object sender, EventArgs e)
        {
            if(txttienkhach.Text!=null && decimal.Parse(txttienkhach.Text)>=tong)
            {
                ktnhap = true;
            }
            //int tientra; /*=int.Parse(textBox7.Text);*/

            //string[] tach = tong2.Text.Split(' ');
            //epkieu();
            decimal tientra = decimal.Parse(txttienkhach.Text) - tong;
            //MessageBox.Show(tientra.ToString());
            textBox7.Text = String.Format("{0:0,0 vnd}",tientra);
            //textEdit1.Text = tientra.ToString();
            //int tienkhach = int.Parse(txttienkhach.Text);
            //tientra = int.Parse(tach[1]) - tienkhach;
            //textBox7.Text = tientra.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelControl2.Visible = true;
        }

        private void checkEdit2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                thanhvien = true;
                panelControl2.Visible = false;
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //voucher vc = db.vouchers.Where(x => x.Makm == txtmavc.Text).SingleOrDefault();
            //if (vc != null)
            //{
            //    txtptram.Text = vc.giagiam;
            //    string[] tach = vc.giagiam.Split(' ');
            //    float chiaphantram = (float.Parse(tach[0]) / 100);
            //    txttiengiam.Text = Convert.ToString(float.Parse(tong.ToString()) * chiaphantram);
            //    txtlydo.Text = vc.tenkm;
            //    decimal tongtiencantra = Tong - decimal.Parse(txttiengiam.Text);
            //    Tong = tongtiencantra;
            //}else
            //{
            //    decimal tongtiencantra = Tong - decimal.Parse(txttiengiam.Text);
            //    Tong = tongtiencantra;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                voucher vc = db.vouchers.Where(x => x.Makm == txtmavc.Text).SingleOrDefault();
                if(vc!= null)
                {
                    voucher = true;
                    txtptram.Text = vc.giagiam;
                    txtptram.Tag = vc.Makm;
                    string[] tach = vc.giagiam.Split(' ');
                    float chiaphantram = (float.Parse(tach[0]) / 100);
                    txttiengiam.Text = Convert.ToString(float.Parse(tong.ToString()) * chiaphantram);
                    txtlydo.Text = vc.tenkm;
                   decimal tongtiencantra = Tong - decimal.Parse(txttiengiam.Text);
                    Tong = tongtiencantra;
                }
            
            }
            catch
            {
                MessageBox.Show("failed");
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                khachhang kh = khachhangDAO.Instance.searchkhachhang(textEdit2.Text);
                if(kh!=null)
                {
                    thanhvien = true;
                    textEdit3.Text = kh.hoten;
                    textBox6.Text = kh.diem.ToString() + " đ";
                    textBox6.Tag = kh.Makh;
                }else
                {
                    thanhvien = false;
                }
              
            }catch
            {

            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                thanhvien = false;
                panelControl2.Visible = true;
            }
        }

        private void tong1_Click_1(object sender, EventArgs e)
        {

        }
    }
}