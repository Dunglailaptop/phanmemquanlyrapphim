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
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using System.IO;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class US_DSPHIM : DevExpress.XtraEditors.XtraUserControl
    {
        public US_DSPHIM()
        {
            InitializeComponent();
            //load();
        }
        private string tenphim;
        private Image image;
        private DateTime date;
        private int maphim;

        public string Tenphim
        {
            get { return tenphim; }
            set { tenphim = value;lbtenphim.Text = value; } 
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; lbngaychieu.Text =value.ToString(); }
        }
        public Image Image
        {
            get { return image; }
            set { image = value;pictureBox1.Image = value; } 
        }

        public int Maphim { get => maphim; set => maphim = value; }


        //public void load()
        //{
        //    Image = pictureBox1.Image;
        //    //if(Image==null)
        //    //{
        //    //    MessageBox.Show("RONG");
        //    //}
        //    lbtenphim.Text = tenphim;
        //    lbngaychieu.Text = Convert.ToString(date);
        //}
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void US_DSPHIM_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.BorderStyle = BorderStyle.None;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            //this.BackColor = Color.Gray;
        }

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            //this.BackColor = Color.Red;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            //button1.BackColor = Color.Red;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.Red;
            //this.BorderStyle=BorderStyle.None;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.Gray;
            //this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void US_DSPHIM_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void US_DSPHIM_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
