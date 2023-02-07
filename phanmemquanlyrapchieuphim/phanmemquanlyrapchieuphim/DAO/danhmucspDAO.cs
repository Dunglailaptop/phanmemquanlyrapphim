using phanmemquanlyrapchieuphim.DTO;
using phanmemquanlyrapchieuphim.FormStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class danhmucspDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static danhmucspDAO instance;
        public static danhmucspDAO Instance
        {
            get { if (instance == null) instance = new danhmucspDAO(); return danhmucspDAO.instance; }
            private set { danhmucspDAO.instance = value; }
        }

        private danhmucspDAO()
        { }
         
        public bool insertdanhmuc(string tendanhmuc)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert into danhmucsp(tendanhmuc) values (N'" + tendanhmuc + "')");
            return result > 0;
        }
        public bool deletedanhmuc(int madm)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("delete from danhmucsp where Madm='" + madm + "'");
            return result > 0;
        }
        public bool updatedanhmuc(string tendanhmuc,int madm)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update danhmucsp set tendanhmuc=N'"+tendanhmuc+"' where Madm='"+madm+"'");
            return result > 0;
        }
    }
}
