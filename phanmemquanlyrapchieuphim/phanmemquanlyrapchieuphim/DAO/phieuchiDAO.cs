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
    public class phieuchiDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static phieuchiDAO instance;
        public static phieuchiDAO Instance
        {
            get { if (instance == null) instance = new phieuchiDAO(); return phieuchiDAO.instance; }
            private set { phieuchiDAO.instance = value; }
        }

        private phieuchiDAO()
        { }
        public phieuchi  tongphieuchi(DateTime date1, DateTime date2)
        {
            //List<phieuchi> phieuchiList = new List<phieuchi>();
            phieuchi pc = new phieuchi();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_Tongtienphieuchi '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                
                pc.sotien = (decimal)dr["tongtien"];
                //pc.Thoigian_name = dr["thoigian"].ToString();
              
            }
            return pc;
        }

        public List<Class> loaddsphieuchi()
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOTHU");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["sotien"]*1000;
                pc.Manhanvien = dr["Manhanvien"].ToString();
                pc.Ngaynhap_name= dr["ngay"].ToString();
                pc.Thoigian_name = dr["thoigian"].ToString();
                pc.id = (int)dr["id"];
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }
        public bool taophieuchi(DateTime ngaynhap,DateTime thoigian,decimal sotien)
        {
            string quye= "insert into phieuchi(Ngaynhap,thoigian,sotien,Manhanvien) values ('"+ngaynhap+"','"+thoigian+"','"+sotien+"','NV02')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public List<Class> phieuchi(DateTime date1,DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_BAOCAOCHI '" + date1 + "' , '" + date2 + "'");
            foreach(DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }

        public List<Class> phieuchibyyear(DateTime date1, DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_phieuchibyyear '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }

        public List<Class> phieuchibymonth(DateTime date1, DateTime date2)
        {
            List<Class> phieuchiList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_phieuchibymonth '" + date1 + "' , '" + date2 + "'");
            foreach (DataRow dr in data.Rows)
            {
                Class pc = new Class();
                pc.sotien = (decimal)dr["tongtien"];
                pc.Thoigian_name = dr["Ngaynhaptien"].ToString();
                phieuchiList.Add(pc);
            }
            return phieuchiList;
        }
        public phieuthu sumphieuchi()
        {
            phieuthu pt = new phieuthu();
            DataTable data = DataProvider.Instance.ExecuteQuery("select sum(sotien) as [tongthu] from phieuchi");
            foreach (DataRow dr in data.Rows)
            {
                pt.sotien = (decimal)dr["tongthu"];
            }
            return pt;
        }
    }
}
