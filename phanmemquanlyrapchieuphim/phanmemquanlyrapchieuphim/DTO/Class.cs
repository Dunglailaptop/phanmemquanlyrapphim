using phanmemquanlyrapchieuphim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemquanlyrapchieuphim.FormStaff
{
    public class Class
    {
       //public string 
        public int trangthaighe { get; set; }
        public int stt { get; set; }
       public byte[] picture { get; set; }
        public string tenloai { get; set; }
        public string motasuco { get; set; }
        public string tieude { get; set; }
        public int id { get; set; }
        public decimal sotien { get; set; }
        public string Ngaynhap_name { get; set; }
        public string Thoigian_name { get; set; }
        public string Manhanvien { get; set; }
        public phim phims { get; set; }
        public quocgia quocgias { get; set; }
        public theloai theloais { get;set; }
        public System.Data.Linq.Binary posster2 { get; set; }
        public string loaiphim { get; set; }
        public byte[] poster { get; set; }
        public int thoiluong { get; set; }
        public string tenphim { get; set; }
        public DateTime date { get; set; }
        public int Maphong { get; set; }
        public string thoigianconvert { get; set; }
        public TimeSpan thoigian { get; set; }
        public decimal giave { get; set; }
        public int tongghe { get; set; }
        public int soghe { get; set; }
        public string row { get; set; }
        public string row2 { get; set; }
        public int status { get; set; } 
        public int maphim { get; set; }
        public int machieu { get; set; }
        public int maghe { get; set; }
        public string hoten { get; set; }
        public string tenchucvu { get; set; }
        public string manv { get; set; }
        public string mota { get; set; }
        public string tenquoc { get; set; }
        public string tentheloai { get; set; }
        public string tacgia { get; set; }
        public int tongsoghe { get; set; }
        public string mausac { get; set; }
        public string thoigianchieu { get; set; }
        public DateTime ngaychieu { get; set; }
        public int gheofday { get; set; }
        public string tenphong { get; set; }
          
        public string ngaychieushow { get; set; }




        public string Mahoadon { get; set; }
         
        public int soluongfood { get; set; }

        public string tenfood { get; set; }
        public decimal giatien { get;  set; }

        //public Class(DataRow row)
        //{
        //    phims.Tenphim = row["Tenphim"].ToString();
        //    quocgias.Tenquocgia = row["Tenquocgia"].ToString();
        //}
    }
}
