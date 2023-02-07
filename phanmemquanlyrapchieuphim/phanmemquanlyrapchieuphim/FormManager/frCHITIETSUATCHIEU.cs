using phanmemquanlyrapchieuphim.DAO;
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
    public partial class frCHITIETSUATCHIEU : DevExpress.XtraEditors.XtraForm
    {
       
        public frCHITIETSUATCHIEU(string tg,int maphong,DateTime date,int maphim)
        {
            InitializeComponent();
           
            laychitietsuatchieu(tg,maphong,maphim,date);
            //showghe(8, 16);
           
        }
        Label lbmaphim = new Label();
        Label lbtest;
        int ghedat = 0;
        void laychitietsuatchieu(string tg,int maphong,int maphim,DateTime date)
        {
            //TimeSpan cast = TimeSpan.Parse(tg);
            Class c = suatchieuDAO.Instance.laychitietsuatchieu(tg,maphong,maphim,date);
         
          
                lbtenphim.Text = c.tenphim;
                lbngaychieu.Text = Convert.ToString(c.date);
                lbphongchieu.Text = Convert.ToString(c.Maphong);
                lbgiave.Text = Convert.ToString(c.giave);
                lbsuatchieu.Text = Convert.ToString(c.thoigianchieu);
                lbtongghe.Text = Convert.ToString(c.tongghe);
                lbmaphim.Visible = false;
                lbmaphim.Text=Convert.ToString(c.maphim);
            //laydsghedadat(tg,c.date,c.maphim, c.Maphong);
            //string time = "20:30:0";
            //string datt = "2022-08-12";
            layallghe(tg, c.date, c.maphim, c.Maphong);

        }
        void layallghe(string tg, DateTime date, int maphim, int maphong)
        {
            List<Class> cs = suatchieuDAO.Instance.layallghe(maphong, tg, date, maphim);
            List<Class> CSs = suatchieuDAO.Instance.laydsghedadat(maphong, tg, date, maphim);
            int x=5, y = 50, khoangcachx = 80, khoangcachy = 55, dem = 1;
            Button btnghe;
           

                foreach (Class c2 in cs)
            {

                //for (int i = 0; i < dong; i++)
                //{
                //x = 20;
                //for (int j = 0; j < cot; j++)
                //{

                btnghe = new Button();
                        btnghe.Location = new Point(x, y);
                        btnghe.Size = new Size(50, 40);
                        //foreach (Class c2 in CS)
                        //{
                        //string check = c2.row + c2.soghe.ToString();
                        string text = "A" + dem;
                        btnghe.Text = c2.row.ToString();

                btnghe.BackColor = Color.White;
               






                //lbtest.Visible = false;



                //btnghe.Click += BtnGhe_Click;
                pnlghe.Controls.Add(btnghe);
                dem++;
                if (dem == 17)
                {
                    y += khoangcachy;
                    //khoangcachx = 100;
                    x = -74;
                    dem = 1;
                }
                //}
                //y += khoangcachy;
                x += khoangcachx;
                    //}
                    
                //}
            }
            foreach (Button ghe in pnlghe.Controls)
            {
                foreach (Class cc in CSs)
                {
                    if (ghe.Text == cc.row2)
                    {
                        ghe.BackColor = Color.Red;
                        ghedat++;
                    }
                    //else
                    //{
                    //    ghe.BackColor = Color.White;
                    //}
                }
            }
            lbdaghe.Text = Convert.ToString(ghedat);
            int tongghe = Convert.ToInt32(lbtongghe.Text); 
             int ghedadat=   Convert.ToInt32(ghedat);
            int tongla = tongghe - ghedadat;
            lbtrong.Text = Convert.ToString(tongla);
        }
        void laydsghedadat(string tg,DateTime date, int maphim,int maphong)
        {
           
            
            List<Class> CS = suatchieuDAO.Instance.laydsghedadat(maphong, tg,date ,maphim);
            foreach (Class c2 in CS)
            {
                lbtest = new Label();
                 string Text = Convert.ToString(c2.row);
                string checkghe = Text + c2.soghe.ToString();
                lbtest.Text=checkghe;
                //lbtest.Visible = false;
            }

        }
        void showghe(int dong,int cot)
        {
           
                int x, y = 10, khoangcachx = 65, khoangcachy = 50, dem = 1;
                Button btnghe;
                for (int i = 0; i < dong; i++)
                {
                    x = 10;
                    for (int j = 0; j < cot; j++)
                    {
                    
                        btnghe = new Button();
                        btnghe.Location = new Point(x, y);
                        btnghe.Size = new Size(50, 40);
                    //foreach (Class c2 in CS)
                    //{
                        //string check = c2.row + c2.soghe.ToString();
                        string text = "A" + dem;
                        btnghe.Text = text.ToString();
                    if (btnghe.Text == lbtest.Text)
                    {
                        btnghe.BackColor = Color.Red;
                    }
                    btnghe.BackColor = Color.White;
                        //btnghe.Click += BtnGhe_Click;
                        pnlghe.Controls.Add(btnghe);
                        dem++;
                        if (dem > 16)
                        {
                            dem = 1;
                        }
                    //}
                        x += khoangcachx;
                    }
                    y += khoangcachy;
                }
            
        
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frCHITIETSUATCHIEU_Load(object sender, EventArgs e)
        {

        }

        private void lbgiave_Click(object sender, EventArgs e)
        {

        }
    }
}
