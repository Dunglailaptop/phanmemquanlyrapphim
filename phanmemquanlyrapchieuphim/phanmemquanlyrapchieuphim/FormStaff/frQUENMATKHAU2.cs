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

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class frQUENMATKHAU2 : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frQUENMATKHAU2()
        {
            InitializeComponent();
        }
        private string ten;

        public string Ten { get => ten; set => ten = value; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            quenmatkhau qmk = db.quenmatkhaus.Where(x => x.Macaplai == textEdit1.Text).SingleOrDefault();
            if(qmk!=null)
            {
                this.Dispose();
                frSUAMK SMK = new frSUAMK();
                SMK.TEN1 = ten;
                SMK.ShowDialog();
            }
        }
    }
}