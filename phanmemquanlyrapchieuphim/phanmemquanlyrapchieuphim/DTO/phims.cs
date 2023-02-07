using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.DTO
{
    public class phims
    {
        private int Maphim;
        private string tenphim;
        private string tacgia;
        private System.DateTime Namphathanh;
        private int matheloai;
        private int maquocgia;
        private int thoiluong;
        private string mota;
        private string poster;
        private int maloaiphim;
    
        public phims(int maphim, string tenphim, string tacgia, DateTime namphathanh, int matheloai, int maquocgia, int thoiluong, string mota, string poster, int maloaiphim)
        {
            this.Maphim = maphim;
            this.Tenphim = tenphim;
            this.Tacgia = tacgia;
            this.Namphathanh = namphathanh;
            this.Matheloai = matheloai;
            this.Maquocgia = maquocgia;
            this.Thoiluong = thoiluong;
            this.Mota = mota;
            this.Poster = poster;
            this.Maloaiphim = maloaiphim;
           
        }
        public phims(DataRow row)
        {
            //this.Maphim = (int)row["Maphim"];
            this.tenphim = row["tenphim"].ToString();
            this.tacgia = row["Tacgia"].ToString();
            this.Namphathanh = (DateTime)row["Namphathanh"];
            //this.theloaiphims.Tentheloai = row["tentheloai"].ToString();
            //this.maquocgia = (int)row["Maquocgia"];
          
            //this.loaiphims.Tenloaiphim = row["tenloai"].ToString();
            this.thoiluong = (int)row["Thoiluong"];
            this.mota = row["mota"].ToString();
            this.poster = row["poster"].ToString();

        }
        public int Maphim1 { get => Maphim; set => Maphim = value; }
        public string Tenphim { get => tenphim; set => tenphim = value; }
        public string Tacgia { get => tacgia; set => tacgia = value; }
        public DateTime Namphathanh1 { get => Namphathanh; set => Namphathanh = value; }
        public int Matheloai { get => matheloai; set => matheloai = value; }
        public int Maquocgia { get => maquocgia; set => maquocgia = value; }
        public int Thoiluong { get => thoiluong; set => thoiluong = value; }
        public string Mota { get => mota; set => mota = value; }
        public string Poster { get => poster; set => poster = value; }
        public int Maloaiphim { get => maloaiphim; set => maloaiphim = value; }
       
    }
}
