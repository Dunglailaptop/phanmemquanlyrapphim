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
    public class khachhangDAO
    {
        private static khachhangDAO instance;
        public static khachhangDAO Instance
        {
            get { if (instance == null) instance = new khachhangDAO(); return khachhangDAO.instance; }
            private set { khachhangDAO.instance = value; }
        }

        private khachhangDAO()
        { }

        public List<Class> baocaokhachhangbymonth(DateTime date)
        {
            List<Class> baocaonhanvien = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_topthanhvienbymonth '" + date + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class c = new Class();
                c.manv = dr["Makh"].ToString();
                c.hoten = dr["hoten"].ToString();
                c.giatien = (decimal)dr["doanhthu"];
                c.row = dr["Stt"].ToString();
                baocaonhanvien.Add(c);
            }
            return baocaonhanvien;

        }
        public List<Class> baocaokhachhangbyyear(DateTime date)
        {
            List<Class> baocaonhanvien = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_topthanhvienbyyear '" + date + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class c = new Class();
                c.manv = dr["Makh"].ToString();
                c.hoten = dr["hoten"].ToString();
                c.giatien = (decimal)dr["doanhthu"];
                c.row = dr["Stt"].ToString();
                baocaonhanvien.Add(c);
            }
            return baocaonhanvien;

        }
        public List<khachhang> loadkhachhang()
        {
            List<khachhang> kh = new List<khachhang>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from khachhang");
            foreach(DataRow dr in data.Rows)
            {
                khachhang k = new khachhang();
                k.Makh = dr["Makh"].ToString();
                k.hoten = dr["hoten"].ToString();
                k.sdt = dr["sdt"].ToString();
                k.email = dr["email"].ToString();
                k.ngaytao = (DateTime)dr["ngaytao"];
                k.diem = (int)dr["diem"];
                kh.Add(k);
            }
            return kh;
        }
        public khachhang searchkhachhang(string sdt)
        {
            khachhang k = new khachhang();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from khachhang where sdt='"+sdt+"'");
            foreach (DataRow dr in data.Rows)
            {
               
                k.Makh = dr["Makh"].ToString();
                k.hoten = dr["hoten"].ToString();
                k.sdt = dr["sdt"].ToString();
                k.email = dr["email"].ToString();
                k.ngaytao = (DateTime)dr["ngaytao"];
                k.diem = (int)dr["diem"];
             
            }
            return k;
        }
        public bool insertkh(string makh,string hoten,string email,string sdt,int diem)
        {
            string quye = "insert into khachhang(Makh,hoten,sdt,ngaytao,email,diem) values ('"+makh+"',N'"+hoten+"','"+sdt+"','"+DateTime.Now+"','"+email+"','"+diem+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool deletekh(string makh)
        {
            string quye = "delete from khachhang where Makh='"+makh+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool updatekh(string makh, string hoten, string email, string sdt)
        {
            string quye = "update khachhang set hoten='"+hoten+"',email='"+email+"',sdt='"+sdt+"'  where Makh='" + makh + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool tichdiemkh(string makh)
        {
            string quye = "update khachhang set diem=diem+10 where Makh='"+makh+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool phieuthanhvienfood(string makh,string mahoadon)
        {
            string quye = "insert into thanhvienbythucan(makh,mahoadonfood) values ('" + makh + "','"+mahoadon+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool phieuthanhvienvexem(string makh, string mahoadon)
        {
            string quye = "insert into thanhvienbyvexem(makh,mahoadon) values ('" + makh + "','" + mahoadon + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
    }
}
