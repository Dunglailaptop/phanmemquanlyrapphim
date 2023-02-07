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
    public class phieuthuDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static phieuthuDAO instance;
        public static phieuthuDAO Instance
        {
            get { if (instance == null) instance = new phieuthuDAO(); return phieuthuDAO.instance; }
            private set { phieuthuDAO.instance = value; }
        }

        private phieuthuDAO()
        { }
        public bool taophieuthu(DateTime ngaynhap, DateTime thoigian, decimal sotien)
        {
            string quye = "insert into phieuthu(Ngaytao,thoigian,sotien,Manhanvien) values ('" + ngaynhap + "','" + thoigian + "','" + sotien + "','NV02')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public List<Class> phieuthu(DateTime date1, DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOPHIEUTHU '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }

        public List<Class> phieuthubyyear(DateTime date1, DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_phieuthubyyear '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }

        public List<Class> phieuthubymonth(DateTime date1, DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_phieuthubymonth '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }
        public phieuthu sumphieuthu()
        {
            phieuthu pt = new phieuthu();
            DataTable data = DataProvider.Instance.ExecuteQuery("select sum(sotien) as [tongthu] from phieuthu");
            foreach(DataRow dr in data.Rows)
            {
                pt.sotien = (decimal)dr["tongthu"];
            }
            return pt;
        }
    }
}
