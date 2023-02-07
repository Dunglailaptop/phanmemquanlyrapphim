using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phanmemquanlyrapchieuphim.DTO;

namespace phanmemquanlyrapchieuphim.DAO
{
    public class QuocgiaDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private static QuocgiaDAO instance;
        public static QuocgiaDAO Instance
        {
            get { if (instance == null) instance = new QuocgiaDAO(); return QuocgiaDAO.instance; }
            private set { QuocgiaDAO.instance = value; }
        }

        private QuocgiaDAO()
        { }
        public List<quocgia> Loaddsquocgia()
        {
            List<quocgia> quocgiaList = db.quocgias.ToList();
            return quocgiaList;
        }
    }
}
