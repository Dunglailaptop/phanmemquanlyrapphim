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
using phanmemquanlyrapchieuphim.FormStaff;

namespace phanmemquanlyrapchieuphim.FormManager
{
    public partial class FrQUANLYPHONG : Form
    {
        private int id;
        int str;
        bool qlphong=false;
        bool themphong = true;
        bool xoaphong = false;
        bool suaphong = false;
        bool qlghe=false;
        bool themghe = false;
        bool suaghe = false;
        bool xoaghe = false;
        bool qlloaighe = false;
        bool themgloaighe = false;
        bool sualoaighe = false;
        bool xoaloaighe = false;
        //bool capnhatghe = false;
        int idmaloaighe ,idmaghe2;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public int Id { get => id; set => id = value; }

        public FrQUANLYPHONG()
        {
            InitializeComponent();
            loadphong();
            tongsoghe();
            //foreach (Control c in flowLayoutPanel1.Controls)
            //{
            //    if (c == null)
            //    {
            //        qlphong = true;
                  
            //        break;
            //        //themphong = true;
            //    }
            //    else
            //    {
            //        check(true);
            //        panel1.Visible = false;
            //        break;
            //    }
            //}
            check(true);
            panel1.Visible = false;
            //loaddmghe();
            //loadloaighetao();
            //loaddayghe();
            //loadloaighe();
            //khoitaosoghe(8,8);
            flowLayoutPanel2.Visible = false;
          
          
            //TAOGHE(1);
        }
        
        void loadloaighetao(int id)
        {
            cbloaighetao.DataSource = loaigheDAO.Instance.loadallloaighe(id);
            cbloaighetao.DisplayMember = "tenloai";
        }
        void loaddmghe(int id)
        {
            cbloaighe.DataSource = loaigheDAO.Instance.loadallloaighe(id);
            cbloaighe.DisplayMember = "tenloai";
        }
        void check(bool ck)
        {
            btnthem.Enabled = !ck;
            btnxoa.Enabled = !ck;
            btnluu.Enabled = !ck;
            btnhuy.Enabled = !ck;
            btnsua.Enabled = !ck;
        }
        void loadloaighe(int maphong,int gheofday)
        {
            flowLayoutPanel2.Controls.Clear();
            us_loaighe us;
            List<loaighe> lg = new List<loaighe>(); 
            lg=loaigheDAO.Instance.loadloaighe();
            foreach(loaighe g in lg)
            {
                us = new us_loaighe();
                us.Argb =g.mausac;
                us.Tenghe = g.tenloai;
                //us.Giave = (int)g.giaghe;
                us.Id = g.id;
                us.Maphong = maphong;
                us.Gheofday = gheofday;
                //MessageBox.Show(us.Argb + " " + us.Tenghe);
                flowLayoutPanel2.Controls.Add(us);
                us.Click += btn_clickloai;
            }
          
        }

        private void btn_clickloai(object sender, EventArgs e)
        {
           
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            if (plthongtinloaighe.Visible==false)
            {
                plthongtinloaighe.Visible = true;
            }
            qlloaighe = true;
            qlphong = false;
            qlghe = false;
            if(qlloaighe==true)
            {
                check(false);
                btnhuy.Enabled = false;
                btnluu.Enabled = false;
            }
            panel4.Visible = false;
            txttenghe.Tag = " ";
            us_loaighe ss=(us_loaighe)sender;
            txttenghe.Text = ss.Tenghe;
            txttenghe.Tag = ss.Id;
            txtmausac.BackColor = Color.FromArgb(Convert.ToInt32(ss.Argb));
            txtmausac.Text = ss.Argb;
            //txtmausac.Text = ss.Argb;
            txtgia.Text = ss.Giave.ToString();
            txtmaphong.Text = ss.Maphong.ToString();
            gheofday.Text = ss.Gheofday.ToString();
            txtid.Text = ss.Id.ToString();
        }
        void loadloaighe2(int maphong, int gheofday)
        {
            flowLayoutPanel3.Controls.Clear();
            us_loaighe us;
            List<loaighe> lg = new List<loaighe>();
            lg = loaigheDAO.Instance.loadloaighe2(maphong);
            foreach (loaighe g in lg)
            {
                us = new us_loaighe();
                us.Argb = g.mausac;
                us.Tenghe = g.tenloai;
                us.Giave = (decimal)g.giaghe;
                us.Id = g.id;
                us.Maphong = maphong;
                us.Gheofday = gheofday;
                //MessageBox.Show(us.Argb + " " + us.Tenghe);
                flowLayoutPanel3.Controls.Add(us);
                us.Click += btn_clickloai2;
            }

        }

        private void btn_clickloai2(object sender, EventArgs e)
        {

            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            if (plthongtinloaighe.Visible == false)
            {
                plthongtinloaighe.Visible = true;
            }
            qlloaighe = true;
            qlphong = false;
            qlghe = false;
            if (qlloaighe == true)
            {
                check(false);
                btnhuy.Enabled = false;
                btnluu.Enabled = false;
            }
            panel4.Visible = false;
            txttenghe.Tag = " ";
            us_loaighe ss = (us_loaighe)sender;
            txttenghe.Text = ss.Tenghe;
            txttenghe.Tag = ss.Id;
            txtmausac.BackColor = Color.FromArgb(Convert.ToInt32(ss.Argb));
            txtmausac.Text = ss.Argb;
            //txtmausac.Text = ss.Argb;
            txtgia.Text = ss.Giave.ToString();
            txtmaphong.Text = ss.Maphong.ToString();
            gheofday.Text = ss.Gheofday.ToString();
            txtid.Text = ss.Id.ToString();
        }
        private void khoitaosoghe(int dong, int cot)
        {
            int x, y = 10, khoangcachx = 95, khoangcachy = 50, dem = 1;
            Button btnghe;
            for (int i = 0; i < dong; i++)
            {
                x = 20;
                for (int j = 0; j < cot; j++)
                {
                    btnghe = new Button();
                    btnghe.Location = new Point(x, y);
                    btnghe.Size = new Size(80, 40);
                    btnghe.Text = dem++.ToString();
                    btnghe.BackColor = Color.White;
                    //btnghe.Click += BtnGhe_Click;
                    plghe.Controls.Add(btnghe);
                    x += khoangcachx;
                }
                y += khoangcachy;
            }
        }

        void TAOGHE(int id,int gheofay)
        {
            plghe.Controls.Clear();
            List<Class> cs = gheDAO.Instance.LAYGHETAO(id);
            int x = 30, y = 10, khoangcachx = 60, khoangcachy = 55, dem = 1;
            Button btnghe;
            foreach (Class c2 in cs)
            {
              
                btnghe = new Button();
                btnghe.Location = new Point(x, y);
                btnghe.Size = new Size(50, 40);
                string text = "A" + dem;
                btnghe.Text = c2.row.ToString();
                btnghe.Tag = c2.maghe;
                btnghe.BackColor = Color.White;
                //MessageBox.Show(c2.mausac.ToString());
                btnghe.FlatAppearance.BorderColor = Color.FromArgb(Convert.ToInt32(c2.mausac));
                btnghe.FlatStyle= FlatStyle.Flat;
                plghe.Controls.Add(btnghe);
                btnghe.Click += btn_ghe;
                //MessageBox.Show(c2.Row.ToString());
                dem++;
                if (dem == gheofay+1)
                {
                    y += khoangcachy;
                    x = -30;
                    dem = 1;
                }
                x += khoangcachx;

            }
            //foreach (Button ghe in pnlghe.Controls)
            //{
            //    foreach (Class cc in CSs)
            //    {
            //        if (ghe.Text == cc.row2)
            //        {
            //            ghe.BackColor = Color.Red;
            //            ghedat++;
            //        }
            //        //else
            //        //{
            //        //    ghe.BackColor = Color.White;
            //        //}
            //    }
            //}

        }

        private void btn_ghe(object sender, EventArgs e)
        {
            Button ghe=(Button)sender;
            string[] tachmp = groupControl1.Text.ToString().Split(':');
            int map = Convert.ToInt32(tachmp[1]);
            loaddmghe(map);
            loadloaighetao(map);
            panel4.Visible = true;
            plthemghe.Visible = false;
            check(true);
            btnsua.Enabled = true;
            qlloaighe = false;
            qlphong = false;
            qlghe = true;
            if (qlghe == true)
            {
                check(false);
                btnhuy.Enabled = false;
                btnluu.Enabled = false;
            }
            //MessageBox.Show(ghe.Tag.ToString());

            if (ghe.BackColor==Color.White)
            {
                ghe.BackColor = Color.Blue;
                txtghe.Text+=","+ghe.Text;
                txtghe.Tag+=","+ ghe.Tag;
                //capnhatghe = true;
                //MessageBox.Show(txtghe.Tag.ToString());
            }
            else if(ghe.BackColor==Color.Blue)
            {
                ghe.BackColor=Color.White;
                var charsToRemove = new string[] { ","+ghe.Text };
                foreach (var c in charsToRemove)
                {
                    txtghe.Text = txtghe.Text.Replace(c, string.Empty);
                }
                var TAG = new string[] { "," + ghe.Tag.ToString() };
                foreach (var c in TAG)
                {
                    txtghe.Tag = txtghe.Tag.ToString().Replace(c, string.Empty);
                }
            }
            plthongtinloaighe.Visible = true;
        }

        void loadphong()
        {
            flowLayoutPanel1.Controls.Clear();
            List<phong> gh = phongDAO.Instance.loadphong();
            Us_PHONG ph;
            foreach (phong pf in gh)
            {
                ph = new Us_PHONG();
                ph.Maphong = pf.Maphong;
                ph.Gheofday = (int)pf.gheofday;
                ph.Tongsoghe = (int)pf.Tongsoghe;
                ph.Tenphong=pf.tenphong;
                ph.Trangthai = Convert.ToInt32(pf.active);
                flowLayoutPanel1.Controls.Add(ph);
                ph.Click += new System.EventHandler(this.btn_click2);
            }
        }

        private void btn_click2(object sender, EventArgs e)
        {
            txtghe.Text = " ";
            txtghe.Tag = " ";
            qlloaighe =false;
            qlphong = true;
            qlghe = false;
            if (qlphong == true)
            {
                check(false);
                btnhuy.Enabled = false;
                btnluu.Enabled = false;
            }
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            if (plthongtinloaighe.Visible == true)
            {
                plthongtinloaighe.Visible = false;
            }
            plghe.Controls.Clear();
            
           Us_PHONG us =(Us_PHONG)sender;
            groupControl1.Text ="Phòng: "+ us.Maphong.ToString();
            lbgheofday.Text = us.Gheofday.ToString();
            lbgheofday.Tag = us.Trangthai;
            txttenphong.Text = us.Tenphong.ToString();
            txtgheofday.Text = us.Gheofday.ToString();
            txttongghe.Text=us.Tongsoghe.ToString();
            flowLayoutPanel2.Visible = true;
            //MessageBox.Show(us.Maphong.ToString());
            loadloaighe(us.Maphong,us.Gheofday);
            loadloaighe2(us.Maphong, us.Gheofday);
            TAOGHE(us.Maphong,us.Gheofday);
            //MessageBox.Show(us.Maphong.ToString());

        }

        void tongsoghe()
        {
            Class cl = phongDAO.Instance.tongsoghe();
            lbtongghe.Text = cl.tongsoghe.ToString();
        }
        private void FrQUANLYPHONG_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            dlg.ShowDialog(); //Hiển thị hộp thoại

            if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            {
                int str = dlg.Color.ToArgb(); //Khai báo biến str
               /* str = dlg.Color.Name;*/ //Trả lại tên của màu đã lựa chọn
                textEdit4.BackColor=Color.FromArgb(str);
                MessageBox.Show(str.ToString()); //Hiển thị lên MessageBox
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            if(qlphong==true)
            {
                themphong = true;
                if(themphong==true)
                {
                    txttenphong.Text = " ";
                    txttongghe.Text = " ";
                    txtgheofday.Text = " ";
                }
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }else if(qlghe==true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = true;
                if(themghe==true)
                {
                    //panel4.Visible = false;
                    //plthongtinloaighe.Visible = true;
                    plthemghe.Visible = true;
                }
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }else if(qlloaighe==true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = true;
                sualoaighe = false;
                xoaloaighe = false;
            }    
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (panel1.Visible=false)
            //{
            //    panel1.Visible=true;
            //}
            check(false);
            btnhuy.Enabled=false;
            btnluu.Enabled = false;
            //}else if(panel1.Height == 198)
            //{
            //    panel1.Height = 5;
            //}
        }

        private void plghe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(themphong==true)
            {
                try
                {
                    int tongghe = int.Parse(txttongghe.Text);
                    int gheofday = int.Parse(txtgheofday.Text);
                    string tenghe = txttenphong.Text;

                    byte[] asciiCharacters = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    string text = asciiEncoding.GetString(asciiCharacters);
                    int dem = 0, de = 0, gg = 0;

                    phong p = new phong();
                    p.Maphong = phongDAO.Instance.taophongmoi(tongghe, tenghe, gheofday).Maphong;
                    MessageBox.Show(p.Maphong.ToString());
                    List<loaighe> lg = loaigheDAO.Instance.loadloaighe();
                    int tong = loaigheDAO.Instance.loadtong();

                    for (int j = 0; j < text.Length; j++)
                    {


                        if (dem == gheofday)
                        {
                            break;
                        }
                        else
                        {
                            for (int g = 0; g < lg.Count(); g++)
                            {

                                for (int i = 1; i <= gheofday; i++)
                                {
                                    de = i;
                                    phongDAO.Instance.taophong(i, text[j].ToString(), p.Maphong, lg[gg].id);
                                }
                                if (de == gheofday)
                                {

                                    if (gg ==2 /*tong - 1*/)
                                    {
                                        gg =2/* tong - 1*/;
                                        break;
                                    }
                                    else
                                    {
                                        gg++;
                                        break;
                                    }

                                }
                            }


                        }

                        dem++;
                    }



                    MessageBox.Show("thêm thành công phòng");
                    loadphong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi tạo phòng: " + ex);
                }
            }
            else if(suaphong==true)
            {
                MessageBox.Show("chuc nang dang build");
            }
            else if(sualoaighe==true)
            {
                try
                {
                    string ten = txttenghe.Text;
                    int gia = Convert.ToInt32(txtgia.Text);
                    string mausac = txtmausac.Text;
                    int id = Convert.ToInt32(txtid.Text);
                    int map = Convert.ToInt32(txtmaphong.Text);
                    int gheof = Convert.ToInt32(gheofday.Text);
                    if (loaigheDAO.Instance.updateloaighe(ten, mausac, gia, id))
                    {
                        check(false);
                        btnhuy.Enabled = false;
                        btnluu.Enabled = false;
                        groupControl1.Text = "Phòng: " + map.ToString();
                        TAOGHE(map, gheof);
                        loadloaighe(map, gheof);
                        loadloaighe2(map, gheof);
                        MessageBox.Show("Cập nhật loại ghế thành công");
                    }
                    else
                    {
                        groupControl1.Text = "Phòng: " + map.ToString();
                        TAOGHE(map, gheof);
                        loadloaighe(map, gheof);
                        loadloaighe2(map, gheof);
                        MessageBox.Show("Cập nhật loại ghế thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật loại ghế: "+ex);
                }
              
            } else if(themgloaighe==true)
            {
                try
                {
                    string ten = txttenghe.Text;
                    int gia = Convert.ToInt32(txtgia.Text);
                    string mausac = txtmausac.Text;
                    int map = Convert.ToInt32(txtmaphong.Text);
                    int gheof = Convert.ToInt32(gheofday.Text);
                    if (loaigheDAO.Instance.taoloaighedefault(ten, mausac, gia,map))
                    {
                        TAOGHE(map, gheof);
                        loadloaighe(map, gheof);
                        loaddmghe(map);
                        loadloaighe2(map, gheof);
                        MessageBox.Show("Tạo loại ghế mới thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo loại ghế: " + ex);
                }
               
            }
            else if(themghe==true)
            {
                try
                {
                    int soghe = Convert.ToInt32(txtsoghe.Text);
                    string[] tachmp = groupControl1.Text.ToString().Split(':');
                    int map = Convert.ToInt32(tachmp[1]);
                    if(gheDAO.Instance.insertghe(soghe, cbday.Text, map, idmaghe2))
                    {
                        //string[] tachmp = groupControl1.Text.ToString().Split(':');
                        //int map = Convert.ToInt32(tachmp[1]);
                        int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                        TAOGHE(map, gheof);
                        loadloaighe(map, gheof);
                        loadloaighe2(map, gheof);
                        txtsoghe.Text = " ";
                        txtghe.Text = " ";
                        txtghe.Tag = " ";
                        MessageBox.Show("Tạo ghế thành công");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi tạo ghế: " + ex);
                }
              

            }
            else if(suaghe==true)
            {
                try
                {
                    //int maghe =Convert.ToInt32(txtghe.Tag);
                    //MessageBox.Show(txtghe.Tag.ToString());
                    string[] tachma = txtghe.Tag.ToString().Split(',');
                    for (int i = 1; i < tachma.Length; i++)
                    {
                        //MessageBox.Show(tachma[i].ToString());
                        gheDAO.Instance.updateghe(Convert.ToInt32(tachma[i]), idmaloaighe);
                    }
                    string[] tachmp = groupControl1.Text.ToString().Split(':');
                    int map = Convert.ToInt32(tachmp[1]);
                    int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                    TAOGHE(map, gheof);
                    loadloaighe(map, gheof);
                    loadloaighe2(map, gheof);
                    txtghe.Text = " ";
                    txtghe.Tag = " ";
                    MessageBox.Show("cập nhật ghế riêng thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật ghế: " + ex);
                    MessageBox.Show("tạo thất bại");
                }
            }
           


    //}

}

        private void flowLayoutPanel2_Paint_2(object sender, PaintEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(panel3.Visible==false)
            {
                panel3.Visible = true;
            }else if(panel3.Visible==true)
            {
                panel3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<loaighe> lg = loaigheDAO.Instance.taoloaighedefault(4186);
            //for(int g=0;g<lg.Count();g++)
            //{
            //    MessageBox.Show(lg[g].id.ToString());
            //}
            int tong = db.loaighes.Count();
            MessageBox.Show(tong.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            /*dlg.ShowDialog();*/ //Hiển thị hộp thoại

            if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            {
                int mm = dlg.Color.ToArgb(); //Khai báo biến str
               txtmausac.Text=Convert.ToString(mm);

                /* str = dlg.Color.Name;*/ //Trả lại tên của màu đã lựa chọn
                txtmausac.BackColor = Color.FromArgb(mm);
                /* MessageBox.Show(str.ToString()); *///Hiển thị lên MessageBox
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            check(true);
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            //if(plthongtinloaighe.Visible==true)
            //{
            //goipt = true;
            //}
            //if(panel1.Visible==true)
            //{
            //    goiptphong = true;
            //}
            if (qlphong == true)
            {
                themphong = false;
                suaphong = true;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }
            else if (qlghe == true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = true;
                if(suaghe == true)
                {
                    plthemghe.Visible = false;
                }
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }
            else if (qlloaighe == true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = true;
                xoaloaighe = false;
            }
        }

        private void cbloaighe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            loaighe selected = cb.SelectedItem as loaighe;
            idmaloaighe = selected.id;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtghe.Text = " ";
            txtghe.Tag = " ";
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (qlphong == true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = true;
                if(xoaphong==true)
                {
                    string[] tachmp = groupControl1.Text.ToString().Split(':');
                    int map = Convert.ToInt32(tachmp[1]);
                    int active = Convert.ToInt32(lbgheofday.Tag.ToString());
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete Yes/No", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                      
                        //MessageBox.Show(tachma[i].ToString());
                            if (phongDAO.Instance.xoaphong(map,active))
                            {
                                
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa phong thành công");

                            }
                            else
                            {
                                //string[] tachmp = groupControl1.Text.ToString().Split(':');
                                //int map = Convert.ToInt32(tachmp[1]);
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa phong thất bại");

                            }
                        

                    }
                }
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }
            else if (qlghe == true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = true;
                if(xoaghe==true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete Yes/No", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string[] tachma = txtghe.Tag.ToString().Split(',');
                        for (int i = 1; i < tachma.Length; i++)
                        {
                            //MessageBox.Show(tachma[i].ToString());
                            if (gheDAO.Instance.deleteghe(Convert.ToInt32(tachma[i])))
                            {
                                string[] tachmp = groupControl1.Text.ToString().Split(':');
                                int map = Convert.ToInt32(tachmp[1]);
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa ghế thành công");
                                
                            }
                            else
                            {
                                string[] tachmp = groupControl1.Text.ToString().Split(':');
                                int map = Convert.ToInt32(tachmp[1]);
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa ghế thất bại");
                                
                            }
                        }
                       
                    }
                }
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = false;
            }
            else if (qlloaighe == true)
            {
                themphong = false;
                suaphong = false;
                xoaphong = false;
                themghe = false;
                suaghe = false;
                xoaghe = false;
                themgloaighe = false;
                sualoaighe = false;
                xoaloaighe = true;
                if(xoaloaighe == true)
                {
                    
                    int id = Convert.ToInt32(txttenghe.Tag.ToString());
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete Yes/No", "Delete", MessageBoxButtons.YesNo);
                    //if(loaigheDAO.Instance.checkloaighe(id))
                    //{
                    //    MessageBox.Show("loại ghế đang được sử dụng");
                    //}else
                    //{
                    try
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            loaigheDAO.Instance.deletephanloai(id);
                            //MessageBox.Show(tachma[i].ToString());
                            if (loaigheDAO.Instance.deleteloaighe(id) )
                            {
                                string[] tachmp = groupControl1.Text.ToString().Split(':');
                                int map = Convert.ToInt32(tachmp[1]);
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                //TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa loại ghế ghế thành công");

                            }
                            else
                            {
                                string[] tachmp = groupControl1.Text.ToString().Split(':');
                                int map = Convert.ToInt32(tachmp[1]);
                                int gheof = Convert.ToInt32(lbgheofday.Text.ToString());
                                //TAOGHE(map, gheof);
                                loadloaighe(map, gheof);
                                loadloaighe2(map, gheof);
                                txtghe.Text = " ";
                                txtghe.Tag = " ";
                                MessageBox.Show("Xóa loại ghế thất bại");

                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("loại ghế đang được sử dụng");
                    }
                       
                    //}
             
                }
            }
        }

        private void cbloaighetao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            loaighe selected = cb.SelectedItem as loaighe;
            idmaghe2 = selected.id;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plthemghe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //frTHEMPHONG tp = new frTHEMPHONG();
            //tp.ShowDialog();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            panel1.Visible = true;
            txttenphong.Text = " ";
            txttongghe.Text = " ";
            txtgheofday.Text = " ";
        }

        //void loaddayghe()
        //{
        //    byte[] asciiCharacters = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
        //    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
        //    string text = asciiEncoding.GetString(asciiCharacters);
        //    string ct = null;
        //    for (int i=0;i<text.Length;i++)
        //    {
        //        //MessageBox.Show(text[i].ToString());


        //        ct += text[i].ToString()+Environment.NewLine;
        //    }
        //    MessageBox.Show(ct);
        //    cbday.Items.Add(ct);
        //}
        private void cbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
