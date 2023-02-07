using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DTO
{
    public class innerjoin 
    {
        private suatchieu suatchieus;
        private chitietsuatchieu chitietsuatchieus;
        private phim phims;
        public suatchieu Suatchieus { get => suatchieus; set => suatchieus = value; }
        public chitietsuatchieu Chitietsuatchieus { get => chitietsuatchieus; set => chitietsuatchieus = value; }
        public phim Phims { get => phims; set => phims = value; }
    }
}
