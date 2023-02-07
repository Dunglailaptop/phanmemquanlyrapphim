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
    public class gheDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static gheDAO instance;
        public static gheDAO Instance
        {
            get { if (instance == null) instance = new gheDAO(); return gheDAO.instance; }
            private set { gheDAO.instance = value; }
        }

        private  gheDAO()
        { }
        public List<Class> LAYGHETAO(int ID)
        {
            List<Class> gheList = new List<Class>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LAYGHETAO '" + ID + "'");
            foreach(DataRow row in data.Rows)
            {
                Class g = new Class();
                g.row = row["ghe"].ToString();
                g.maghe = (int)row["Maghe"];
                g.Maphong = (int)row["Maphong"];
                g.mausac =row["mausac"].ToString();
                //g.Soghe = (int)row["gheofday"];
                gheList.Add(g);
            }
            return gheList;
        }
        public bool updateghe(int maghe,int maloaighe)
        {
            string quey = "update ghe set maloaighe='" + maloaighe + "' where Maghe='" + maghe + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(quey);
            return result >0;
        }
        public bool insertghe(int soghe,string row,int maphong,int maloaighe)
        {
            string quey = "insert into ghe(Soghe,Row,Maphong,maloaighe) values ('"+soghe+"','"+row+"','"+maphong+"','"+maloaighe+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quey);
            return result > 0;
        }
        public bool deleteghe(int Maghe)
        {
            string quye = "Delete from ghe where Maghe='" + Maghe + "'";
            int result=DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
        public bool deleteghebyphong(int Maphong)
        {
            string quye = "Delete from ghe where Maphong='" + Maphong + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;
        }
    }
}
