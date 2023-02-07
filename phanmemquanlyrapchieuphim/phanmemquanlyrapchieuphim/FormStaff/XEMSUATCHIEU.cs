using DevExpress.XtraEditors;
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

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class XEMSUATCHIEU : DevExpress.XtraEditors.XtraForm
    {
        public XEMSUATCHIEU(DateTime date1, int maphim)
        {
            InitializeComponent();
            Date3 = date1;
            //flsuatchieu.Visible = false;
            //loadsuatchieu(date1, Maphim);
            lbngaychieu.Text = date;
            LoadMatrix();
            label1.Text = date1.ToString();
            //txtngay.Text = DateTime.Now.ToString();
            //panel3.Height = 60;
        }
        #region Peoperties
        private List<List<Button>> matrix;

        private List<string> dateofweek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion

        DateTime date3;
       
        private Image poster;
        private string date;
        private string tenphim;
        private int maphim;
        string time;

        public Image Poster
        {
            get { return poster; }
            set { poster = value; pictureBox1.Image = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; lbngaychieu.Text = value; }
        }
        public string Tenphim
        {
            get { return tenphim; }
            set { tenphim = value; lbtenphim.Text = value; }
        }


        public int Maphim { get => maphim; set => maphim = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public DateTime Date3 { get => date3; set => date3 = value; }

        //public string Date3 { get => date3; set => date3 = value; }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button oldbtn = new Button() { Width = 0, Height = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight };
                    btn.Location = new Point(oldbtn.Location.X + oldbtn.Width + Cons.marign, oldbtn.Location.Y);

                    pnlngaythang.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldbtn = btn;
                }
                oldbtn = new Button() { Width = 0, Height = 0, Location = new Point(0, oldbtn.Location.Y + Cons.dateButtonHeight) };
            }
            setDefault();
        }
        int DateofMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                    break;
                default:
                    return 30; ;


            }
        }
        void AddNumberIntoMatrixByDate(DateTime date)
        {
            clearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            //int column =dateofweek.IndexOf(useDate.DayOfWeek.ToString());
            int line = 0;

            for (int i = 1; i < DateofMonth(date) + 1; i++)
            {
                int column = dateofweek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                btn.Click += btn_click;
                if (isEqualDate(useDate, date))
                {

                    btn.BackColor = Color.Yellow;
                }
                if (isEqualDate(useDate, Date3))
                {
                    btn.FlatAppearance.BorderColor = Color.Blue;
                    btn.FlatStyle = FlatStyle.Flat;
                    //break;
                }
                if (column == 6)
                {
                    line++;
                }
                useDate = useDate.AddDays(1);
            }
        }
        //public void wirte(DateTime date)
        //{
        //    return wirte(UpdMessageType.)
        //}
        private void btn_click(object sender, EventArgs e)
        {
            //clearMatrix();
            Button btn = (Button)sender;
            btn.Controls.Clear();
            string[] tach = dateTimePicker1.Text.Split('-');

            string ngsy = tach[1] + "/" + btn.Text + "/" + tach[2];
            string ngsy2 = btn.Text + "-" + tach[1] + "-" + tach[2];
            dateTimePicker1.Value = Convert.ToDateTime(ngsy);
            loadsuatchieu(ngsy2, Maphim);
            //if (btn.BackColor == Color.White)
            //{
            //    btn.BackColor = Color.Blue;

            //}
            //else if(btn.BackColor==Color.Blue)
            //{
            //    btn.BackColor = Color.White;
            //}
            //dateTimePicker1.Text = btn.Text + "-" + tach[1] + "-" + tach[2];
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }
        void clearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
            }
        }

        void loadsuatchieu(string date, int maphim)
        {
            flsuatchieu.Controls.Clear();
            List<Class> cl = new List<Class>();
            cl = suatchieuDAO.Instance.laysuatchieutheophim(date, maphim);
            us_suatchieu btn;
            Label lb;
            foreach (Class su in cl)
            {
                btn = new us_suatchieu();


                btn.Thoigian = su.thoigianchieu.ToString();
                btn.Tenrap = su.tenphong.ToString();
                btn.Maphong = su.Maphong;

                flsuatchieu.Controls.Add(btn);
                btn.Click += BtnGhe_Click;
            }

        }

        //void layphongtheosuatchieu(string time,int maphim,string date)
        //{
        //    List<phong> cl = new List<phong>();
        //    cl = phongDAO.Instance.Layphongtheosuatchieu(time,maphim,date);
        //    Button btn;
        //    Label lb;
        //    foreach (phong su in cl)
        //    {
        //        btn = new Button();
        //        btn.Size = new Size(80, 50);
        //        btn.BackColor = Color.Blue;
        //        btn.Text ="Phòng: " + su.Maphong.ToString();
        //        btn.ForeColor= Color.White;
        //        btn.Click += Btn_Click;
        //        lbphong.Controls.Add(btn);
        //    }
        //}

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] tach = btn.Text.Split(':');
            frDATVE FR = new frDATVE(time.ToString(), Convert.ToInt32(tach[1]), maphim, Convert.ToDateTime(date));
            FR.Show();
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            //lbphong.Controls.Clear();
            us_suatchieu BTN = (us_suatchieu)sender;
            time = BTN.Text;
            //layphongtheosuatchieu(BTN.Text, Maphim, lbngaychieu.Text);
            frDATVE FR = new frDATVE(time.ToString(), BTN.Maphong, maphim, Convert.ToDateTime(dateTimePicker1.Value));
            FR.ShowDialog();
        }

        void loadphong()
        {

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //if(flsuatchieu.Visible==false)
            //{
            //    flsuatchieu.Controls.Clear();
            //    panel3.Height = 171;
            //    flsuatchieu.Visible = true;

            //    loadsuatchieu(date,Maphim);
            //}
            //else
            //{
            //    panel3.Height = 60;
            //    flsuatchieu.Visible = false;
            //}

        }

        private void frXEMSUATCHIEU_Load(object sender, EventArgs e)
        {
            //lbngay.Text = dateNavigator1.EditValue.ToString();
            loadsuatchieu(date, Maphim);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateNavigator1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dateNavigator1.EditValue.ToString());
            //lbngay.Text = dateNavigator1.EditValue.ToString();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        void setDefault()
        {
            dateTimePicker1.Value = Convert.ToDateTime(Date3);
            //txtngay.Text = dateTimePicker1.Text;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
            //dateNavigator1.EditValue =dateTimePicker1.Value.ToString();
        }

        private void dateNavigator1_Click_1(object sender, EventArgs e)
        {
            //loadsuatchieu(calendarControl1.Text, Maphim);
            //Message ms = new Message();
            //alertControl1.Show(this, "Thông báo", calendarControl1.Text+maphim, "", Properties.Resources.icons8_logout_96, ms);
            //alertControl1.Show(thongbao);
        }

        private void calendarControl1_Click(object sender, EventArgs e)
        {
            //loadsuatchieu(dateTimePicker1.Text.ToString(), Maphim);
            //Message ms = new Message();
            //alertControl1.Show(this, "Thông báo", calendarControl1.EditValue.ToString() + maphim, "", Properties.Resources.icons8_logout_96, ms);
            ////alertControl1.Show(thongbao);
            //calendarControl1.EditValue = date;
            //    dateTimePicker1.Text = lbngaychieu.Text;
            //    calendarControl1.EditValue = dateTimePicker1.Value;
            //    Message ms = new Message();
            //    alertControl1.Show(this, "Thông báo", calendarControl1.EditValue.ToString(), "", Properties.Resources.icons8_logout_96, ms);
        }

        private void calendarControl1_EditValueChanged(object sender, EventArgs e)
        {

            //dateTimePicker1.Text = lbngaychieu.Text;
            //calendarControl1.EditValue = dateTimePicker1.Value;
            //Message ms = new Message();
            //alertControl1.Show(this, "Thông báo", calendarControl1.EditValue.ToString(), "", Properties.Resources.icons8_logout_96, ms);
        }

        private void calendarControl1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void calendarControl1_VisibleChanged(object sender, EventArgs e)
        {
            //dateTimePicker1.Text = lbngaychieu.Text;
            //calendarControl1.EditValue = dateTimePicker1.Value;
            //Message ms = new Message();
            //alertControl1.Show(this, "Thông báo", calendarControl1.EditValue.ToString(), "", Properties.Resources.icons8_logout_96, ms);
        }

        private void flsuatchieu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnthangsau_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(1);
        }

        private void btnthangtruoc_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setDefault();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void XEMSUATCHIEU_Load(object sender, EventArgs e)
        {

        }

        private void pnlngaythang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flsuatchieu_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}