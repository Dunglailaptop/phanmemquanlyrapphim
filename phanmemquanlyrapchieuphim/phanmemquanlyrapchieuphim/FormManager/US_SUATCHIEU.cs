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
    public partial class US_SUATCHIEU : UserControl
    {
        public US_SUATCHIEU()
        {
            InitializeComponent();
            flowLayoutPanel1.Visible = false;
         
            //fr.Height = 100;
        }
        private string tenphim;
        private string loaiphim;
        private int thoiluong;
        private Image poster;
        private int maphim;
        private int maphong;
        private DateTime time;
        string phong = "Phòng ";

        public string Tenphim {
            get { return tenphim; }
            set { tenphim = value;LBtenphim.Text = value; }
        }
        public string Loaiphim 
        {
            get { return loaiphim; }
            set { loaiphim = value; lbloaiphim.Text = value; } 
        }
        public int Thoiluong 
        {
            get {return thoiluong; }
            set { thoiluong = value; lbthoiluong.Text = Convert.ToString(value); } 
        }

        public Image Poster {
            get { return poster; }
            set { poster = value; pictureBox1.Image = value; } 
        }

        public int Maphim { get => maphim; set => maphim = value; }
        public int Maphong {
            get { return maphong; }
            set { maphong = value; lbphong.Text = phong+Convert.ToString(value); }
        }
        public DateTime Time { get => time; set => time = value; }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if(flowLayoutPanel1.Visible==false)
            {
                flowLayoutPanel1.Visible = true;
                //loadsuatchieu(Time,maphim,maphong);
              
            }else if(flowLayoutPanel1.Visible==true)
            {
                flowLayoutPanel1.Visible = false;
            }
           
        }
        //void loadsuatchieu(DateTime id,int maphim,int maphong)
        //{
        //    List<suatchieu> cl = new List<suatchieu>();
        //    cl = suatchieuDAO.Instance.LAYSUATCHIEU(id,maphim,maphong);
        //    Button btn;
        //    Label lb;
        //    foreach(suatchieu su in cl)
        //    {
        //        lb = new Label();
        //        lb.Text = "Ngày chiếu: ";
        //        btn = new Button();
        //        btn.Size = new Size(80, 50);
        //        btn.BackColor = Color.Bisque;
        //        btn.Text=su.thoigianchieu.ToString();
        //        btn.Click += BtnGhe_Click;
        //        flowLayoutPanel1.Controls.Add(btn);
        //    }
        //}
        private void BtnGhe_Click(object sender, EventArgs e)
        {
            //Button btnghe = (Button)sender;
            //TimeSpan suatchieu = TimeSpan.Parse(btnghe.Text);
            //frCHITIETSUATCHIEU ch = new frCHITIETSUATCHIEU(suatchieu,maphong,time,maphim);
            //ch.Show();



        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
