using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
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
using ComboBox = System.Windows.Forms.ComboBox;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class themsuat : DevExpress.XtraEditors.XtraForm
    {
        int idmaphim2=0;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public themsuat()
        {
            InitializeComponent();
            loadtenphim();
            loaddata(dateTimePicker1.Value, idmaphim2, dateTimePicker2.Value);
        }
        void loaddata(DateTime DATE1, int maphim, DateTime date2)
        {
            gridControleft.DataSource = db.USP_LAYSUATCHIEU2(maphim, DATE1, date2).ToList();
        }
        void loadtenphim()
        {
            cbtenphim.DataSource = phimDAO.Instance.LAYTENPHIM();
            cbtenphim.DisplayMember = "Tenphim";
        }
        private void themsuat_Load(object sender, EventArgs e)
        {

        }

        private void cbtenphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phim selected = cb.SelectedItem as phim;
            idmaphim2 = selected.Maphim;
            loaddata(dateTimePicker1.Value, idmaphim2, dateTimePicker2.Value);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //foreach (DataGridView row in gridControleft.Controls)
            //{
            //    bool check = Convert.ToBoolean(row.SelectedCells[0].Value);
            //    if (check)
            //    {
            //        gridView1.SetRowCellValue(1, "Ngaychieu", row.SelectedCells[1].Value);
            //    }
            //}

        }
    }
}