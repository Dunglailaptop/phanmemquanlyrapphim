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
    public class phongDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static phongDAO instance;
        public static phongDAO Instance
        {
            get { if (instance == null) instance = new phongDAO(); return phongDAO.instance; }
            private set { phongDAO.instance = value; }
        }

        private phongDAO()
        { }
        public List<phong> loadphong()
        {
            List<phong> phongList = new List<phong>();
            DataTable table = DataProvider.Instance.ExecuteQuery("select * from phong");
            foreach(DataRow row in table.Rows)
            {
                phong p = new phong();
                p.Maphong = (int)row["Maphong"];
                p.tenphong = row["tenphong"].ToString();
                p.Tongsoghe = (int)row["Tongsoghe"];
                p.gheofday = (int)row["gheofday"];
                p.active = (int)row["active"];
                phongList.Add(p);
            }
            return phongList;
        }
        public List<Class> loadphongid(int id,DateTime date,DateTime date2)
        {
            List<Class> cl = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYDSTHOIGIANCHIEU'" + id+"' , '"+date+"' , '"+date2+"'");
            foreach (DataRow row in data.Rows)
            {
                Class ph = new Class();
                ph.poster = (byte[])row["poster"];
                ph.maphim = (int)row["Mã phim"];
                ph.thoiluong = (int)row["Thời lượng/Phút"];
                ph.tenphim = row["Tên phim"].ToString();
                ph.loaiphim = row["Loại phim"].ToString();
                ph.Maphong = (int)row["Maphong"];
                cl.Add(ph);
            }

            return cl;
        }
        public List<phong> layphong()
        {
            List<phong> phg = db.phongs.ToList();
            return phg;
        }
        public List<phong> Layphongtheosuatchieu(string time,int maphim,string date)
        {
            List<phong> p = new List<phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYPHONGTHEOSUATCHIEU '" + time + "' , '" + maphim + "' , '" + date + "'");
            foreach(DataRow row in data.Rows)
            {
                phong ph = new phong();
                ph.Maphong = (int)row["Maphong"];
                p.Add(ph);
            }
            return p;
        }
        public Class tongsoghe()
        {
            Class cl = new Class();
            DataTable data = DataProvider.Instance.ExecuteQuery("select count(g.Maghe) [Tongsoghe] from phong p inner join ghe g on g.Maphong=p.Maphong");
            foreach(DataRow row in data.Rows)
            {
                cl.tongsoghe = (int)row["Tongsoghe"];
            }
            return cl;
        }
        public bool taophong(int soghe,string row,int maphong,int maloaighe)
        {
         //int   maphong = 4165;
          int result=  DataProvider.Instance.ExecuteNonQuery("USP_insertghemoi '"+soghe + "' , '" + row + "' , '"+maphong+"' , '"+maloaighe+"'");
            return result > 0;
        }
       public phong taophongmoi(int tongghe,string tenphong,int gheofday)
        {
            phong ph = new phong();
            DataTable data = DataProvider.Instance.ExecuteQuery("insert into phong(Tongsoghe,tenphong,gheofday) output INSERTED.Maphong  values ('"+tongghe+"','"+tenphong+"','"+gheofday+"')");
            foreach(DataRow r in data.Rows)
            {
                ph.Maphong = (int)r["Maphong"];
            }
            return ph;
        }
        public bool deletephong(int maphong)
        {
            string quye = "Delete from phong where Maphong='" + maphong + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool xoaphong(int maphong,int active)
        {
            string quye = "USP_ktactive '" + maphong + "' , '" + active + "'";
            int thongbao = DataProvider.Instance.ExecuteNonQuery(quye);
            return thongbao > 0;
        }
            
    }
}
