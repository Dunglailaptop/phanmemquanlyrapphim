using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class voucherDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static voucherDAO instance;
        public static voucherDAO Instance
        {
            get { if (instance == null) instance = new voucherDAO(); return voucherDAO.instance; }
            private set { voucherDAO.instance = value; }
        }

        private voucherDAO()
        { }
        public List<voucher> loadvoucher()
        {
            List<voucher> voucherList = new List<voucher>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from voucher");
            foreach(DataRow row in data.Rows)
            {
                voucher vc = new voucher();
                vc.tenkm = row["tenkm"].ToString();
                vc.giagiam = row["giagiam"].ToString();
                vc.ngaycuoi = (DateTime)row["ngaycuoi"];
                vc.ngaydau = (DateTime)row["ngaydau"];
                vc.soluong = (int)row["soluong"];
                vc.Makm = row["Makm"].ToString();
                voucherList.Add(vc);

            }
            return voucherList;
        }
        public voucher loadvoucherbyid(string makm)
        {
            voucher vc = new voucher();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from voucher where Makm='"+makm+"'");
            foreach (DataRow row in data.Rows)
            {
               
                vc.tenkm = row["tenkm"].ToString();
                vc.giagiam = row["giagiam"].ToString();
                vc.ngaycuoi = (DateTime)row["ngaycuoi"];
                vc.ngaydau = (DateTime)row["ngaydau"];
                vc.soluong = (int)row["soluong"];
                vc.Makm = row["Makm"].ToString();
               

            }
            return vc;
        }
        public bool insertvoucher(string tenkm,string giagiam,DateTime ngayd,DateTime ngayc,int solug,int status)
        {
            int reuslt = DataProvider.Instance.ExecuteNonQuery("insert into voucher(tenkm,giagiam,ngaydau,ngaycuoi,soluong,tinhtrang) values (N'" + tenkm + "','" + giagiam + "','" + ngayd + "','" + ngayc + "','" + solug + "','" + status + "')");
            return reuslt > 0;
        }
        public bool deletevoucher(string makm)
        {
            int reuslt = DataProvider.Instance.ExecuteNonQuery("delete from voucher where Makm='"+makm+"'");
            return reuslt > 0;
        }
        public bool updatevoucher(string makm,string tenkm, string giagiam, DateTime ngayd, DateTime ngayc, int solug)
        {
            string quye = "update voucher set tenkm=N'"+tenkm+"' ,ngaydau='"+ngayd+"',ngaycuoi='"+ngayc+"',giagiam='"+giagiam+"',soluong='"+solug+"' where Makm='"+makm+"'";
            int reuslt = DataProvider.Instance.ExecuteNonQuery(quye);
            return reuslt > 0;
        }
        public bool hoadonvoucher(string makm, string mahoadon)
        {
            string quye = "insert into hoadoncovoucher(makm,mahoadon) values ('"+makm+"','"+mahoadon+"')";
            int reuslt = DataProvider.Instance.ExecuteNonQuery(quye);
            return reuslt > 0;
        }
    }
}
