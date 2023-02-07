using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class HoaDonDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }

        private HoaDonDAO()
        { }
        public hoadon THANHTOAN(DateTime Ngaytao,decimal giaveduocgiam,int soluongve,int maphim,decimal tongtien,decimal giave)
        {
            string makhachhang = "kh01";
            string manhanvien = "NV01";
            int status = 1;
            hoadon hd = new hoadon();
           DataTable data=DataProvider.Instance.ExecuteQuery(" USP_TAOHOADON '" + makhachhang + "' , '" + manhanvien + "' , '" + maphim + "' , '" + Ngaytao + "' , '" + soluongve +"' , '" + giaveduocgiam + "' , '" + tongtien + "'");
            foreach(DataRow dr in data.Rows)
            {
                hd.Mahoadon = dr["mahd"].ToString();

            }
            return hd;
        }
        public void INSERTGHEDAMUA(int MACHIEU,int MAGHE,string mahoadon)
        {
            int STATUS = 1;
            DataProvider.Instance.ExecuteNonQuery("USP_INSERTGHE '" + MACHIEU + "' , '" + STATUS + "' , '" + MAGHE + "','"+mahoadon+"'");
        }
        public void INSERTVEXEM(string MAHOADON, int MACHIEU,int MAGHE)
        {
       
            DataProvider.Instance.ExecuteNonQuery("USP_TAOVEXEM '" + MAHOADON + "' , '" + MACHIEU + "' , '" + MAGHE + "'");
        }
        public bool insertchitiethoadonfood(int masp,int soluong,decimal giatien, string mahoadon)
        {
            string quy = "insert into chitiethoadonfood(Masp,soluong,giatien,Mahoadon) values ('"+masp+"','"+soluong+"','"+giatien+"','"+mahoadon+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quy);
            return result > 0;
        }
        public List<Class> inhoadonfood(string mahoadon)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select HDSP.giatien as [tongtien],cf.Mahoadon,sp.Tensanpham,cf.soluong as [slog],cf.giatien as [gia] from hoadonsanpham HDSP inner join chitiethoadonfood cf on cf.Mahoadon=HDSP.Mahoadon inner join sanpham sp on sp.Masp=cf.Masp where HDSP.Mahoadon='" + mahoadon + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class c = new Class();
                c.Mahoadon = dr["Mahoadon"].ToString();
                c.soluongfood = (int)dr["slog"];
                c.tenfood = dr["Tensanpham"].ToString();
                c.giatien = (decimal)dr["gia"];
                c.sotien = (decimal)dr["tongtien"];
                cl.Add(c);
            }
            return cl;

        }
        public hoadonsanpham INSERTFOOD(decimal giatien,int soluong,DateTime date)
        {

            hoadonsanpham hd = new hoadonsanpham();
            DataTable data =DataProvider.Instance.ExecuteQuery("insert into hoadonsanpham(giatien,soluong,Ngaytao,Manhanvien) output inserted.Mahoadon as [id] values ('"+giatien+"','"+soluong+"','"+date+"','NV02')");
            foreach(DataRow row in data.Rows)
            {
                hd.Mahoadon = row["id"].ToString();

            }
            return hd;
        }
        public List<Class> inhoadon(string mahoadon)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_INHOADON '" + mahoadon + "'");
            foreach(DataRow row in data.Rows)
            {
                Class cs = new Class();
                cs.tenphim = row["tenphim"].ToString();
                cs.row = row["ghe"].ToString();
                cs.ngaychieushow = row["Ngaychieu"].ToString();
                cs.thoigianchieu = row["thoigian"].ToString();
                cs.Mahoadon = row["Mahoadon"].ToString();
                cs.hoten = row["hoten"].ToString();
                cs.tenphong = row["tenphong"].ToString();
                cl.Add(cs);
            }
            return cl;

        }
        public List<Class> dshoadonvexem(DateTime date)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_quanlyhoadonve '"+date+"'");
            foreach (DataRow row in data.Rows)
            {
                Class CS = new Class();
                CS.Mahoadon = row["Mahoadon"].ToString();
                CS.soluongfood = (int)row["soluongve"];
                CS.giatien = (decimal)row["tongtien"];
                CS.tenphim = row["Tenphim"].ToString();
                CS.Ngaynhap_name = row["Ngay"].ToString();
                CS.hoten = row["hoten"].ToString();
                CS.Maphong = (int)row["Maphong"];
                CS.thoigianchieu = row["thoigian"].ToString();
                CS.ngaychieushow= row["Ngaychieu"].ToString();
                cl.Add(CS);
            }
            return cl;
        }
        public List<hoadonsanpham> dshoadonfood(DateTime date)
        {
            List<hoadonsanpham> cl = new List<hoadonsanpham>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from hoadonsanpham hd where hd.Ngaytao='"+date+"'");
            foreach (DataRow row in data.Rows)
            {
                hoadonsanpham cl2 = new hoadonsanpham();
                cl2.Mahoadon = row["Mahoadon"].ToString();
                cl2.Manhanvien = row["Manhanvien"].ToString();
                cl2.Ngaytao = (DateTime)row["Ngaytao"];
                cl2.soluong = (int)row["soluong"];
                cl2.giatien = (decimal)row["giatien"];
                cl.Add(cl2);
            }
            return cl;
        }
    }
}
