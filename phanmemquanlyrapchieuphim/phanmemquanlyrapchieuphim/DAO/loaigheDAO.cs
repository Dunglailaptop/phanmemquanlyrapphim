using phanmemquanlyrapchieuphim.DAO;
using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class loaigheDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static loaigheDAO instance;
        public static loaigheDAO Instance
        {
            get { if (instance == null) instance = new loaigheDAO(); return loaigheDAO.instance; }
            private set { loaigheDAO.instance = value; }
        }

        private loaigheDAO()
        { }
        public List<loaighe> loadloaighe()
        {
            List<loaighe> lg = new List<loaighe>();
            string quye = "select * from loaighe where id not in (select Maloai from phanloaighebyphong)";
            DataTable data = DataProvider.Instance.ExecuteQuery(quye);
            foreach (DataRow dr in data.Rows)
            {
                loaighe lgg = new loaighe();
                lgg.id = (int)dr["id"];
                lgg.tenloai = dr["tenloai"].ToString();
                lgg.mausac = dr["mausac"].ToString();
                //lgg.giaghe = Convert.ToDecimal(dr["giaghe"]);
                lg.Add(lgg);
            }
            return lg;
        }
        public List<loaighe> loadloaighebyphong(int maphong)
        {
            List<loaighe> lg = new List<loaighe>();
            string quye = "select distinct lg.mausac,lg.tenloai,lg.giaghe from ghe g inner join loaighe lg on g.maloaighe=lg.id where g.Maphong='"+maphong+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(quye);
            foreach (DataRow dr in data.Rows)
            {
                loaighe lgg = new loaighe();
                //lgg.id = (int)dr["id"];
                lgg.tenloai = dr["tenloai"].ToString();
                lgg.mausac = dr["mausac"].ToString();
                lgg.giaghe = Convert.ToInt32(dr["giaghe"]);
                lg.Add(lgg);
            }
            return lg;
        }
        public List<loaighe> loadloaighe2(int id)
        {
            List<loaighe> lg = new List<loaighe>();
            string quye = "select * from loaighe lg inner join phanloaighebyphong pl on pl.Maloai=lg.id inner join phong p on p.Maphong=pl.Maphong where p.Maphong='"+id+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(quye);
            foreach (DataRow dr in data.Rows)
            {
                loaighe lgg = new loaighe();
                lgg.id = (int)dr["id"];
                lgg.tenloai = dr["tenloai"].ToString();
                lgg.mausac = dr["mausac"].ToString();
                lgg.giaghe = (decimal)dr["giaghe"];
                lg.Add(lgg);
            }
            return lg;
        }
        public List<loaighe> loadallloaighe(int id)
        {
            List<loaighe> lg = new List<loaighe>();
            string quye = "select * from loaighe g inner join phanloaighebyphong pl on pl.Maloai=g.id where pl.Maphong='"+id+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(quye);
            foreach (DataRow dr in data.Rows)
            {
                loaighe lgg = new loaighe();
                lgg.id = (int)dr["id"];
                lgg.tenloai = dr["tenloai"].ToString();
                lgg.mausac = dr["mausac"].ToString();
                lgg.giaghe = (decimal)dr["giaghe"];
                lg.Add(lgg);
            }
            return lg;
        }
        public bool deletephanloai(int maloai)
        {
            string qu = "DELETE FROM phanloaighebyphong where Maloai='"+maloai+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(qu);
            return result >0;
        }
        public bool deletephanloaibyphong(int maphong)
        {
            string qu = "DELETE FROM phanloaighebyphong where Maphong='" + maphong + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(qu);
            return result > 0;
        }
        public int loadtong()
        {
            int TONG = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery("select count(*) as [tong] from loaighe");
            foreach (DataRow dr in data.Rows)
            {
               
                TONG= (int)dr["tong"];
             
                
            }
            return TONG;
        }
        public bool updateloaighe(string loaighe,string mausac,int giaghe,int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update loaighe set tenloai=N'" + loaighe + "' , mausac='" + mausac + "' , giaghe='" + giaghe + "' where id='"+id+"'");
            return result >0;
        }
        public bool taoloaighedefault(string tenloai,string mausac,int giaghe,int maphong)
        {
            List<loaighe> lg = new List<loaighe>();
            string quey = "USP_TAOLOAIGHEBYPHONG N'"+ tenloai+"' , '"+mausac+"' , '"+giaghe+"' , '"+maphong+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quey);
            
            return result>0;
        }
        public bool checkloaighe(int id)
        {
            string quey="select * from loaighe where id='"+id+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quey);
            return result > 0;
        }
        public bool deleteloaighe(int id)
        {
            string quey = "delete from loaighe where id='" + id + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(quey);
            return result > 0;
        }
    }
}
