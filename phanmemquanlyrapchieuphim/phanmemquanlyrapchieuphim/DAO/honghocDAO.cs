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
    public class honghocDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static honghocDAO instance;
        public static honghocDAO Instance
        {
            get { if (instance == null) instance = new honghocDAO(); return honghocDAO.instance; }
            private set { honghocDAO.instance = value; }
        }

        private honghocDAO()
        { }
        public bool insertsuco(byte[] anh,string tieude,string mota,int maloai)
        {
            string manv = "NV02";
           int result=db.USP_insertbaocaosuco(tieude,mota,anh,manv,maloai);
            return result >0;
        }
        public bool insertghehong(int idmphong,int soghe)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" USP_baocaohongghe '" + idmphong + "','" + soghe + "'");
            return result > 0;
        }
        public List<ghe> ghehong(int maphong)
        {
            List<ghe> list = new List<ghe>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *,Row+cast(Soghe as varchar) [ghe] from ghe where Maphong='"+maphong+"'");
            foreach(DataRow row in data.Rows)
            {
                ghe gh = new ghe();
                gh.Row = row["ghe"].ToString();
                gh.Maghe = (int)row["Maghe"];
                list.Add(gh);
            }
            return list;
        }
        public List<Class> showbaocao()
        {
            List<Class> bc = new List<Class>();
            DataTable date = DataProvider.Instance.ExecuteQuery("USP_showbaocaosuco");
            foreach(DataRow dt in date.Rows)
            {
                Class bcc = new Class();
                bcc.picture = (byte[])dt["picture"];
                bcc.tenloai = dt["tenloai"].ToString();
                bcc.tieude = dt["tieude"].ToString();
                bcc.motasuco = dt["moto"].ToString();
                bcc.id = (int)dt["id"];
                bc.Add(bcc);
            }
            return bc;
        }
    }
}
