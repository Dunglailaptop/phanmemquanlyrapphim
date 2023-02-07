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
    public partial class us_loaighe : DevExpress.XtraEditors.XtraUserControl
    {
        public us_loaighe()
        {
            InitializeComponent();
            //int argb = -16711936;
            //button1.FlatAppearance.BorderColor = Color.FromArgb(argb);

        }
        private string argb;
        private string tenghe;
        private decimal giave;
        private int id;
        private int maphong;
        private int gheofday;
        public string Argb {
            get { return argb; }
            set { argb = value;button1.FlatAppearance.BorderColor = Color.FromArgb(Convert.ToInt32(value)); } 
        }

        public string Tenghe 
        {
            get {return tenghe; }
            set { tenghe = value; lbtenghe.Text = value; } 
        }

        public decimal Giave
        {
            get { return giave; }
            set { giave = value; lbgia.Text =string.Format("{0:0,0 vnd}",value); } 
        }

        public int Id { get => id; set => id = value; }
        public int Maphong { get => maphong; set => maphong = value; }
        public int Gheofday
        {
            get { return gheofday; }
            set { gheofday = value;lbhangghe.Text =Convert.ToString(value); } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void us_loaighe_Load(object sender, EventArgs e)
        {

        }

        private void us_loaighe_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void us_loaighe_MouseClick(object sender, MouseEventArgs e)
        {
            //this.BackColor = Color.Gray;
        }
    }
}
