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
    public class nhanvienDAO
    {
        private static nhanvienDAO instance;
        public static nhanvienDAO Instance
        {
            get { if (instance == null) instance = new nhanvienDAO(); return nhanvienDAO.instance; }
            private set { nhanvienDAO.instance = value; }
        }

        private nhanvienDAO()
        { }

        public List<nhanvien> loaddsnhanvien()
        {
            List<nhanvien> list = new List<nhanvien>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nhanvien");
            foreach(DataRow row in data.Rows)
            {
                nhanvien nv=new nhanvien();
                nv.Manhanvien = row["Manhanvien"].ToString();
                nv.hoten = row["hoten"].ToString();
                nv.Email = row["Email"].ToString();
                nv.sdt = row["sdt"].ToString();
                nv.Ngaysinh = (DateTime)row["Ngaysinh"];
                nv.Ngaybatdau = (DateTime)row["Ngaybatdau"];
                nv.Machucvu = (int)row["Machucvu"];
                nv.hinhanh = (byte[])row["hinhanh"];
                list.Add(nv);
            }
            return list;
        }
        public nhanvien loaddetailnhanvien(string manhanvien)
        {
            nhanvien nv = new nhanvien();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nhanvien where Manhanvien='"+manhanvien+"'");
            foreach (DataRow row in data.Rows)
            {
               
                nv.Manhanvien = row["Manhanvien"].ToString();
                nv.hoten = row["hoten"].ToString();
                nv.Email = row["Email"].ToString();
                nv.sdt = row["sdt"].ToString();
                nv.Ngaysinh = (DateTime)row["Ngaysinh"];
                nv.Ngaybatdau = (DateTime)row["Ngaybatdau"];
                nv.Machucvu = (int)row["Machucvu"];
                nv.hinhanh = (byte[])row["hinhanh"];
                
            }
            return nv;
        }
        public phanquyen loadpq(int manv)
        {
            phanquyen pq = new phanquyen();
            string quye = "select * from phanquyen where Machucvu='"+manv+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(quye);
            foreach(DataRow row in data.Rows)
            {
                pq.Tenchucvu = row["Tenchucvu"].ToString();
            }
            return pq;

        }
        public bool deletenhanvien(string manhanvien)
        {
            string quye = "delete from nhanvien where Manhanvien='" + manhanvien + "'";
            int resullt = DataProvider.Instance.ExecuteNonQuery(quye);
            return resullt > 0;
        }
        public bool insertnv(string manv,string hoten,string email,string sdt,DateTime ngaysinh,string ngaytao,int machucvu, byte[] hinhanh)
        {
            string quye = "insert into nhanvien(hoten,sdt,Email,Ngaysinh,Ngaybatdau,Machucvu,hinhanh) values ('"+hoten+"','"+sdt+"','"+email+"','"+ngaysinh+"','"+ngaytao+"','"+machucvu+"','"+hinhanh+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public List<Class> baocaonhanvienbymonth(DateTime date)
        {
            List<Class> baocaonhanvien = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_topnhanvienbythang '"+date+"'");
            foreach (DataRow dr in data.Rows)
            {
                Class c = new Class();
                c.manv =dr["Manhanvien"].ToString();
                c.hoten = dr["hoten"].ToString();
                c.giatien = (decimal)dr["doanhthu"];
                c.row = dr["Stt"].ToString();
                baocaonhanvien.Add(c);
            }
            return baocaonhanvien;

        }
        public List<Class> baocaonhanvienbyyear(DateTime date)
        {
            List<Class> baocaonhanvien = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("usp_topnhanvienbyyear '" + date + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class c = new Class();
                c.manv = dr["Manhanvien"].ToString();
                c.hoten = dr["hoten"].ToString();
                c.giatien = (decimal)dr["doanhthu"];
                c.row = dr["Stt"].ToString();
                baocaonhanvien.Add(c);
            }
            return baocaonhanvien;

        }
    }
}
