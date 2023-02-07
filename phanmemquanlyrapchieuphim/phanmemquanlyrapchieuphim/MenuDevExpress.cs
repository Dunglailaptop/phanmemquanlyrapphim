using DevExpress.XtraBars;
using phanmemquanlyrapchieuphim.FormManager;
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
    public partial class MenuDevExpress : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MenuDevExpress()
        {
            InitializeComponent();
        }
        private string hoten;
        void openchild(Type typeForm)
        {
            foreach (Form form in MdiChildren)
            {
                if(form.GetType()==typeForm)
                {
                    form.Activate();
                    return;
                }    
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; barStaticItem1.Caption = value; }
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            frQUANLYPHIM QP = new frQUANLYPHIM();
            QP.MdiParent = this;
            QP.Show();
        }

        private void btn_qlphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYSUATCHIEUPHIM));
            //frQLSUATCHIEU QP = new frQLSUATCHIEU();
            //QP.MdiParent = this;
            //QP.Show();
        }

        private void ql_suatchieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYFOOD));
        }

        private void QL_pchieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(FrQUANLYPHONG));
            //FrQUANLYPHONG op = new FrQUANLYPHONG();
            //op.MdiParent = this;
            //op.Show();
        }

        private void barStaticItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void MenuDevExpress_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
            DANGNHAP dn = new DANGNHAP();
            dn.ShowDialog();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(FrQUANLYPHONG));
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frthongke));
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(FRQUANLYKHACHHANG));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYKHUYENMAI));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYNHANVIEN));
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYHOADONVE));
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            openchild(typeof(frQUANLYHOADONFOOD));
        }
    }
}