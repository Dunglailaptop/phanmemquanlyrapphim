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
    public partial class frSUAMK : DevExpress.XtraEditors.XtraForm
    {
        private string TEN;
        public frSUAMK()
        {
            InitializeComponent();
        }

        public string TEN1 {
            get {return TEN; }
            set { TEN = value;textEdit1.Text = value; } 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text !=null)
            {
                if (AccountDAO.Instance.updateaccout(TEN,textEdit2.Text))
                {
                    MessageBox.Show("sửa thành công");
                    this.Dispose();
                }
            }
        }
    }
}