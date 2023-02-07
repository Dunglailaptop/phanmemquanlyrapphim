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
    public partial class us_tongtien : DevExpress.XtraEditors.XtraUserControl
    {
        public us_tongtien()
        {
            InitializeComponent();
        }
        private decimal tongtien;

        public decimal Tongtien { 
            get {return tongtien; }
            set { tongtien = value; lbtong.Text = Convert.ToString(value); } 
        }

        private void us_tongtien_Load(object sender, EventArgs e)
        {

        }
    }
}
