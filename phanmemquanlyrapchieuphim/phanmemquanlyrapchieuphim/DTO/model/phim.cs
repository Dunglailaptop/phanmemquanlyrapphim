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
    using System.Collections.Generic;
    
    public partial class phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phim()
        {
            this.chitietsuatchieux = new HashSet<chitietsuatchieu>();
            this.hoadons = new HashSet<hoadon>();
            this.suatchieux = new HashSet<suatchieu>();
        }
    
        public int Maphim { get; set; }
        public string Tenphim { get; set; }
        public string Tacgia { get; set; }
        public System.DateTime Namphathanh { get; set; }
        public Nullable<int> Matheloai { get; set; }
        public Nullable<int> Maquocgia { get; set; }
        public Nullable<int> Thoiluong { get; set; }
        public string mota { get; set; }
        public string loaiphim { get; set; }
        public byte[] poster { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietsuatchieu> chitietsuatchieux { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
        public virtual quocgia quocgia { get; set; }
        public virtual theloai theloai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<suatchieu> suatchieux { get; set; }
    }
}
