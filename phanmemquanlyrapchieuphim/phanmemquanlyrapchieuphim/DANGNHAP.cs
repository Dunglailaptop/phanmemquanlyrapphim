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
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;

namespace phanmemquanlyrapchieuphim
{
    public partial class DANGNHAP : DevExpress.XtraEditors.XtraForm
    {

        public DANGNHAP()
        {
           
           
            InitializeComponent();
        }
        bool login(string username, string password)
        {
            return AccountDAO.Instance.login(username, password);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string username = textEdit1.Text;
            string password = textEdit2.Text;
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
                    //this.Show();
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
                    mn.Idnhanvien = list.manv;
                    //mn.Hide();
                    mn.ShowDialog();
                    //this.Show();
                    //this.Dispose();
                    //this.Show();
                }
            }
            else
            {
                MessageBox.Show("sai tên đăng nhập hoặc mật khẩu vui lòng kiểm tra lại");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //string username = textEdit1.Text;
            //string password = textEdit2.Text;
            //if (login(username, password))
            //{
            //    Class list = AccountDAO.Instance.phanquyen(username, password);
            //    if (list.tenchucvu == "Quanly")
            //    {
            //        MessageBox.Show("Đăng nhập quản lý thành công");
            //        this.Dispose();
            //        MenuDevExpress mn = new MenuDevExpress();
            //        mn.Hoten = list.hoten;
            //        //mn.Hide();
            //        mn.ShowDialog();
            //    }
            //    else if (list.tenchucvu == "nhanvien")
            //    {
            //        MessageBox.Show("Đăng nhập nhân viên thành công");

            //        MenuStaff mn = new MenuStaff();
            //        mn.Hoten = list.hoten;
            //        this.Hide();
            //        //mn.Hide();
            //        mn.ShowDialog();
            //        this.Show();
            //    }
            //}
        }

        private void DANGNHAP_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textEdit1.Text;
            string password = textEdit2.Text;
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
                    //this.Show();
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
                    //this.Show();
                    //this.Dispose();
                    //this.Show();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frQUENMATKHAU QL = new frQUENMATKHAU();
            QL.ShowDialog();
        }
    }
}