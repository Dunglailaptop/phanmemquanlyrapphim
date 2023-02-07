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
    public partial class us_suatchieu : DevExpress.XtraEditors.XtraUserControl
    {
        public us_suatchieu()
        {
            InitializeComponent();
        }
        private string thoigian;
        private string tenrap;
        private int maphim;
        private int maphong;
        public string Thoigian
        {
            get { return thoigian; }
            set { thoigian = value;label1.Text = value; } 
        }
        public string Tenrap
        {
            get { return tenrap; }
            set { tenrap = value;label2.Text = value; } 
        }

        public int Maphim { get => maphim; set => maphim = value; }
        public int Maphong { get => maphong; set => maphong = value; }

        private void us_suatchieu_Load(object sender, EventArgs e)
        {

        }
    }
}
