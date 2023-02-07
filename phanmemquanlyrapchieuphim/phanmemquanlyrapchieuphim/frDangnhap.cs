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

namespace phanmemquanlyrapchieuphim
{
    public partial class frDangnhap : DevExpress.XtraEditors.XtraForm
    {
        public frDangnhap()
        {
            InitializeComponent();
        }

        private void frDangnhap_Load(object sender, EventArgs e)
        {
            //textBox1.Text = "Username";
            //textBox2.Text = "Password";
           

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    textBox2.Text = "Password";
            //}
            //textBox1.Text = "";

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            //if (textBox2.Text == "")
            //{
            //    textBox1.Text = "Username";
            //}
            //textBox2.Text = "";

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string username=textBox1.Text;
            string password=textBox2.Text;
            if(login(username, password))
            {
                Class list = AccountDAO.Instance.phanquyen(username, password);
                if (list.tenchucvu == "Quanly")
                {
                    MessageBox.Show("Đăng nhập quản lý thành công");
                    //this.Close();
                    this.Hide();
                    MenuDevExpress mn = new MenuDevExpress();
                    mn.Hoten = list.hoten;
                    //mn.Hide();
                    mn.ShowDialog();
                    this.Show();
                }
                else if (list.tenchucvu == "nhanvien")
                {
                    MessageBox.Show("Đăng nhập nhân viên thành công");
                    this.Hide();
                    MenuStaffdev mn = new MenuStaffdev();
                    mn.Hoten = list.hoten;
                    mn.ShowDialog();
                    this.Show();
                }


            }
            else
            {
                MessageBox.Show("ten dang nhap hoac mat khau sai");
            }
        }
        bool login(string username,string password)
        {
            return AccountDAO.Instance.login(username,password);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string username = textEdit1.Text;
            string password= textEdit2.Text;
            //string password = textEdit2.Text;
            if (login(username, password))
            {
                Class list = AccountDAO.Instance.phanquyen(username, password);
                if (list.tenchucvu == "Quanly")
                {

                    MessageBox.Show("Đăng nhập quản lý thành công");
                    this.Hide();
                    MenuDevExpress mn = new MenuDevExpress();
                    mn.Hoten = list.hoten;

                    mn.ShowDialog();
                    this.Show();
                    //this.Dispose();
                }
                else if (list.tenchucvu == "nhanvien")
                {
                    MessageBox.Show("Đăng nhập nhân viên thành công");
                    //WaitForm1 wait = new WaitForm1();
                    //wait.ShowDialog();
                    //wait.Dispose();
                    this.Hide();
                    MenuStaffdev mn = new MenuStaffdev();
                    //mn.Hoten = list.hoten;

                    //mn.Hide();
                    mn.ShowDialog();
                    this.Show();
                    //this.Dispose();
                    //this.Show();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textEdit1.Text = textBox1.Text;
            textEdit2.Text = textBox2.Text;
            //string password = textEdit2.Text;
            if (login(textEdit1.Text, textEdit2.Text))
            {
                Class list = AccountDAO.Instance.phanquyen(textEdit1.Text, textEdit2.Text);
                if (list.tenchucvu == "Quanly")
                {

                    MessageBox.Show("Đăng nhập quản lý thành công");
                    this.Hide();
                    MenuDevExpress mn = new MenuDevExpress();
                    mn.Hoten = list.hoten;

                    mn.ShowDialog();
                    this.Show();
                    //this.Dispose();
                }
                else if (list.tenchucvu == "nhanvien")
                {
                    MessageBox.Show("Đăng nhập nhân viên thành công");
                    //WaitForm1 wait = new WaitForm1();
                    //wait.ShowDialog();
                    //wait.Dispose();
                    this.Hide();
                    MenuStaffdev mn = new MenuStaffdev();
                    //mn.Hoten = list.hoten;

                    //mn.Hide();
                    mn.ShowDialog();
                    this.Show();
                    //this.Dispose();
                    //this.Show();
                }
            }
        }
    }
}
