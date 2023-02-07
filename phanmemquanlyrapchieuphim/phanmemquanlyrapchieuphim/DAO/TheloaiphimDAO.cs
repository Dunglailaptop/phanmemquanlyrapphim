using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phanmemquanlyrapchieuphim.DTO;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class TheloaiphimDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static TheloaiphimDAO instance;
        public static TheloaiphimDAO Instance
        {
            get { if (instance == null) instance = new TheloaiphimDAO(); return TheloaiphimDAO.instance; }
            private set { TheloaiphimDAO.instance = value; }
        }

        private TheloaiphimDAO()
        { }
        public List<theloai> loaddstheloai()
        {
            List<theloai> list = new List<theloai>();
            list = db.theloais.ToList();
            return list;
        }
        public List<theloai> gettheloaibyid(int id)
        {
            List<theloai> th = db.theloais.Where(x => x.Matheloai == id).ToList();
            return th;
        }
    }
}
