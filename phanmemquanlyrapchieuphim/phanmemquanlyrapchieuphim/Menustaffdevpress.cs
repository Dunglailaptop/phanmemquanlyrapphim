using DevExpress.XtraEditors;
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

namespace phanmemquanlyrapchieuphim
{
    public partial class Menustaffdevpress : DevExpress.XtraEditors.XtraForm
    {
        public Menustaffdevpress()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DANGNHAP DP=new DANGNHAP();
            DP.Show();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            //if (panelMenu.Visible == false)
            //{
            //    panelMenu.Visible = true;


            //}
            //else if (panelMenu.Visible == true)
            //{
            //    panelMenu.Visible = false;
            //}
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            DANGNHAP dANGNHAP = new DANGNHAP();
            dANGNHAP.Show();
        }

        private void Menustaffdevpress_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            frDATVEXEM DVXEM=new frDATVEXEM();
            DVXEM.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DANGNHAP dANGNHAP = new DANGNHAP();
            dANGNHAP.Show();
        }
    }
}