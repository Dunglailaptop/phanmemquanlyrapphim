using DevExpress.XtraBars;
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
    public partial class MenuSatff : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MenuSatff()
        {
            InitializeComponent();
        }
        void openchild(Type typeForm)
        {
            foreach (Form form in MdiChildren)
            {
                if (form.GetType() == typeForm)
                {
                    form.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(DATVEXEM));
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frDATDOAN));
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(FRBAOCAOSUCO));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(FR_NHAPTIENMAY));
        }
    }
}