using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.DAO;
using System.IO;
using DevExpress.XtraGrid;
using phanmemquanlyrapchieuphim.FormStaff;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class frQUANLYPHIM : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string imgLocation = "";
        int idtheloai = 0;
        int idquocgia = 0;
        bool _them;
        public frQUANLYPHIM()
        {
            InitializeComponent();
            loadphim();
            loadtheloai();
            loaiquocgia();
           
        }
        private Byte[] hinhanh;
        private int test;

        public byte[] Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value;} 
        }

        public int Test { get => test; set => test = value; }

        public void loadphim()
        {


            gridControl1.DataSource = phimDAO.Instance.loadphim();
            dsphim.OptionsBehavior.Editable = false;

        }
        void loadtheloai()
        {
            cbtheloai.DataSource = TheloaiphimDAO.Instance.loaddstheloai();
            cbtheloai.DisplayMember = "Tentheloai";
        }
        void gettheloaibyid(int id)
        {
            List<theloai> theloais = TheloaiphimDAO.Instance.gettheloaibyid(id);
            cbtheloai.DataSource = theloais;

        }
        void loaiquocgia()
        {
            List<quocgia> qg = QuocgiaDAO.Instance.Loaddsquocgia();
            cbquocgia.DataSource = qg;
            cbquocgia.DisplayMember = "tenquocgia";
        }
        void _check(bool chec)
        {
            btnthem.Enabled = !chec;
            btnsua.Enabled = !chec;
            btnxoa.Enabled = !chec;
            btnin.Enabled = !chec;
           
            btnhuy.Enabled = !chec;
            btnluu.Enabled = !chec;

        }
        void text(bool chec)
        {
            txttenphim.Enabled = !chec;
            txttacgia.Enabled = !chec;
            txtthoiluong.Enabled = !chec;
            txtmota.Enabled = !chec;
            cbloaiphim.Enabled = !chec;
            cbquocgia.Enabled = !chec;
            cbtheloai.Enabled = !chec;
            datetime.Enabled = !chec;
            btnhinhanh.Enabled = !chec;
        }
        void insertphim(string tenphim, string tacgia, int matheloai, int maquocgia, int thoiluong, DateTime namphathanh, byte[] poster, string mota, string loaiphim)
        {
            phimDAO.Instance.insertphim(tenphim, tacgia, matheloai, maquocgia, thoiluong, namphathanh, poster, mota, loaiphim);
        }
        void updatephim(int maphim, string tenphim, string tacgia, int matheloai, int maquocgia, int thoiluong, DateTime namphathanh, byte[] poster, string mota, string loaiphim)
        {
            phimDAO.Instance.updatephim(maphim, tenphim, tacgia, matheloai, maquocgia, thoiluong, namphathanh, poster, mota, loaiphim);
        }
        //private void F2_updateEventHandler(object sender, frXemchitietphim.UpdateEventArgs args)
        //{
        //    loadphim();
        //}
        //public static void DelegateMethod()
        //{
        //    loadphim();
        //}
        public Image convertbytetoimage(Byte[] data)
        { 
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex);
                return null;
                
            }
          
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frQUANLYPHIM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phanmemquanlyrapchieuphimDataSet.phim' table. You can move, or remove it, as needed.
            this.phimTableAdapter.Fill(this.phanmemquanlyrapchieuphimDataSet.phim);
            _check(true);
            text(true);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            //{

            //    int id = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            //    phim ph = phimDAO.Instance.poster(id);
            //    pictureBox1.Image = convertbytetoimage(ph.poster.ToArray());
            //    lbtenphim.Text = ph.Tenphim.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Hay click vao dong");
            //}
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            _check(false);
            
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            if(dsphim.GetFocusedRowCellValue("Maphim")!=null)
            {
                int id = int.Parse(dsphim.GetFocusedRowCellValue("Maphim").ToString());
                Class ph = phimDAO.Instance.showchitietphim(id);
                pictureBox1.Image = convertbytetoimage(ph.poster.ToArray());
                hinhanh = ph.poster;
                txttenphim.Text = ph.tenphim;
                txttacgia.Text = ph.tacgia;
                txtthoiluong.Text = Convert.ToString(ph.thoiluong);
                cbloaiphim.Text = ph.loaiphim;
                cbquocgia.Text = ph.tenquoc;
                cbtheloai.Text = ph.tentheloai.ToString();
                txtmota.Text = ph.mota;
                txtMaphim.Text = Convert.ToString(ph.maphim);
            }else
            {
                MessageBox.Show("lỗi rỗng");
            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        void indd(GridControl gir )
        {
            if(!gir.IsPrintingAvailable)
            {
                MessageBox.Show("faild");
                return;
            }
            gir.ShowPrintPreview();
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            indd(gridControl1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                if (imgLocation != null)
                {

                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    Hinhanh = br.ReadBytes((int)stream.Length);
                }
            }

        }

        private void btnthem_ItemClick(object sender, ItemClickEventArgs e)
        {
            _them = true;
            _check(true);
            text(false);
            txttenphim.Text = " ";
            txttacgia.Text = " ";
            txtmota.Text = " ";
            txtthoiluong.Text = " ";
            pictureBox1.Image = null;
            
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
           
        }

        private void cbquocgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            quocgia selected = cb.SelectedItem as quocgia;
            idquocgia = selected.Maquocgia;
        }

        private void cbtheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            theloai selected = cb.SelectedItem as theloai;
            idtheloai = selected.Matheloai;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {


            _check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            _check(false);
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            if (_them)
            {
                try
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    images = br.ReadBytes((int)stream.Length);
                    int thoilg = int.Parse(txtthoiluong.Text);
                    DateTime date = datetime.Value;
                    insertphim(txttenphim.Text, txttacgia.Text, idtheloai, idquocgia, thoilg, date, images, txtmota.Text, cbloaiphim.Text);
                    loadphim();
                    MessageBox.Show("Tạo thành công phim mới");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi: " + (ex.Message));
                }
            }else
            {
                try
                {

                    int thoilg = int.Parse(txtthoiluong.Text);
                    DateTime date = datetime.Value;
                    int maphim = Convert.ToInt32(txtMaphim.Text);
                    updatephim(maphim,txttenphim.Text,txttacgia.Text, idtheloai, idquocgia, thoilg, date, hinhanh, txtmota.Text, cbloaiphim.Text);
                    loadphim();
                    MessageBox.Show("Sửa thành công phim");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi: " + (ex.Message));
                }
            }
           
        }

        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {
            _them = false;
            _check(true);
            text(false);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnxoa_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete Yes/No", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (phimDAO.Instance.delete(int.Parse(txtMaphim.Text)))
                    {
                        MessageBox.Show("Xóa phim thành công");
                        loadphim();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                        loadphim();
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Phim đang tồn tại lịch chiếu");
                }
               
            }

        }

        private void txtMaphim_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbloaiphim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}