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
    public class SanPhamDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }

        private SanPhamDAO()
        { }
        public bool insertsanpham(string tensanpham,int madanhmuc,decimal gia,int soluong,byte[] hinhanh)
        {
            
            db.USP_INSERTSANPHAM(tensanpham, madanhmuc, gia, soluong, hinhanh);
            int result = db.GetChangeSet().Inserts.Count();
            return result>0;
        
        }
        public bool updatesanpham(string tensanpham, int madanhmuc, decimal gia, int soluong, byte[] hinhanh,int masp)
        {
            db.USP_UPDATESANPHAM(tensanpham, madanhmuc, soluong, hinhanh, gia, masp);
            int result = db.GetChangeSet().Updates.Count();
            return (result>0);
        }
        public List<danhmucsp> showlistdanhmuc()
        {
            List<danhmucsp> dm = new List<danhmucsp>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_SHOWDANHMUC");
            foreach(DataRow row in data.Rows)
            {
                danhmucsp dmm = new danhmucsp();
                dmm.Madm = (int)row["Madm"];
                dmm.tendanhmuc = row["tendanhmuc"].ToString();
                dm.Add(dmm);
            }
            return dm;
        }
        public string showdm(int madm)
        {

            danhmucsp dm = new danhmucsp();
            dm = db.danhmucsps.Where(x => x.Madm == madm).SingleOrDefault();
            return dm.tendanhmuc.ToString();
        }
        public bool delete(int id)
        {
           int RESULT= DataProvider.Instance.ExecuteNonQuery("Delete from sanpham where Masp='" + id + "'");
            return RESULT>0;
        }
        public List<sanpham> sreach(int id)
        {
            List<sanpham> dm = new List<sanpham>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from sanpham where Madanhmuc='"+id+"'");
            foreach (DataRow row in data.Rows)
            {
                sanpham dmm = new sanpham();
                dmm.Tensanpham = row["Tensanpham"].ToString();
                dmm.Madanhmuc = (int)row["Madanhmuc"];
                dmm.Masp = (int)row["Masp"];
                dmm.hinhanh = (byte[])row["hinhanh"];
                dmm.soluong = (int?)row["soluong"];
                dmm.Gia = (decimal?)row["Gia"];
                dm.Add(dmm);
            }
            return dm;
        }
        public Class showmotsanpham(int Masp)
        {
            Class dmm = new Class();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from sanpham sp inner join danhmucsp dm on dm.Madm=sp.Madanhmuc where Masp='" + Masp + "'");
            foreach (DataRow row in data.Rows)
            {
               
                dmm.tenfood = row["Tensanpham"].ToString();
                dmm.tenloai = row["Tendanhmuc"].ToString();
                dmm.machieu = (int)row["Masp"];
                dmm.picture = (byte[])row["hinhanh"];
                dmm.soluongfood = (int)row["soluong"];
                dmm.giave = (decimal)row["Gia"];
             
            }
            return dmm;
        }
        public List<Class> listspbydanhmuc(int id)
        {
            List<Class> dm = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from sanpham sp inner join danhmucsp dm on dm.Madm=sp.Madanhmuc where Madanhmuc='" + id + "'");
            foreach (DataRow row in data.Rows)
            {
                Class dmm = new Class();
                dmm.tenfood = row["Tensanpham"].ToString();
                dmm.tenloai = row["Tendanhmuc"].ToString();
                dmm.machieu = (int)row["Masp"];
                dmm.picture = (byte[])row["hinhanh"];
                dmm.soluongfood = (int)row["soluong"];
                dmm.giave = (decimal)row["Gia"];
                dm.Add(dmm);
            }
            return dm;
        }

        public List<sanpham> showlistsanpham()
        {
            List<sanpham> dm = new List<sanpham>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_SHOWSANPHAM");
            foreach (DataRow row in data.Rows)
            {
                sanpham dmm = new sanpham();
                dmm.Tensanpham = row["Tensanpham"].ToString();
                dmm.Madanhmuc = (int)row["Madanhmuc"];
                dmm.Masp = (int)row["Masp"];
                dmm.hinhanh = (byte[])row["hinhanh"];
                dmm.soluong = (int?)row["soluong"];
                dmm.Gia = (decimal?)row["Gia"];
                dm.Add(dmm);
            }
            return dm;
        }
       public List<Class> baocaothucan(DateTime date1)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_doanhthuthucan '" + date1 + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenfood = row["tensanpham"].ToString();
                c.giatien = (decimal)row["tongtien"];
                c.soluongfood = (int)row["tongve"];
                c.row = row["Stt"].ToString();
                c.maphim = (int)row["Masp"];
                cl.Add(c);
            }
            return cl;
        }
        public List<Class> baocaothucanbymonth(DateTime date1)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_doanhthuthucanbymonth '" + date1 + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenfood = row["tensanpham"].ToString();
                c.giatien = (decimal)row["tongtien"];
                c.soluongfood = (int)row["tongve"];
                c.maphim = (int)row["Masp"];
                c.row = row["Stt"].ToString();
                cl.Add(c);
            }
            return cl;
        }


        public List<Class> baocaochitietthucanbydate(DateTime date1,DateTime date2,int masp)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOfood '" + date1 + "' , '"+date2+"' , '"+masp+"'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenfood = row["tensanpham"].ToString();
                c.giatien = (decimal)row["tongtiensl"];
                c.soluongfood = (int)row["tongsl"];
                c.ngaychieushow = row["Ngay"].ToString();
                c.maphim = (int)row["Masp"];
                //c.row = row["Stt"].ToString();
                cl.Add(c);
            }
            return cl;
        }
        public List<Class> baocaochitietthucanbymonth(DateTime date1, DateTime date2, int masp)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOfoodbymonth '" + date1 + "' , '" + date2 + "' , '" + masp + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenfood = row["tensanpham"].ToString();
                c.giatien = (decimal)row["tongtiensl"];
                c.soluongfood = (int)row["tongsl"];
                c.ngaychieushow = row["Ngay"].ToString();
                c.maphim = (int)row["Masp"];
                //c.row = row["Stt"].ToString();
                cl.Add(c);
            }
            return cl;
        }
        public List<Class> baocaochitietthucanbyyear(DateTime date1, DateTime date2, int masp)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOfoodbyyear '" + date1 + "' , '" + date2 + "' , '" + masp + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenfood = row["tensanpham"].ToString();
                c.giatien = (decimal)row["tongtiensl"];
                c.soluongfood = (int)row["tongsl"];
                c.ngaychieushow = row["Ngay"].ToString();
                c.maphim = (int)row["Masp"];
                //c.row = row["Stt"].ToString();
                cl.Add(c);
            }
            return cl;
        }
    }
}
