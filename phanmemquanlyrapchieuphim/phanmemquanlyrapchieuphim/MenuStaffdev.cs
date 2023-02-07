using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.FormStaff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemquanlyrapchieuphim
{
    public partial class MenuStaffdev : DevExpress.XtraEditors.XtraForm
    {
        private string idnhanvien;
        public MenuStaffdev()
        {
            InitializeComponent();
            //this.Text = String.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //panel5.Height = button1.Height;
            //panel5.Top = button1.Top;
            ////panel2.Height = 334;
            //button11.Image = button1.Image;
            //button11.Text = button1.Text;
            //panel3.Controls.Clear();

            //TRANGCHU nv = new TRANGCHU();
            ////panel2.Dock = DockStyle.None;
            //nv.TopLevel = false;
            //nv.Dock = DockStyle.Fill;
            //panel3.Controls.Add(nv);
            ////nv.loadphim();
            //nv.Show();
        }
        private string hoten;

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public string Idnhanvien { get => idnhanvien; set => idnhanvien = value; }

        private void button2_Click(object sender, EventArgs e)
        {

            //flowLayoutPanel2.Visible = false;
            //panel11.Visible = false;
            //panel12.Visible = false;
            //flowLayoutPanel2.Visible = false;
            //panel5.Height = button2.Height;
            //panel5.Top = button2.Top;
            ////panel2.Height = 61;
            //button11.Image = button2.Image;
            //button11.Text = button2.Text;
            //panel3.Controls.Clear();
            //frDATVEXEM nv = new frDATVEXEM();
            ////panel2.Dock = DockStyle.None;
            //nv.TopLevel =false;
            //nv.Dock = DockStyle.Fill;
            //panel3.Controls.Add(nv);
            ////nv.loadphim();
            //nv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel2.Visible = false;
            //panel5.Height = button3.Height;
            //panel5.Top = button3.Top;
            ////panel2.Height = 61;
            //button11.Image = button3.Image;
            //button11.Text = button3.Text;
            //panel3.Controls.Clear();
            //frDATDOAN nv = new frDATDOAN();
            ////panel2.Dock = DockStyle.None;
            //nv.TopLevel = false;
            //nv.Dock = DockStyle.Fill;
            //panel3.Controls.Add(nv);
            ////nv.loadphim();
            //nv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel3.Controls.Clear();
            //flowLayoutPanel2.Visible = true;
           
            //panel5.Height = button1.Height;
            //panel5.Top = button1.Top;
            ////panel2.Height = 334;
            //button11.Image = button1.Image;
            //button11.Text = button1.Text;
          

            //TRANGCHU nv = new TRANGCHU();
            ////panel2.Dock = DockStyle.None;
            //nv.TopLevel = false;
            //nv.Dock = DockStyle.Fill;
            //panel3.Controls.Add(nv);
            ////nv.loadphim();
            //nv.Show();
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void MenuStaffdev_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(800);
            splashScreenManager1.CloseWaitForm();
            frDangnhap dn = new frDangnhap();
            dn.Show();
            this.Dispose();
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel15_MouseClick(object sender, MouseEventArgs e)
        {
           
            //panel5.Height = button2.Height;
            //panel5.Top = button2.Top;
            ////panel2.Height = 61;
            //button11.Image = button2.Image;
            //button11.Text = button2.Text;
            //panel3.Controls.Clear();
         
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////flowLayoutPanel2.Visible = false;
            //panel5.Height = button4.Height;
            //panel5.Top = button4.Top;
            ////panel2.Height = 61;
            //button11.Image = button4.Image;
            //button11.Text = button4.Text;
            //panel3.Controls.Clear();
            //FR_NHAPTIENMAY nv = new FR_NHAPTIENMAY();
            ////panel2.Dock = DockStyle.None;
            //nv.TopLevel = false;
            //nv.Dock = DockStyle.Fill;
            //panel3.Controls.Add(nv);
            ////nv.loadphim();
            //nv.Show();
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel2.Visible = false;
            //panel5.Height = button5.Height;
            //panel5.Top = button5.Top;
            ////panel2.Height = 61;
            //button11.Image = button5.Image;
            //button11.Text = button5.Text;
            //panel3.Controls.Clear();
         
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pnlvexem_MouseClick(object sender, MouseEventArgs e)
        {
            //flowLayoutPanel2.Visible = false;
            //panel11.Visible = false;
            //panel12.Visible = false;
            ////flowLayoutPanel2.Visible = false;
            //panel5.Height = button2.Height;
            //panel5.Top = button2.Top;
            ////panel2.Height = 61;
            //button11.Image = button2.Image;
            //button11.Text = button2.Text;
            //panel3.Controls.Clear();
          
        }

        private void pnlthucan_MouseClick(object sender, MouseEventArgs e)
        {
            ////flowLayoutPanel2.Visible = false;
            //panel5.Height = button3.Height;
            //panel5.Top = button3.Top;
            ////panel2.Height = 61;
            //button11.Image = button3.Image;
            //button11.Text = button3.Text;
            //panel3.Controls.Clear();
           
        }

        private void pnlthuchi_MouseClick(object sender, MouseEventArgs e)
        {
            //flowLayoutPanel2.Visible = false;
            //panel5.Height = button4.Height;
            //panel5.Top = button4.Top;
            ////panel2.Height = 61;
            //button11.Image = button4.Image;
            //button11.Text = button4.Text;
            //panel3.Controls.Clear();
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            DANGNHAP dn = new DANGNHAP();
            //dn.Hide();
            dn.ShowDialog();
            WaitForm1 wait = new WaitForm1();
            wait.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FR_NHAPTIENMAY nv = new FR_NHAPTIENMAY();
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
            FRBAOCAOSUCO nv = new FRBAOCAOSUCO();
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
            DATVEXEM nv = new DATVEXEM();
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //simpleButton2.BackColor = Color.Yellow;
            panelControl1.Controls.Clear();
            frDATDOAN nv = new frDATDOAN();
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            DANGNHAP nv = new DANGNHAP();
            nv.ShowDialog();
            this.Dispose();

        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
            FR_NHAPTIENMAY nv = new FR_NHAPTIENMAY();
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Clear();
            FRQUANLYTHONGTINCANHAN nv = new FRQUANLYTHONGTINCANHAN(idnhanvien);
            //panel2.Dock = DockStyle.None;
            nv.TopLevel = false;
            nv.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(nv);
            //nv.loadphim();
            nv.Show();
        }
    }
}