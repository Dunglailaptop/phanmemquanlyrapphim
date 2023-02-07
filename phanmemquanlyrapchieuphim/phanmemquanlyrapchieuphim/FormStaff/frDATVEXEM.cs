using phanmemquanlyrapchieuphim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phanmemquanlyrapchieuphim.DTO;
using System.IO;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frDATVEXEM : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frDATVEXEM()
        {
            InitializeComponent();
            listusercontroll(dateTimePicker1.Value);
            loaddmtheloai();
        }
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        void loaddmtheloai()
        {
            List<theloai> tl=new List<theloai>();
            tl = db.theloais.ToList();
            Button btn;
            foreach(theloai t in tl)
            {
                btn = new Button();
                btn.Size = new Size(435, 94);
                btn.BackColor = Color.DodgerBlue;
               
                float size = 25;
                 size=btn.Font.Size;
                btn.ForeColor = Color.White;
                btn.Text = t.tentheloai;
                btn.Tag = t.Matheloai;
                btn.Dock = DockStyle.Top;
                panel3.Controls.Add(btn);
                btn.Click += Click_btn;
            }
        }

        private void Click_btn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            flowLayoutPanel1.Controls.Clear();
            listusercontroll2(dateTimePicker1.Value,int.Parse(btn.Tag.ToString()));
        }

        void listusercontroll(DateTime date)
        {
            List<phim> phi = phimDAO.Instance.laydsphimdangchieu(date);
            US_DSPHIM user;
            //for (int i = 0; i < 1; i++)
            //{
                foreach (phim p in phi)
                {
                    user = new US_DSPHIM();
                    user.Tenphim = p.Tenphim.ToString();
                    user.Image = convertbytetoimage(p.poster.ToArray());
                    user.Date = p.Namphathanh;
                    user.Maphim = p.Maphim;
                flowLayoutPanel1.Controls.Add(user);
                user.Click += userControl_hover;
            }
           
                //user =new US_DSPHIM();
               
            
        }
        void listusercontroll2(DateTime date,int theloai)
        {
            List<phim> phi = phimDAO.Instance.laydsphimdangchieuBYTHELOAI(date,theloai);
            US_DSPHIM user;
            //for (int i = 0; i < 1; i++)
            //{
            foreach (phim p in phi)
            {
                user = new US_DSPHIM();
                user.Tenphim = p.Tenphim.ToString();
                user.Image = convertbytetoimage(p.poster.ToArray());
                user.Date = p.Namphathanh;
                user.Maphim = p.Maphim;
                flowLayoutPanel1.Controls.Add(user);
                user.Click += userControl_hover;
            }

            //user =new US_DSPHIM();


        }
        void timkiem(DateTime date, string theloai)
        {
            List<phim> phi = phimDAO.Instance.TIMKIEMPHIM(date, theloai);
            US_DSPHIM user;
            //for (int i = 0; i < 1; i++)
            //{
            foreach (phim p in phi)
            {
                user = new US_DSPHIM();
                user.Tenphim = p.Tenphim.ToString();
                user.Image = convertbytetoimage(p.poster.ToArray());
                user.Date = p.Namphathanh;
                user.Maphim = p.Maphim;
                flowLayoutPanel1.Controls.Add(user);
                user.Click += userControl_hover;
            }

            //user =new US_DSPHIM();


        }
        void userControl_hover(object sender, EventArgs e)
        {
            US_DSPHIM US = (US_DSPHIM)sender;
            string tach = dateTimePicker1.Text.ToString();
            frXEMSUATCHIEU fr = new frXEMSUATCHIEU(dateTimePicker1.Value,US.Maphim);
            fr.Tenphim = US.Tenphim;
            fr.Poster = US.Image;
           
            fr.Date = tach;
            MessageBox.Show(fr.Date);
            fr.Maphim=US.Maphim;
            fr.Show();
        }

        private void frDATVEXEM_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listusercontroll(dateTimePicker1.Value);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            timkiem(dateTimePicker1.Value, textBox1.Text);
        }

        private void flowLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
