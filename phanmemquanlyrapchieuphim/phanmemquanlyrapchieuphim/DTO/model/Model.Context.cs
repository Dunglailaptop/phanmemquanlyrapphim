//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace phanmemquanlyrapchieuphim.DTO.model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class phanmemquanlyrapchieuphimEntities2 : DbContext
    {
        public phanmemquanlyrapchieuphimEntities2()
            : base("name=phanmemquanlyrapchieuphimEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<baocaosuco> baocaosucoes { get; set; }
        public virtual DbSet<chitietghe> chitietghes { get; set; }
        public virtual DbSet<chitiethoadonsp> chitiethoadonsps { get; set; }
        public virtual DbSet<chitietsuatchieu> chitietsuatchieux { get; set; }
        public virtual DbSet<danhmucsp> danhmucsps { get; set; }
        public virtual DbSet<ghe> ghes { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<hoadonsanpham> hoadonsanphams { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaighe> loaighes { get; set; }
        public virtual DbSet<loaihonghoc> loaihonghocs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<phanloaighebyphong> phanloaighebyphongs { get; set; }
        public virtual DbSet<phanquyen> phanquyens { get; set; }
        public virtual DbSet<phieuchi> phieuchis { get; set; }
        public virtual DbSet<phim> phims { get; set; }
        public virtual DbSet<phong> phongs { get; set; }
        public virtual DbSet<quanlythuchi> quanlythuchis { get; set; }
        public virtual DbSet<quocgia> quocgias { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<suatchieu> suatchieux { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<vexem> vexems { get; set; }
        public virtual DbSet<suatchieuphim> suatchieuphims { get; set; }
    }
}
