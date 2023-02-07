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
    public partial class Us_PHONG : UserControl
    {
        public Us_PHONG()
        {
            InitializeComponent();
        }
        private int maphong;
        private int gheofday;
        private string tenphong;
        private int trangthai;
        private int tongsoghe;
        public int Maphong {
            get {return maphong; }
            set { maphong = value; lbsophong.Text =Convert.ToString(value); }
        }

        public int Gheofday { get => gheofday; set => gheofday = value; }
        public string Tenphong
        {
            get { return tenphong; }
            set { tenphong = value;lbtenphong.Text = value; } 
        }

        public int Trangthai {
            get {return trangthai; }
            set { trangthai = value; 
            if(value ==1)
                {
                    lbtrangthai.ForeColor = Color.Red;
                    lbtrangthai.Text = "Active";
                }else if(value ==0)
                {
                    lbtrangthai.ForeColor = Color.Green;
                    lbtrangthai.Text = "None";
                }
            } 
        }

        public int Tongsoghe { get => tongsoghe; set => tongsoghe = value; }

        private void Us_PHONG_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
