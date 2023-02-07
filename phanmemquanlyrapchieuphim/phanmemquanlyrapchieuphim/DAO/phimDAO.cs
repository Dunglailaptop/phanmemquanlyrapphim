
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
    public class phimDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static phimDAO instance;
        public static phimDAO Instance
        {
            get { if (instance == null) instance = new phimDAO(); return phimDAO.instance; }
            private set { phimDAO.instance = value; }
        }

        private phimDAO()
        { }
      
       //public object loadtablephim()
       // {
       //     List<phim> phi = db.phims.ToList();
       //     List<quocgia> quocg = db.quocgias.ToList();
       //     List<theloai> THE = db.theloais.ToList();
       //     var quye = (from quoc in quocg
       //                 join ph in phi on quoc.Maquocgia equals ph.Maquocgia into table1
       //                 from ph in table1
       //                 join th in THE on ph.Matheloai equals th.Matheloai
       //                 select new { ph.Maphim, ph.Tenphim, ph.loaiphim, quoc.Tenquocgia, th.tentheloai, ph.Thoiluong }).ToList();
       //     return quye;
       // }
        public DataTable loadphim()
        {
            List<Class> phimsz = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_getINNERPHIM");
            foreach (DataRow row in data.Rows)
            {
                Class phimss = new Class();
                phimss.maphim = (int)row["Maphim"];
                phimss.tenquoc = row["Tenquocgia"].ToString();
                phimss.tentheloai = row["Tentheloai"].ToString();
                phimss.thoiluong = (int)row["Thoiluong"];
                phimss.tacgia = row["Tacgia"].ToString();
                phimss.loaiphim = row["loaiphim"].ToString();
                phimss.poster = (byte[])row["poster"];
                phimsz.Add(phimss);
            }

            return data;
        }
        public phim poster(int id)
        {
            phim p = new phim();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from phim where Maphim='" + id + "'");
            foreach(DataRow dr in data.Rows)
            {
                p.poster = (Byte[])dr["poster"];
                p.Tenphim = dr["Tenphim"].ToString();
            }
            return p;
        }
        public Class showchitietphim(int id)
        {
            Class phim = new Class();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from phim p inner join quocgia qg on p.Maquocgia=qg.Maquocgia inner join theloai th on th.Matheloai=p.Matheloai where p.Maphim='" + id + "'");
           foreach(DataRow row in data.Rows)
            {
                phim.tenphim = row["Tenphim"].ToString();
                phim.maphim = (int)row["Maphim"];
                phim.poster = (byte[])row["poster"];
                phim.mota = row["mota"].ToString();
                phim.loaiphim = row["loaiphim"].ToString();
                phim.thoiluong = (int)row["thoiluong"];
                phim.tenquoc = row["Tenquocgia"].ToString();
                phim.tentheloai = row["tentheloai"].ToString();
                phim.date = (DateTime)row["Namphathanh"];
                phim.tacgia = row["Tacgia"].ToString();

            }
            return phim;
        }
        public void insertphim(string tenphim,string tacgia,int matheloai,int maquocgia,int thoiluong,DateTime namphathanh,byte[] poster,string mota,string loaiphim)
        {
            db.USP_INSERTPHIM(tenphim, tacgia, namphathanh, matheloai, maquocgia, thoiluong, mota, loaiphim, poster);
        }
        public void updatephim(int maphim,string tenphim, string tacgia, int matheloai, int maquocgia, int thoiluong, DateTime namphathanh, byte[] poster, string mota, string loaiphim)
        {
            db.USP_UPDATEPHIM(tenphim, tacgia, namphathanh, matheloai, maquocgia, thoiluong, mota, loaiphim, poster, maphim);
        }
        //public void update2(int maphim, string tenphim, string tacgia, int matheloai, int maquocgia, int thoiluong, DateTime namphathanh, byte[] poster, string mota, string loaiphim)
        //{
        //    //List<Class> phimsz = new List<Class>();
        //    ////DataTable data = DataProvider.Instance.ExecuteQuery("USP_UPDATEPHIM", object[]{ });
        //    ////foreach (DataRow row in data.Rows)
        //    ////{
        //    ////    Class phimss = new Class();
        //    ////    phimsz.Add(phimss);
        //    ////}

        //    //return data;
        //}
        public List<phim> LAYTENPHIM()
        {
            List<phim> phimList = db.phims.ToList();
            return phimList;
           

        }
        public List<phim> laydsphimdangcosuatchieu(DateTime date)
        {
            List<phim> phi = new List<phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSPHIMDANGCOSUATCHIEU '"+date+"'");
            foreach (DataRow row in data.Rows)
            {
                phim phim = new phim();
                phim.Tenphim = row["Tenphim"].ToString();
                phim.poster = (byte[])row["poster"];
                phim.Namphathanh = (DateTime)row["Namphathanh"];
                phi.Add(phim);
            }
            return phi;
        }
        public List<phim> laydsphimdangchieu(DateTime date)
        {
            List<phim> phi = new List<phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSPHIMDANGCHIEU '" + date + "'");
            foreach (DataRow row in data.Rows)
            {
                phim phim = new phim();
                phim.Tenphim = row["Tenphim"].ToString();
                phim.poster = (byte[])row["anh"];
                phim.Namphathanh = (DateTime)row["Namphathanh"];
                phim.Maphim = (int)row["Maphim"];
                phi.Add(phim);
            }
            return phi;
        }
        public List<phim> laydsphimdangchieuBYTHELOAI(DateTime date,int theloai)
        {
            List<phim> phi = new List<phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSPHIMDANGCHIEUBYTHELOAI '"+theloai+"','" + date + "'");
            foreach (DataRow row in data.Rows)
            {
                phim phim = new phim();
                phim.Tenphim = row["Tenphim"].ToString();
                phim.poster = (byte[])row["anh"];
                phim.Namphathanh = (DateTime)row["Namphathanh"];
                phim.Maphim = (int)row["Maphim"];
                phi.Add(phim);
            }
            return phi;
        }
        public List<phim> TIMKIEMPHIM(DateTime date, string tenphim)
        {
            List<phim> phi = new List<phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_timkiemphim '" + tenphim + "','" + date + "'");
            foreach (DataRow row in data.Rows)
            {
                phim phim = new phim();
                phim.Tenphim = row["Tenphim"].ToString();
                phim.poster = (byte[])row["anh"];
                phim.Namphathanh = (DateTime)row["Namphathanh"];
                phim.Maphim = (int)row["Maphim"];
                phi.Add(phim);
            }
            return phi;
        }
        public bool delete(int id)
        {
            int result=DataProvider.Instance.ExecuteNonQuery("Delete from phim where Maphim='" + id + "'");
            return result>0;
        }

        public List<Class> BAOCAOPHIM(DateTime DATE1,DateTime DATE2,int maphim)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOPHIM '"+DATE1+"' , '"+DATE2+"' , '"+maphim+"'");
            foreach(DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenphim = row["Tenphim"].ToString();
                c.soluongfood = (int)row["tongve"];
                c.giatien = (decimal)row["tongtienphim"];
                c.ngaychieushow = row["Ngay"].ToString();
                CL.Add(c);
            }
            return CL;

        }
        public List<Class> BAOCAOPHIMbyyear(DateTime DATE1, DateTime DATE2, int maphim)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOPHIMbyyear '" + DATE1 + "' , '" + DATE2 + "' , '" + maphim + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenphim = row["Tenphim"].ToString();
                c.soluongfood = (int)row["tongve"];
                c.giatien = (decimal)row["tongtienphim"];
                c.ngaychieushow = row["Ngay"].ToString();
                CL.Add(c);
            }
            return CL;

        }
        public List<Class> BAOCAOPHIMbymonth(DateTime DATE1, DateTime DATE2, int maphim)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOPHIMbymonth '" + DATE1 + "' , '" + DATE2 + "' , '" + maphim + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenphim = row["Tenphim"].ToString();
                c.soluongfood = (int)row["tongve"];
                c.giatien = (decimal)row["tongtienphim"];
                c.ngaychieushow = row["Ngay"].ToString();
                CL.Add(c);
            }
            return CL;

        }
        public List<Class> doanhhthuphim(DateTime DATE1)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_doanhthuphim '" + DATE1 + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenphim = row["Tenphim"].ToString();
                c.soluongfood = (int)row["tongve"];
                c.giatien = (decimal)row["tongtien"];
                c.tieude = row["Stt"].ToString();
                c.maphim = (int)row["Maphim"];
                CL.Add(c);
            }
            return CL;

        }

        public List<Class> doanhhthuphimbymonth(DateTime DATE1)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_doanhthuphimbymonth '" + DATE1 + "'");
            foreach (DataRow row in data.Rows)
            {
                Class c = new Class();
                c.tenphim = row["Tenphim"].ToString();
                c.soluongfood = (int)row["tongve"];
                c.giatien = (decimal)row["tongtien"];
                c.tieude = row["Stt"].ToString();
                c.maphim = (int)row["Maphim"];
                CL.Add(c);
            }
            return CL;

        }
    }
}
