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
    public class quanlythuchiDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static quanlythuchiDAO instance;
        public static quanlythuchiDAO Instance
        {
            get { if (instance == null) instance = new quanlythuchiDAO(); return quanlythuchiDAO.instance; }
            private set { quanlythuchiDAO.instance = value; }
        }

        private quanlythuchiDAO()
        { }
        public List<Class> loaddsthuchi()
        {
            List<Class> list = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_SHOWDSTHUCHI");
            //list = db.quanlythuchis.ToList();
            foreach (DataRow row in data.Rows)
            {
                Class quanlythuchi = new Class();
                quanlythuchi.Ngaynhap_name = row["Ngaynhaptien"].ToString();
                quanlythuchi.Thoigian_name = row["thoigiannhap"].ToString();
                quanlythuchi.sotien =(decimal)row["sotien"];
                quanlythuchi.Manhanvien = row["Manhanvien"].ToString();
                list.Add(quanlythuchi);
            }
            return list;
        }
        public bool nhaptien(decimal SOTIEN,DateTime THOIGIAN,DateTime NGAYNHAP)
        {
            string quye = "insert into quanlythuchi(Ngaynhap,thoigian,sotien,Manhanvien) values ('"+NGAYNHAP+"','"+THOIGIAN+"','"+SOTIEN+"','NV01')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
    }
}
