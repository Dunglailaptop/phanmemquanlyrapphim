using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using webtnonline.Models;
using phanmemquanlyrapchieuphim.DAO;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frQUENMATKHAU : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frQUENMATKHAU()
        {
            InitializeComponent();
        }
        void guimail(string from,string to, string subject,string message)
        {
            MailMessage mess = new MailMessage(from,to,subject,message);
            SmtpClient client=new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ndung983@gmail.com", "gnezzvtsarhtukhr");
            client.Send(mess);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string f = "ndung983@gmail.com";
                string tittle = "cap lai mat khau";
                Random r = new Random();
                string HD = "CL";
                hoadon hd = new hoadon();

                string manv = crypt.Encrypt(HD.Trim() + r.Next().ToString(), true);

                account ac = db.accounts.Where(x => x.Username == textEdit1.Text).SingleOrDefault();
                if (ac != null)
                {
                    MessageBox.Show("đã tìm thấy");
                    nhanvien nv = db.nhanviens.Where(x => x.Manhanvien == ac.Manhanvien).SingleOrDefault();
                    if (nv != null)
                    {
                        guimail(f, nv.Email, tittle, manv);
                        if (AccountDAO.Instance.quenmatkhau(manv))
                        {
                            this.Dispose();
                            MessageBox.Show("gửi thành công");
                            frQUENMATKHAU2 mk = new frQUENMATKHAU2();
                            mk.Ten = ac.Username;
                            mk.ShowDialog();
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
            //panelControl1.Visible = true;
           
        }
    }
}