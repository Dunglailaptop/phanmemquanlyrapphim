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
    public class AccountDAO
    {
        
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO()
        { }
        public bool login(string username,string password)
        {
            string query = "USP_login @username , @Password";
            DataTable  result = DataProvider.Instance.ExecuteQuery(query,new object[] {username,password});
            return result.Rows.Count > 0;
        }
        public Class phanquyen(string username,string password)
        {
            Class CL=new Class();
            string QUYE = "USP_login @username , @Password";
            DataTable data = DataProvider.Instance.ExecuteQuery(QUYE, new object[]
            {
                username,password
            });
            foreach(DataRow row in data.Rows)
            {
                Class CLSS=new Class();
                CL.manv = row["Manhanvien"].ToString();
                CL.tenchucvu = row["Tenchucvu"].ToString();
                CL.hoten = row["hoten"].ToString();
                
            }
            return CL;
        }

        public bool insertaccout(string user,string matkhau,string manv)
        {
            string quye = "insert into account(Username,Password,Manhanvien) values ('"+user+"','"+matkhau+"', '"+manv+"')";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;

        }

        public bool updateaccout(string user, string matkhau)
        {
            string quye = "update account set  Password='" + matkhau + "' where Username='"+user+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;

        }
        public bool deleteaccout(string user)
        {
            string quye = "delete from account where Username='"+user+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(quye);
            return result > 0;

        }
        public bool quenmatkhau(string id)
        {
            string q = "insert into quenmatkhau(Macaplai) values('" + id + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(q);
            return result > 0;
        }
        //public  List<account> loadaccount()
        //{
        //    //List<account> list = new List<account>();
        //    //DataTable data = DataProvider.Instance.ExecuteQuery("USP_getlistaccount");
        //    //foreach(DataRow item in data.Rows)
        //    //{
        //    //    account ac = new account(item);
        //    //    list.Add(ac);
        //    //}
        //    //return list;
        //}
    }
}
