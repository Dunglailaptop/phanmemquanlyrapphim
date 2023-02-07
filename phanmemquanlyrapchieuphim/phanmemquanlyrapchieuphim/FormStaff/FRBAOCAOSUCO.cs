using DevExpress.XtraEditors;
using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
//using System.Windows.Controls.ComboBox;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public partial class FRBAOCAOSUCO : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FRBAOCAOSUCO()
        {
            InitializeComponent();
            loaddssuco();
            loaddsphong();
            loaddsbaocao();
        }
        string imgLocation = "";
        int idmaloai,idmaphong,idmaghe;
        bool updateghe;
        void loaddssuco()
        {
            comboBox2.DataSource = db.loaihonghocs.ToList();
            comboBox2.DisplayMember = "tenloai";
        }
        void loaddsphong()
        {
            comboBox3.DataSource = db.phongs.ToList();
            comboBox3.DisplayMember = "tenphong";
        }
        void loaddsbaocao()
        {
            gridControl1.DataSource = honghocDAO.Instance.showbaocao();
            dsbaocao.OptionsBehavior.Editable = false;
        }
        void loaddsghe(int maphong)
        {
            comboBox1.DataSource = honghocDAO.Instance.ghehong(maphong);
            comboBox1.DisplayMember = "Row";
            
           
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.Text == "hỏng ghế")
            {
                panel1.Visible = true;
                updateghe = true;
            }
            else
            {
                updateghe = false;
                ComboBox cb = sender as ComboBox;
                if (cb.SelectedItem == null)
                    return;

                loaihonghoc selected = cb.SelectedItem as loaihonghoc;
                idmaloai = selected.Maloai;
                panel1.Visible=false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            phong selected = cb.SelectedItem as phong;
            idmaphong = selected.Maphong;
            loaddsghe(idmaphong);
           
            //panel1.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }
        public Image convertbytetoimage(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] images = null;
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(stream);
                images = br.ReadBytes((int)stream.Length);

                if (honghocDAO.Instance.insertsuco(images, txttieude.Text.ToString(), richTextBox1.Text, idmaloai))
                {
                    MessageBox.Show("ok");

                }
                if (updateghe == true)
                {

                    if (honghocDAO.Instance.insertghehong(idmaphong, idmaghe))
                    {
                        MessageBox.Show("cap nhat ghế thành công");
                    }
                }
            }catch
            {
                MessageBox.Show("lỗi");
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

            ghe selected = cb.SelectedItem as ghe;
            idmaghe = selected.Maghe;
            //MessageBox.Show(idmaghe.ToString());
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}