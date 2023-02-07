using DevExpress.XtraEditors;
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

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frHOADONFOOD : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public frHOADONFOOD(string list2)
        {
            InitializeComponent();
            us_HOADONFOOD ss;
            
            List<sanpham> p = new List<sanpham>();
            //frHOADONFOOD fr = new frHOADONFOOD();
            string ten=null;
            string[] tach = list2.Split(',');
           //p= fr;
           for(int i = 0; i < tach.Length-1; i++)
            {
                if (tach[i] != null)
                {
                    string[] tach2 = tach[i].Split(':');
                    for (int j = 0; j < tach2.Length - 1; j++)
                    {
                        //ten = tach2[0].ToString();
                        if (tach2[j] != null)
                        {
                            ss = new us_HOADONFOOD();
                            ss.Ten = tach2[0].ToString();
                            //if (ss.Ten==ten)
                            //{

                            ss.Soluong = int.Parse(tach2[1]);
                            ss.Gia = decimal.Parse(tach2[2]);
                            ss.Masp = int.Parse(tach2[3]);
                            flowLayoutPanel1.Controls.Add(ss);
                            //}
                            break;
                        }

                    }
                }
                
            }
            list = list2;
        }
        
        private string list;
        private decimal solg;
        private string masp;
        public string List
        {
            get { return list; }
            set { list = value; } 
        }
        public decimal Solg
        {
            get { return solg; }
            set { solg = value;lbtong.Text =String.Format("{0:0,0 vnd}",value/**1000*/); }
        }

        public string Masp { get => masp; set => masp = value; }

        private void lbtendoan_Click(object sender, EventArgs e)
        {

        }

        private void flyoutPanelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soluong = 0;
            decimal giatien = 0;
            string maspp = null;
            foreach(us_HOADONFOOD s in flowLayoutPanel1.Controls)
            {
                soluong += s.Soluong;
                giatien += s.Gia;
                maspp += s.Masp+":";
            }
            //MessageBox.Show(soluong.ToString()+":"+giatien.ToString());
            frTHANHTOAN tt = new frTHANHTOAN();
            string[] tach = lbtong.Text.Split(' ');
            tt.Tong = Convert.ToDecimal(tach[0]);
            tt.Doan = true;
            tt.List = list;
            //tt.Masp = maspp;
            tt.Soluong = soluong;
            tt.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbtong_Click(object sender, EventArgs e)
        {

        }
    }
}