using DevExpress.Utils;
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
//using System.Windows.Controls.ComboBox;
using ComboBox = System.Windows.Forms.ComboBox;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class FRTHEMSUATCHIEUPHIM : DevExpress.XtraEditors.XtraForm
    {
        DateTimePicker dtp;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FRTHEMSUATCHIEUPHIM()
        {
            InitializeComponent();
            loaddata(dateTimePicker2.Value,idmaphim,dateTimePicker3.Value);
            loadtenphim();
            loadphong();
            loadtenphim2();
            adddatetimepicker();
            _check(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            thoigian.Text = timeEdit1.Text;
            gia.Text = textEdit1.Text;
        }
        int idmaphim;
        int idmaphim2;
        int idmaphong;
        bool tab1;
        bool tab2;
        void loaddata(DateTime DATE1,int maphim,DateTime date2)
        {
            dataGridViewleft.DataSource = db.USP_LAYSUATCHIEU2(maphim,DATE1,date2).ToList();
        }
        void loadtenphim()
        {
            cbtenphim.DataSource = phimDAO.Instance.LAYTENPHIM();
            cbtenphim.DisplayMember = "Tenphim";
        }
        void loadtenphim2()
        {
            comboBox1.DataSource = phimDAO.Instance.LAYTENPHIM();
            comboBox1.DisplayMember = "Tenphim";
        }
        void loadphong()
        {
            cbphongchieu.DataSource = phongDAO.Instance.loadphong();
            cbphongchieu.DisplayMember = "Maphong";
        }
        void adddatetimepicker()
        {
            dtp = new DateTimePicker();
            dtp.CustomFormat = "dd-MM-yyyy";
            dtp.Format = DateTimePickerFormat.Custom;
           
            dtp.Visible=false;
            dtp.Width = 125;
            dataGridViewright.Controls.Add(dtp);

            dtp.ValueChanged +=this.dtp_ValueChanged;
            dataGridViewright.CellBeginEdit += this.dataGridViewright_CellBeginEdit;
            dataGridViewright.CellEndEdit +=this.dataGridViewright_CellEndEdit;

        }
        //void themsuat(int maphong, int maphim, DateTime ngaychieu, string time, float giave)
        //{
        //    suatchieuDAO.Instance.inesrt(maphong, maphim, ngaychieu, time, giave);
        //}
        void _check(bool ck)
        {
            btnthem.Enabled = !ck;
            btnsua.Enabled = !ck;
            btnxoa.Enabled = !ck;
            btnhuy.Enabled = !ck;
            btnluu.Enabled = !ck;
        }
        private void dataGridViewleft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnright_Click(object sender, EventArgs e)
        {
           
;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridViewright.Rows.Clear();
            //loaddata();
            //foreach()
            foreach (DataGridViewRow row in dataGridViewleft.Rows)
            {
                bool isselected = Convert.ToBoolean(row.Cells[0].Value);
                if(isselected)
                {
                    //for(int i=1;i<=dataGridViewleft.RowCount;i++)
                    //{
                    dataGridViewright.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
                    //}
                    
                }
            }
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
          
        }

        private void FRTHEMSUATCHIEUPHIM_Load(object sender, EventArgs e)
        {
            
            //TabControl tb = new TabControl();
            //if()
            //{

            //}
        }

        private void cbtenphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbphim.Text = cbtenphim.Text;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phim selected = cb.SelectedItem as phim;
            tenp.Text = selected.Tenphim;
            idmaphim = selected.Maphim;
        }

        private void cbphongchieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbphong.Text = cbphongchieu.Text;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phong selected = cb.SelectedItem as phong;
            phong.Text = selected.tenphong;
            idmaphong = selected.Maphong;
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _check(true);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }
       
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            //MessageBox.Show(timeEdit1.Text);
            //TimeSpan suatchieu =TimeSpan.Parse(dateTimePicker2.Text);
            if(tab2==true)
            {
                try
                {
                    if (suatchieuDAO.Instance.inesrt(idmaphong, idmaphim, dateTimePicker1.Value, timeEdit1.Text, float.Parse(textEdit1.Text))) 
                    {
                        MessageBox.Show("Thêm suất chiếu thành công");
                        this.Close();
                    }else
                    {
                        MessageBox.Show("suat chieu da ton tai");
                    }
                    //themsuat();
                   
                }
                catch
                {
                    MessageBox.Show("thêm thất bại");
                }
            }else if(tab1==true)
            {
                try
                {
                    for (int i=0;i<dataGridViewright.RowCount;i++)
                    {
                    DataGridViewRow ROW = dataGridViewright.Rows[i];
                        if (suatchieuDAO.Instance.inesrt(int.Parse(ROW.Cells[2].Value.ToString()), idmaphim2, Convert.ToDateTime(ROW.Cells[1].Value.ToString()), ROW.Cells[0].Value.ToString(), float.Parse(ROW.Cells[3].Value.ToString())))
                        {
                            MessageBox.Show("Thêm suất chiếu thành công");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("suat chieu da ton tai");
                        }
                        //themsuat();
                      
                        
                   
                    }
                    //MessageBox.Show("Thêm danh sách suất chiếu thành công");
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("thêm danh sách thất bại");
                }
            }
          

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phim selected = cb.SelectedItem as phim;
            idmaphim2 = selected.Maphim;
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value); 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewleft_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridViewright.Rows.Clear();
            ////loaddata();
            //foreach (DataGridViewRow row in dataGridViewright.Rows)
            //{
            //    bool isselected = Convert.ToBoolean(row.Cells[3].Value);
            //    if (isselected)
            //    {
            //        dataGridViewright.Rows.RemoveAt(row.Index);
            //        //for(int i=1;i<=dataGridViewleft.RowCount;i++)
            //        //{
            //        //dataGridViewright.Rows.RemoveAt(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
            //        //}

            //    }
            //}
            for(int i=dataGridViewright.RowCount-1;i>=0;i--)
            {
                DataGridViewRow row = dataGridViewright.Rows[i];
                if (Convert.ToBoolean(row.Cells[4].Value))
                {
                    dataGridViewright.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void dataGridViewright_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((dataGridViewright.Focused) && (dataGridViewright.CurrentCell.ColumnIndex==1))
                {
                    dtp.Location = dataGridViewright.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtp.Visible = true;
                if (dataGridViewright.CurrentCell.Value != null)
                {
                    string d = "14-12-2023";
                        dtp.Value =/* Convert.ToDateTime(dataGridViewright.CurrentCell.Value)*//*;*/ DateTime.Today; //*;
                }
                else
                {
                    dtp.Value = DateTime.Today;
                }
            }
            else
                {
                    dtp.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:");
            }
        }

        private void dataGridViewright_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((dataGridViewright.Focused) && (dataGridViewright.CurrentCell.ColumnIndex == 1))
                {
                    dataGridViewright.CurrentCell.Value = dtp.Value.Date;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:" + ex);
            }
        }
        private void dtp_ValueChanged(Object sender,EventArgs e)
        {
            dataGridViewright.CurrentCell.Value=dtp.Text;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[1])//your specific tabname
            {
                tab1 = true;
                tab2 = false;
            }else if(xtraTabControl1.SelectedTabPage == xtraTabControl1.TabPages[0])
            {
                tab2 = true;
                tab1 = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value);
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phim selected = cb.SelectedItem as phim;
            idmaphim2 = selected.Maphim;
            loaddata(dateTimePicker2.Value, idmaphim2, dateTimePicker3.Value);
        }

        private void dataGridViewright_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewleft_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Ngaychieu.Text = dateTimePicker1.Text;

        }

        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {
            thoigian.Text = timeEdit1.Text;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gia.Text = textEdit1.Text;
            //giave
        }
    }
}