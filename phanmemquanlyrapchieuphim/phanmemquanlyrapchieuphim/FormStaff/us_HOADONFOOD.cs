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

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class us_HOADONFOOD : DevExpress.XtraEditors.XtraUserControl
    {
        public us_HOADONFOOD()
        {
            InitializeComponent();
        }
        private string ten;
        private int soluong;
        private decimal gia;
        private int masp;

        public string Ten { 
             get {return ten; } 
             set { ten = value; lbten.Text = value; } 
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; lbsoluong.Text = Convert.ToString(value); }
        }
        public decimal Gia
        {
            get { return gia; }
            set { gia = value;lbgia.Text = Convert.ToString(value); } 
        }

        public int Masp
        {
            get { return masp; }
            set {masp = value;lbmasp.Text =Convert.ToString(value); } 
        }

        private void us_HOADONFOOD_Load(object sender, EventArgs e)
        {

        }
    }
}
