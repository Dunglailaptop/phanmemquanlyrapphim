using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class suatchieuDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static suatchieuDAO instance;
        public static suatchieuDAO Instance
        {
            get { if (instance == null) instance = new suatchieuDAO(); return suatchieuDAO.instance; }
            private set { suatchieuDAO.instance = value; }
        }

        private suatchieuDAO()
        { }

        public List<innerjoin> loadsuatchieubyphim(DateTime id)
        {
            List<suatchieu> list = new List<suatchieu>();
            list = db.suatchieus.ToList();
            List<phim> phims = db.phims.ToList();
            List<chitietsuatchieu> chitietsuatchieus = db.chitietsuatchieus.ToList();
            var quey = (from ph in phims
                        join sc in list on ph.Maphim equals sc.Maphim into table1
                        from sc in table1
                        join ch in chitietsuatchieus on sc.Machieu equals ch.Machieu
                        where ch.Ngaybatdau == id
                        select new innerjoin { Suatchieus = sc, Phims=ph, Chitietsuatchieus = ch }).ToList();
            return quey;
        }
        
        public bool inesrt(int maphong,int maphim,DateTime ngaybatdau,string time,float giave)
        {
       
           int result=  DataProvider.Instance.ExecuteNonQuery("USP_tess '"+time+"' , '"+maphong+"' , '"+maphim+"' , '"+ngaybatdau+"' , '"+giave+"'");
            return result>0;
        }
        public List<Class> loaddsngaychieu(int id,int maphong)
        {
            List<Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSNGAYCHIEU '"+id+"' , '"+maphong+"'");
            foreach(DataRow row in data.Rows)
            {
                Class clas = new Class();
                clas.tenphim = row["Tenphim"].ToString();
                clas.date = (DateTime)row["Ngaybatdau"];
                CL.Add(clas);
            }
            return CL;

        }
        public Class laychitietsuatchieu(string thoigian,int maphong,int maphim,DateTime date)
        {
            //List<Class> CL = new List<Class>();
            Class clas = new Class();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_CHITIETSUATCHIEU '" + thoigian+ "' , '"+maphong+"' , '"+maphim+"' , '"+date+"'");
            foreach (DataRow row in data.Rows)
            {
                
                clas.tenphim = row["Tenphim"].ToString();
                clas.ngaychieushow = row["Ngaychieu"].ToString();
                clas.date = (DateTime)row["Ngaybatdau"];
                clas.Maphong = (int)row["Maphong"];
                clas.thoigianchieu =row["thoigian"].ToString();
                //clas.thoigian = (TimeSpan)row["thoigianchieu"];
                clas.maphim = (int)row["Maphim"];
                clas.giave = Convert.ToDecimal(row["giave"]);
                clas.poster = (byte[])row["poster"];
                clas.machieu = (int)row["Machieu"];
                clas.tongghe = (int)row["Tongsoghe"];
                clas.gheofday = (int)row["gheofday"];
                //CL.Add(clas);
            }
            return clas;
        }
        public List<Class> laydsghedadat(int maphong,string suatchieu,DateTime ngaychieu,int maphim)
        {
            List <Class> CL = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GHEDADAT '" + suatchieu + "' , '" + maphong + "' , '" + maphim + "' , '" + ngaychieu + "'");
         foreach(DataRow row in data.Rows)
            {
                Class clas = new Class();
                clas.row2 = row["ghedat"].ToString();
                clas.status = (int)row["Status"];
                CL.Add(clas);
            }
            return CL;
        }
        public List<Class> layallghe(int maphong, string suatchieu, DateTime ngaychieu, int maphim)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_DSGHE '" + suatchieu + "' , '" + maphong + "' , '" + maphim + "' , '" + ngaychieu + "'");
            foreach (DataRow row in data.Rows)
            {
                Class cllas = new Class();
                cllas.row = row["ghe"].ToString();
                cllas.maghe = (int)row["Maghe"];
                cllas.gheofday = (int)row["gheofday"];
                cllas.trangthaighe = (int)row["trangthaighe"];
                cllas.mausac = row["mausac"].ToString();
                //cllas.gheofday = (int)row["gheofday"];
                cl.Add(cllas);
            }
            return cl;
        }
        //public List<suatchieu> loadsuatchieu()
        //{
        //    List<suatchieu> cl = new List<suatchieu>();
        //    DataTable data = DataProvider.Instance.ExecuteQuery("select thoigianchieu from suatchieu");
        //    foreach(DataRow row in data.Rows)
        //    {
        //        suatchieu cllas = new suatchieu();
        //        cllas.thoigianchieu =(TimeSpan)row["thoigianchieu"];
        //        cl.Add(cllas);
        //    }
        //    return cl;
        //}
      public List<Class> LAYSUATCHIEU(DateTime DATE,int maphim,int maphong,DateTime date2)
        {
            List<Class> SC = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYSUATCHIEU '" + maphong + "' , '" + maphim + "' , '" + DATE + "' , '"+date2+"'");
            foreach(DataRow row in data.Rows)
            {
                Class suatchieu = new Class();
                suatchieu.thoigianchieu = row["thoigianchieu"].ToString();
                suatchieu.ngaychieu = (DateTime)row["Ngaybatdau"];
                suatchieu.Maphong = (int)row["Maphong"];
                SC.Add(suatchieu);
            }
            return SC;
        }
        public List<Class> LAYSUATCHIEU2(DateTime DATE, int maphim, DateTime date2)
        {
            List<Class> SC = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYSUATCHIEU2 '" + maphim + "' , '" + DATE + "' , '" + date2 + "'");
            foreach (DataRow row in data.Rows)
            {
                Class suatchieu = new Class();
                suatchieu.thoigianchieu = row["thoigianchieu"].ToString();
                suatchieu.ngaychieu = (DateTime)row["Ngaybatdau"];
                suatchieu.Maphong = (int)row["Maphong"];
                suatchieu.giave = (int)row["giave"];
                SC.Add(suatchieu);
            }
            return SC;
        }
        public List<Class> getallsuatchieu( DateTime date,DateTime date2)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSPHIMDANGCOSUATCHIEU'"+date + "' , '"+date2+"'");
            foreach (DataRow row in data.Rows)
            {
                Class ph = new Class();
                ph.poster = (byte[])row["anh"];
                ph.maphim = (int)row["Maphim"];
                ph.thoiluong = (int)row["Thoiluong"];
                ph.tenphim = row["Tenphim"].ToString();
                ph.loaiphim = row["loaiphim"].ToString();
                ph.Maphong = (int)row["Maphong"];
                cl.Add(ph);
            }

            return cl;
        }
        public List<Class> laysuatchieutheophim(string date,int maphim)
        {
            List<Class> sc=new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYSUATCHIEUTHEOPHIM '" + maphim + "' , '" + date + "'");
             foreach(DataRow row in data.Rows)
            {
                Class ph = new Class();
                ph.thoigianchieu = row["thoigianchieu"].ToString();
                ph.tenphong = row["tenphong"].ToString();
                ph.Maphong =(int)row["Maphong"];
                ph.maphim = (int)row["Maphim"];
                sc.Add(ph);
            }
            return sc;
        }
        public bool xoasuatchieu(int machieu)
        {
            string q = "usp_xoasuatchieu '"+machieu+"'";
            int reuslt = DataProvider.Instance.ExecuteNonQuery(q);
            return reuslt > 0;
        }
        public bool suasuatchieu(int machieu,decimal giave,DateTime thoigian,DateTime date,int maphim)
        {
            string q = "ups_suathongtinsuatchieu '"+machieu+"','"+thoigian+"','"+date+"','"+giave+"', '"+maphim+"'";
            int reuslt = DataProvider.Instance.ExecuteNonQuery(q);
            return reuslt > 0;
        }
    }
}
